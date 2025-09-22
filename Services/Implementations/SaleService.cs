using System;
using System.Data;
using System.Data.SqlClient;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly string _cs;
        public SaleService(string connectionString) { _cs = connectionString; }

        public int CreateSaleWithAllocation(SaleCreateRequest req)
        {
            using (var conn = new SqlConnection(_cs))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    try
                    {
                        // 1) Insert Sale
                        cmd.CommandText = "INSERT INTO Sale(CustomerName, TotalAmount, SaleDate, SaleBy) VALUES(@c,@t, SYSUTCDATETIME(), @by); SELECT SCOPE_IDENTITY();";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@c", (object)(req.CustomerName ?? (object)DBNull.Value));
                        cmd.Parameters.AddWithValue("@t", req.TotalAmount);
                        cmd.Parameters.AddWithValue("@by", (object)(req.SaleBy ?? (object)DBNull.Value));
                        var saleId = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach (var d in req.Details)
                        {
                            // Ensure valid quantities
                            var totalPills = d.QuantityPacks * d.PillsPerPack + d.QuantityPills;
                            if (totalPills <= 0) throw new InvalidOperationException("S? l??ng bán ph?i > 0");
                            if (!d.PackagingId.HasValue && !d.MedicineId.HasValue)
                                throw new InvalidOperationException("Thi?u thông tin thu?c/pack");
                            if (!d.BatchId.HasValue) throw new InvalidOperationException("Thi?u BatchId");

                            // Validate stock and expiry
                            int available = 0; DateTime exp = DateTime.MaxValue;
                            cmd.CommandText = "SELECT QuantityPills, ExpiryDate FROM Batch WHERE BatchId=@bid";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@bid", d.BatchId.Value);
                            using (var rdr = cmd.ExecuteReader())
                            {
                                if (!rdr.Read()) throw new InvalidOperationException("Batch không t?n t?i");
                                available = Convert.ToInt32(rdr[0]);
                                exp = Convert.ToDateTime(rdr[1]);
                            }
                            if (exp.Date < DateTime.Today) throw new InvalidOperationException("Lô ?ã h?t h?n");
                            if (available < totalPills) throw new InvalidOperationException("Không ?? hàng trong kho");

                            // 2) Insert SaleDetail (UnitPrice per pill)
                            cmd.CommandText = @"INSERT INTO SaleDetail(SaleId, MedicineId, PackagingId, QuantityPacks, QuantityPills, UnitPrice)
VALUES(@sid,@mid,@pid,@qpacks,@qpills,@price); SELECT SCOPE_IDENTITY();";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@sid", saleId);
                            cmd.Parameters.AddWithValue("@mid", (object)(d.MedicineId ?? (object)DBNull.Value));
                            cmd.Parameters.AddWithValue("@pid", (object)(d.PackagingId ?? (object)DBNull.Value));
                            cmd.Parameters.AddWithValue("@qpacks", d.QuantityPacks);
                            cmd.Parameters.AddWithValue("@qpills", d.QuantityPills);
                            cmd.Parameters.AddWithValue("@price", d.UnitPrice);
                            var saleDetailId = Convert.ToInt32(cmd.ExecuteScalar());

                            // 3) Allocate from selected batch
                            cmd.CommandText = "UPDATE Batch SET QuantityPills = QuantityPills - @take WHERE BatchId=@bid";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@take", totalPills);
                            cmd.Parameters.AddWithValue("@bid", d.BatchId.Value);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "INSERT INTO SaleBatchAllocation(SaleId, SaleDetailId, BatchId, AllocatedPills) VALUES(@sid,@sdid,@bid,@alloc)";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@sid", saleId);
                            cmd.Parameters.AddWithValue("@sdid", saleDetailId);
                            cmd.Parameters.AddWithValue("@bid", d.BatchId.Value);
                            cmd.Parameters.AddWithValue("@alloc", totalPills);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return saleId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }

    public interface ISaleService
    {
        int CreateSaleWithAllocation(SaleCreateRequest req);
    }

    public class SaleCreateRequest
    {
        public string CustomerName { get; set; }
        public int? SaleBy { get; set; }
        public decimal TotalAmount { get; set; }
        public System.Collections.Generic.List<SaleDetailCreate> Details { get; set; } = new System.Collections.Generic.List<SaleDetailCreate>();
    }
    public class SaleDetailCreate
    {
        public int? MedicineId { get; set; }
        public int? PackagingId { get; set; }
        public int? BatchId { get; set; }
        public int QuantityPacks { get; set; }
        public int QuantityPills { get; set; }
        public int PillsPerPack { get; set; }
        public decimal UnitPrice { get; set; } // per pill
    }
}
