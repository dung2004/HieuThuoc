using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class BatchService : IBatchService
    {
        private readonly string _connectionString;
        public BatchService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Near expiry helper retained
        public IEnumerable<Batch> GetNearExpiry(DateTime fromDate, int daysThreshold, int? medicineId = null)
        {
            var list = new List<Batch>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT b.BatchId,
                                        b.PackagingId,
                                        p.MedicineId AS MedicineId,
                                        b.BatchCode,
                                        b.ExpiryDate,
                                        b.QuantityPills,
                                        b.PurchasePrice,
                                        b.ReceivedPacks,
                                        b.ReceivedLoosePills,
                                        b.CreatedAt
                                    FROM Batch b
                                    LEFT JOIN Packaging p ON p.PackagingId = b.PackagingId
                                    WHERE b.ExpiryDate BETWEEN @from AND DATEADD(DAY, @days, @from)
                                    AND b.QuantityPills > 0" + (medicineId.HasValue ? " AND p.MedicineId = @mid" : "") + " ORDER BY b.ExpiryDate";
                cmd.Parameters.AddWithValue("@from", fromDate.Date);
                cmd.Parameters.AddWithValue("@days", daysThreshold);
                if (medicineId.HasValue) cmd.Parameters.AddWithValue("@mid", medicineId.Value);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read()) list.Add(Map(rdr));
                }
            }
            return list;
        }

        public IEnumerable<Batch> SearchBatches(int? medicineId, DateTime? fromExpiry, DateTime? toExpiry, string keyword)
        {
            var list = new List<Batch>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                var sb = new System.Text.StringBuilder();
                sb.Append(@"SELECT b.BatchId,
                               b.PackagingId,
                               p.MedicineId AS MedicineId,
                               b.BatchCode,
                               b.ExpiryDate,
                               b.QuantityPills,
                               b.PurchasePrice,
                               b.ReceivedPacks,
                               b.ReceivedLoosePills,
                               b.CreatedAt
                            FROM Batch b
                            LEFT JOIN Packaging p ON p.PackagingId = b.PackagingId
                            WHERE 1=1");
                if (medicineId.HasValue && medicineId.Value > 0) { sb.Append(" AND p.MedicineId=@mid"); cmd.Parameters.AddWithValue("@mid", medicineId.Value); }
                if (fromExpiry.HasValue) { sb.Append(" AND b.ExpiryDate >= @from"); cmd.Parameters.AddWithValue("@from", fromExpiry.Value.Date); }
                if (toExpiry.HasValue) { sb.Append(" AND b.ExpiryDate <= @to"); cmd.Parameters.AddWithValue("@to", toExpiry.Value.Date); }
                if (!string.IsNullOrWhiteSpace(keyword)) { sb.Append(" AND (CAST(b.BatchId AS NVARCHAR(50)) LIKE @kw OR b.BatchCode LIKE @kw)"); cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%"); }
                sb.Append(" ORDER BY b.ExpiryDate");
                cmd.CommandText = sb.ToString();
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read()) list.Add(Map(rdr));
                }
            }
            return list;
        }

        public void UpdateBatch(Batch batch)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Batch SET BatchCode=@code, ExpiryDate=@exp, PurchasePrice=@price, ReceivedPacks=@packs, ReceivedLoosePills=@loose, CreatedAt=@created WHERE BatchId=@id";
                cmd.Parameters.AddWithValue("@code", (object)(batch.BatchCode ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@exp", batch.ExpiryDate);
                cmd.Parameters.AddWithValue("@price", batch.PurchasePrice);
                cmd.Parameters.AddWithValue("@packs", (object)(batch.ReceivedPacks ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@loose", (object)(batch.ReceivedLoosePills ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@created", batch.CreatedAt);
                cmd.Parameters.AddWithValue("@id", batch.BatchId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBatch(int batchId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Batch WHERE BatchId=@id";
                cmd.Parameters.AddWithValue("@id", batchId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private Batch Map(System.Data.IDataRecord rdr)
        {
            return new Batch
            {
                BatchId = rdr["BatchId"] != DBNull.Value ? (int)rdr["BatchId"] : 0,
                PackagingId = rdr["PackagingId"] != DBNull.Value ? (int)rdr["PackagingId"] : 0,
                MedicineId = rdr["MedicineId"] != DBNull.Value ? (int)rdr["MedicineId"] : 0,
                BatchCode = rdr["BatchCode"] != DBNull.Value ? rdr["BatchCode"].ToString() : null,
                ExpiryDate = rdr["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(rdr["ExpiryDate"]) : DateTime.MinValue,
                QuantityPills = rdr["QuantityPills"] != DBNull.Value ? (int)rdr["QuantityPills"] : 0,
                PurchasePrice = rdr["PurchasePrice"] != DBNull.Value ? Convert.ToDecimal(rdr["PurchasePrice"]) : 0m,
                ReceivedPacks = rdr["ReceivedPacks"] != DBNull.Value ? (int?)Convert.ToInt32(rdr["ReceivedPacks"]) : null,
                ReceivedLoosePills = rdr["ReceivedLoosePills"] != DBNull.Value ? (int?)Convert.ToInt32(rdr["ReceivedLoosePills"]) : null,
                CreatedAt = rdr["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(rdr["CreatedAt"]) : DateTime.MinValue
            };
        }
    }
}
