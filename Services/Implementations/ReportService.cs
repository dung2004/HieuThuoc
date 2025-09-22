using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.DTOs;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly string _connectionString;
        public ReportService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DashboardStatsDto GetDashboardStats(int currentUserRoleId)
        {
            // Đơn giản: RevenueToday = tổng Sale.TotalAmount trong ngày; TotalStockPills =
            // SUM(Batch.QuantityPills)
            // Có thể lọc theo quyền nếu cần (ví dụ nhân viên xem doanh thu cá nhân) — chưa
            // có seller nên trả về tổng.
            var dto = new DashboardStatsDto();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                                    SELECT
                                      (SELECT ISNULL(SUM(TotalAmount),0)
                                       FROM Sale
                                       WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)) AS RevenueToday,
                                      (SELECT ISNULL(SUM(QuantityPills),0) FROM Batch) AS TotalStockPills";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        dto.RevenueToday = rdr["RevenueToday"] != DBNull.Value ? Convert.ToDecimal(rdr["RevenueToday"]) : 0m;
                        dto.TotalStockPills = rdr["TotalStockPills"] != DBNull.Value ? Convert.ToInt32(rdr["TotalStockPills"]) : 0;
                    }
                }
            }
            return dto;
        }

        //tính KPI và series doanh thu trong 'days' ngày gần nhất
        public IEnumerable<RevenuePointDto> GetRevenueSeries(int days)
        {
            var list = new List<RevenuePointDto>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                                WITH d AS (
                                  SELECT CAST(GETDATE() AS DATE) AS d
                                  UNION ALL
                                  SELECT DATEADD(DAY, -1, d) FROM d WHERE d > DATEADD(DAY, -@days, CAST(GETDATE() AS DATE))
                                )
                                SELECT d AS [Date],
                                       (SELECT ISNULL(SUM(TotalAmount),0) FROM Sale WHERE CAST(SaleDate AS DATE) = d) AS Total
                                FROM d
                                ORDER BY d";
                cmd.Parameters.AddWithValue("@days", days);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new RevenuePointDto
                        {
                            Date = Convert.ToDateTime(rdr["Date"]),
                            Total = rdr["Total"] != DBNull.Value ? Convert.ToDecimal(rdr["Total"]) : 0m
                        });
                    }
                }
            }
            return list;
        }
    }
}
