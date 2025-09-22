using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public class PackagingRepository : IPackagingRepository
    {
        private readonly string _connectionString;
        public PackagingRepository(string cs) { _connectionString = cs; }

        public IEnumerable<Packaging> GetAll(string keyword = null)
        {
            var list = new List<Packaging>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT PackagingId, MedicineId, PackagingCode, Name, PillsPerPack, PricePerPack, PricePerPill
FROM Packaging" + (string.IsNullOrWhiteSpace(keyword) ? "" : " WHERE (Name LIKE @kw OR PackagingCode LIKE @kw)");
                if (!string.IsNullOrWhiteSpace(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(Map(rdr));
                    }
                }
            }
            return list;
        }

        public IEnumerable<Packaging> GetByMedicine(int medicineId, string keyword = null)
        {
            var list = new List<Packaging>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT 
                                    PackagingId, MedicineId, PackagingCode, 
                                    Name, PillsPerPack, PricePerPack, PricePerPill
                                    FROM Packaging 
                                    WHERE MedicineId=@mid" 
                                      + (string.IsNullOrWhiteSpace(keyword) 
                                          ? "" : " AND (Name LIKE @kw OR PackagingCode LIKE @kw)");
                cmd.Parameters.AddWithValue("@mid", medicineId);
                if (!string.IsNullOrWhiteSpace(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(Map(rdr));
                    }
                }
            }
            return list;
        }

        private Packaging Map(System.Data.IDataRecord rdr)
        {
            return new Packaging
            {
                PackagingId = Convert.ToInt32(rdr["PackagingId"]),
                MedicineId = Convert.ToInt32(rdr["MedicineId"]),
                PackagingCode = rdr["PackagingCode"].ToString(),
                Name = rdr["Name"].ToString(),
                PillsPerPack = Convert.ToInt32(rdr["PillsPerPack"]),
                PricePerPack = rdr["PricePerPack"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rdr["PricePerPack"]),
                PricePerPill = rdr["PricePerPill"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rdr["PricePerPill"])
            };
        }

        public Packaging GetByMedicineAndCode(int medicineId, string code)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT TOP 1 PackagingId, MedicineId, PackagingCode, Name, PillsPerPack, PricePerPack, PricePerPill
FROM Packaging WHERE MedicineId=@mid AND PackagingCode=@code";
                cmd.Parameters.AddWithValue("@mid", medicineId);
                cmd.Parameters.AddWithValue("@code", code);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    return new Packaging
                    {
                        PackagingId = Convert.ToInt32(rdr["PackagingId"]),
                        MedicineId = Convert.ToInt32(rdr["MedicineId"]),
                        PackagingCode = rdr["PackagingCode"].ToString(),
                        Name = rdr["Name"].ToString(),
                        PillsPerPack = Convert.ToInt32(rdr["PillsPerPack"]),
                        PricePerPack = rdr["PricePerPack"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rdr["PricePerPack"]),
                        PricePerPill = rdr["PricePerPill"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rdr["PricePerPill"])
                    };
                }
            }
        }

        public int Add(Packaging p)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Packaging(MedicineId, PackagingCode, Name, PillsPerPack, PricePerPack, PricePerPill)
VALUES(@mid, @code, @name, @pills, @ppack, @ppill); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@mid", p.MedicineId);
                cmd.Parameters.AddWithValue("@code", p.PackagingCode);
                cmd.Parameters.AddWithValue("@name", (object)p.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pills", p.PillsPerPack);
                cmd.Parameters.AddWithValue("@ppack", (object)p.PricePerPack ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ppill", (object)p.PricePerPill ?? (object)DBNull.Value);
                conn.Open();
                var idObj = cmd.ExecuteScalar();
                return Convert.ToInt32(idObj);
            }
        }

        public void Update(Packaging p)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Packaging SET PackagingCode=@code, Name=@name, PillsPerPack=@pills, PricePerPack=@ppack, PricePerPill=@ppill
WHERE PackagingId=@id";
                cmd.Parameters.AddWithValue("@code", p.PackagingCode);
                cmd.Parameters.AddWithValue("@name", (object)p.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pills", p.PillsPerPack);
                cmd.Parameters.AddWithValue("@ppack", (object)p.PricePerPack ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ppill", (object)p.PricePerPill ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", p.PackagingId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int packagingId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Packaging WHERE PackagingId=@id";
                cmd.Parameters.AddWithValue("@id", packagingId);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // FK violation
                    {
                        throw new InvalidOperationException("Cannot delete this packaging because it is referenced in other transactions (SaleDetail/Batch/Purchase). Please delete or update the related records first.");
                    }
                    throw;
                }
            }
        }
    }
}