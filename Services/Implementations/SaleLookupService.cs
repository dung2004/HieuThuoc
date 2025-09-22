using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Services.DTOs;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class SaleLookupService : ISaleLookupService
    {
        private readonly string _cs;
        public SaleLookupService(string connectionString) { _cs = connectionString; }

        public IEnumerable<SimpleLookup> GetMedicinesByName()
        {
            var list = new List<SimpleLookup>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT MedicineId AS Id, Name FROM Medicine ORDER BY Name";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read()) list.Add(new SimpleLookup { Id = rdr.GetInt32(0), Name = rdr.GetString(1) });
            }
            return list;
        }

        public IEnumerable<SimpleLookup> GetMedicinesByCode()
        {
            var list = new List<SimpleLookup>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT MedicineId AS Id, MedicineCode AS Name FROM Medicine ORDER BY MedicineCode";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read()) list.Add(new SimpleLookup { Id = rdr.GetInt32(0), Name = rdr.GetString(1) });
            }
            return list;
        }

        public IEnumerable<PackagingLookup> GetPackagingsByMedicine(int medicineId)
        {
            var list = new List<PackagingLookup>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT p.PackagingId, p.Name, p.MedicineId, m.Name AS MedicineName, p.PillsPerPack, p.PricePerPill
FROM Packaging p LEFT JOIN Medicine m ON m.MedicineId = p.MedicineId WHERE p.MedicineId=@mid ORDER BY p.Name";
                cmd.Parameters.AddWithValue("@mid", medicineId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new PackagingLookup
                        {
                            PackagingId = rdr.GetInt32(0),
                            PackagingName = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                            MedicineId = rdr.GetInt32(2),
                            MedicineName = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                            PillsPerPack = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                            PricePerPill = rdr.IsDBNull(5) ? (decimal?)null : rdr.GetDecimal(5)
                        });
                    }
                }
            }
            return list;
        }

        public IEnumerable<BatchLookup> GetBatchesByPackaging(int packagingId)
        {
            var list = new List<BatchLookup>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT BatchId, ExpiryDate, QuantityPills FROM Batch WHERE PackagingId=@pid ORDER BY ExpiryDate";
                cmd.Parameters.AddWithValue("@pid", packagingId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new BatchLookup
                        {
                            BatchId = rdr.GetInt32(0),
                            ExpiryDate = rdr.GetDateTime(1),
                            QuantityPills = rdr.GetInt32(2)
                        });
                    }
                }
            }
            return list;
        }

        public IEnumerable<SaleGridRow> SearchSales(string keyword)
        {
            var list = new List<SaleGridRow>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT s.SaleId, sd.SaleDetailId, sd.MedicineId, m.Name, m.MedicineCode, s.CustomerName,
 sd.PackagingId, p.Name AS PackagingName, sba.BatchId, b.QuantityPills AS TotalQuantityPills,
 sd.QuantityPacks, sd.QuantityPills, p.PillsPerPack, (sd.QuantityPacks * p.PillsPerPack + sd.QuantityPills) AS TotalPills,
 sd.UnitPrice AS PricePerPill, s.TotalAmount, s.SaleDate, s.SaleBy
FROM Sale s
JOIN SaleDetail sd ON sd.SaleId = s.SaleId
LEFT JOIN SaleBatchAllocation sba ON sba.SaleDetailId = sd.SaleDetailId
LEFT JOIN Batch b ON b.BatchId = sba.BatchId
LEFT JOIN Packaging p ON p.PackagingId = sd.PackagingId
LEFT JOIN Medicine m ON m.MedicineId = sd.MedicineId
WHERE (@kw IS NULL OR @kw = '' OR m.Name LIKE @kw OR m.MedicineCode LIKE @kw OR s.CustomerName LIKE @kw OR p.Name LIKE @kw OR CAST(s.SaleBy AS NVARCHAR(50)) LIKE @kw)
ORDER BY s.SaleDate DESC, s.SaleId DESC";
                cmd.Parameters.AddWithValue("@kw", (object)DBNull.Value);
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.Parameters["@kw"].Value = "%" + keyword + "%";
                }
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new SaleGridRow
                        {
                            SaleId = rdr.GetInt32(0),
                            SaleDetailId = rdr.GetInt32(1),
                            MedicineId = rdr.IsDBNull(2) ? (int?)null : rdr.GetInt32(2),
                            MedicineName = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                            MedicineCode = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                            CustomerName = rdr.IsDBNull(5) ? null : rdr.GetString(5),
                            PackagingId = rdr.IsDBNull(6) ? (int?)null : rdr.GetInt32(6),
                            PackagingName = rdr.IsDBNull(7) ? null : rdr.GetString(7),
                            BatchId = rdr.IsDBNull(8) ? (int?)null : rdr.GetInt32(8),
                            TotalQuantityPills = rdr.IsDBNull(9) ? 0 : rdr.GetInt32(9),
                            QuantityPacks = rdr.IsDBNull(10) ? 0 : rdr.GetInt32(10),
                            QuantityPills = rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11),
                            PillsPerPack = rdr.IsDBNull(12) ? 0 : rdr.GetInt32(12),
                            TotalPills = rdr.IsDBNull(13) ? 0 : rdr.GetInt32(13),
                            PricePerPill = rdr.IsDBNull(14) ? 0 : rdr.GetDecimal(14),
                            TotalAmount = rdr.IsDBNull(15) ? 0 : rdr.GetDecimal(15),
                            SaleDate = rdr.GetDateTime(16),
                            SaleBy = rdr.IsDBNull(17) ? (int?)null : rdr.GetInt32(17)
                        });
                    }
                }
            }
            return list;
        }

        public IEnumerable<SaleGridRow> SearchSalesByDate(DateTime date)
        {
            var list = new List<SaleGridRow>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT s.SaleId, sd.SaleDetailId, sd.MedicineId, m.Name, m.MedicineCode, s.CustomerName,
 sd.PackagingId, p.Name AS PackagingName, sba.BatchId, b.QuantityPills AS TotalQuantityPills,
 sd.QuantityPacks, sd.QuantityPills, p.PillsPerPack, (sd.QuantityPacks * p.PillsPerPack + sd.QuantityPills) AS TotalPills,
 sd.UnitPrice AS PricePerPill, s.TotalAmount, s.SaleDate, s.SaleBy
FROM Sale s
JOIN SaleDetail sd ON sd.SaleId = s.SaleId
LEFT JOIN SaleBatchAllocation sba ON sba.SaleDetailId = sd.SaleDetailId
LEFT JOIN Batch b ON b.BatchId = sba.BatchId
LEFT JOIN Packaging p ON p.PackagingId = sd.PackagingId
LEFT JOIN Medicine m ON m.MedicineId = sd.MedicineId
WHERE CAST(s.SaleDate AS DATE) = @d
ORDER BY s.SaleDate DESC, s.SaleId DESC";
                cmd.Parameters.AddWithValue("@d", date.Date);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new SaleGridRow
                        {
                            SaleId = rdr.GetInt32(0),
                            SaleDetailId = rdr.GetInt32(1),
                            MedicineId = rdr.IsDBNull(2) ? (int?)null : rdr.GetInt32(2),
                            MedicineName = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                            MedicineCode = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                            CustomerName = rdr.IsDBNull(5) ? null : rdr.GetString(5),
                            PackagingId = rdr.IsDBNull(6) ? (int?)null : rdr.GetInt32(6),
                            PackagingName = rdr.IsDBNull(7) ? null : rdr.GetString(7),
                            BatchId = rdr.IsDBNull(8) ? (int?)null : rdr.GetInt32(8),
                            TotalQuantityPills = rdr.IsDBNull(9) ? 0 : rdr.GetInt32(9),
                            QuantityPacks = rdr.IsDBNull(10) ? 0 : rdr.GetInt32(10),
                            QuantityPills = rdr.IsDBNull(11) ? 0 : rdr.GetInt32(11),
                            PillsPerPack = rdr.IsDBNull(12) ? 0 : rdr.GetInt32(12),
                            TotalPills = rdr.IsDBNull(13) ? 0 : rdr.GetInt32(13),
                            PricePerPill = rdr.IsDBNull(14) ? 0 : rdr.GetDecimal(14),
                            TotalAmount = rdr.IsDBNull(15) ? 0 : rdr.GetDecimal(15),
                            SaleDate = rdr.GetDateTime(16),
                            SaleBy = rdr.IsDBNull(17) ? (int?)null : rdr.GetInt32(17)
                        });
                    }
                }
            }
            return list;
        }
    }
}
