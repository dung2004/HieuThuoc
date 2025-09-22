using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HieuThuoc.Services.DTOs;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly string _cs;
        public PurchaseService(string connectionString) { _cs = connectionString; }

        public IEnumerable<PurchaseGridRow> LoadGrid()
        {
            var list = new List<PurchaseGridRow>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
                                      p.PurchaseId,
                                      pd.PurchaseDetailId,
                                      s.SupplierId,
                                      s.Name AS SupplierName,
                                      pk.PackagingId,
                                      pk.Name AS PackagingName,
                                      m.Name AS MedicineName,
                                      b.BatchCode,
                                      b.ExpiryDate,
                                      pd.QuantityPacks       AS ReceivedPacks,
                                      pk.PillsPerPack,
                                      b.ReceivedLoosePills,
                                      pd.QuantityPills,
                                      pd.UnitPricePerPill,
                                      p.TotalAmount,
                                      p.PurchaseDate
                                    FROM Purchase p
                                    INNER JOIN PurchaseDetail pd ON pd.PurchaseId = p.PurchaseId
                                    INNER JOIN Batch b ON b.BatchId = pd.BatchId
                                    LEFT JOIN Packaging pk ON pk.PackagingId = b.PackagingId
                                    LEFT JOIN Medicine m ON m.MedicineId = pk.MedicineId
                                    LEFT JOIN Supplier s ON s.SupplierId = p.SupplierId
                                    ORDER BY p.PurchaseDate DESC, p.PurchaseId DESC;";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new PurchaseGridRow
                        {
                            PurchaseId = rdr.GetInt32(0),
                            PurchaseDetailId = rdr.GetInt32(1),
                            SupplierId = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2),
                            SupplierName = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                            PackagingId = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                            PackagingName = rdr.IsDBNull(5) ? null : rdr.GetString(5),
                            MedicineName = rdr.IsDBNull(6) ? null : rdr.GetString(6),
                            BatchCode = rdr.IsDBNull(7) ? null : rdr.GetString(7),
                            ExpiryDate = rdr.GetDateTime(8),
                            ReceivedPacks = rdr.IsDBNull(9) ? 0 : rdr.GetInt32(9),
                            PillsPerPack = rdr.IsDBNull(10) ? 0 : rdr.GetInt32(10),
                            ReceivedLoosePills = rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11),
                            QuantityPills = rdr.GetInt32(12),
                            UnitPricePerPill = rdr.GetDecimal(13),
                            TotalAmount = rdr.GetDecimal(14),
                            PurchaseDate = rdr.GetDateTime(15)
                        });
                    }
                }
            }
            return list;
        }

        public IEnumerable<SimpleLookup> GetSuppliers()
        {
            var list = new List<SimpleLookup>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT SupplierId AS Id, Name FROM Supplier ORDER BY Name";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new SimpleLookup { Id = rdr.GetInt32(0), Name = rdr.GetString(1) });
                    }
                }
            }
            return list;
        }

        public IEnumerable<PackagingLookup> GetPackagings()
        {
            var list = new List<PackagingLookup>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT p.PackagingId, p.Name, p.MedicineId, m.Name AS MedicineName, p.PillsPerPack
                                    FROM Packaging p
                                    LEFT JOIN Medicine m ON m.MedicineId = p.MedicineId
                                    ORDER BY p.Name";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new PackagingLookup
                        {
                            PackagingId = rdr.GetInt32(0),
                            PackagingName = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                            MedicineId = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2),
                            MedicineName = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                            PillsPerPack = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4)
                        });
                    }
                }
            }
            return list;
        }

        public int SavePurchaseTransaction(PurchaseSaveRequest req)
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
                        // Tính sẵn QuantityPills
                        var quantityPills = req.ReceivedPacks * req.PillsPerPack + req.ReceivedLoosePills;

                        // 1) Insert Purchase
                        cmd.CommandText = "INSERT INTO Purchase(SupplierId, PurchaseDate, TotalAmount) VALUES(@sid, @date, @total); SELECT SCOPE_IDENTITY();";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@sid", req.SupplierId);
                        cmd.Parameters.AddWithValue("@date", req.PurchaseDate);
                        cmd.Parameters.AddWithValue("@total", req.TotalAmount);
                        var purchaseId = Convert.ToInt32(cmd.ExecuteScalar());

                        // 2) Insert Batch (chèn QuantityPills để tránh NULL vi phạm NOT NULL)
                        cmd.CommandText = @"INSERT INTO Batch(PackagingId, BatchCode, ExpiryDate, QuantityPills, PurchasePrice, ReceivedPacks, ReceivedLoosePills, CreatedAt)
                                            VALUES(@pid, @code, @exp, @qty, @price, @packs, @loose, SYSUTCDATETIME()); SELECT SCOPE_IDENTITY();";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pid", req.PackagingId);
                        cmd.Parameters.AddWithValue("@code", (object)(req.BatchCode ?? (object)DBNull.Value));
                        cmd.Parameters.AddWithValue("@exp", req.ExpiryDate);
                        cmd.Parameters.AddWithValue("@qty", quantityPills);
                        cmd.Parameters.AddWithValue("@price", req.UnitPricePerPill);
                        cmd.Parameters.AddWithValue("@packs", (object)req.ReceivedPacks);
                        cmd.Parameters.AddWithValue("@loose", (object)req.ReceivedLoosePills);
                        var batchId = Convert.ToInt32(cmd.ExecuteScalar());

                        // 3) Insert PurchaseDetail
                        cmd.CommandText = @"INSERT INTO PurchaseDetail(PurchaseId, BatchId, QuantityPacks, QuantityPills, UnitPricePerPill)
                                            VALUES(@purId, @batchId, @qpacks, @qpills, @unit); SELECT SCOPE_IDENTITY();";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@purId", purchaseId);
                        cmd.Parameters.AddWithValue("@batchId", batchId);
                        cmd.Parameters.AddWithValue("@qpacks", req.ReceivedPacks);
                        cmd.Parameters.AddWithValue("@qpills", quantityPills);
                        cmd.Parameters.AddWithValue("@unit", req.UnitPricePerPill);
                        var detailId = Convert.ToInt32(cmd.ExecuteScalar());

                        tx.Commit();
                        return purchaseId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdatePurchase(PurchaseUpdateRequest req)
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
                        // Update Purchase
                        cmd.CommandText = "UPDATE Purchase SET SupplierId=@sid, PurchaseDate=@date, TotalAmount=@total WHERE PurchaseId=@id";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@sid", req.SupplierId);
                        cmd.Parameters.AddWithValue("@date", req.PurchaseDate);
                        cmd.Parameters.AddWithValue("@total", req.TotalAmount);
                        cmd.Parameters.AddWithValue("@id", req.PurchaseId);
                        cmd.ExecuteNonQuery();

                        // Tính lại QuantityPills
                        var quantityPills = req.ReceivedPacks * req.PillsPerPack + req.ReceivedLoosePills;

                        // Update Batch (cập nhật luôn QuantityPills để đồng bộ)
                        cmd.CommandText = @"UPDATE Batch SET PackagingId=@pid, BatchCode=@code, ExpiryDate=@exp, QuantityPills=@qty, PurchasePrice=@price, ReceivedPacks=@packs, ReceivedLoosePills=@loose WHERE BatchId=(SELECT BatchId FROM PurchaseDetail WHERE PurchaseDetailId=@pdid)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pid", req.PackagingId);
                        cmd.Parameters.AddWithValue("@code", (object)(req.BatchCode ?? (object)DBNull.Value));
                        cmd.Parameters.AddWithValue("@exp", req.ExpiryDate);
                        cmd.Parameters.AddWithValue("@qty", quantityPills);
                        cmd.Parameters.AddWithValue("@price", req.UnitPricePerPill);
                        cmd.Parameters.AddWithValue("@packs", req.ReceivedPacks);
                        cmd.Parameters.AddWithValue("@loose", req.ReceivedLoosePills);
                        cmd.Parameters.AddWithValue("@pdid", req.PurchaseDetailId);
                        cmd.ExecuteNonQuery();

                        // Update PurchaseDetail
                        cmd.CommandText = @"UPDATE PurchaseDetail SET QuantityPacks=@qpacks, QuantityPills=@qpills, UnitPricePerPill=@unit WHERE PurchaseDetailId=@pdid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@qpacks", req.ReceivedPacks);
                        cmd.Parameters.AddWithValue("@qpills", quantityPills);
                        cmd.Parameters.AddWithValue("@unit", req.UnitPricePerPill);
                        cmd.Parameters.AddWithValue("@pdid", req.PurchaseDetailId);
                        cmd.ExecuteNonQuery();

                        tx.Commit();
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
}
