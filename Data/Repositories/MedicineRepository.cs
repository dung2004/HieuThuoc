using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly string _connectionString;
        public MedicineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Medicine> GetAll(string search = null)
        {
            var list = new List<Medicine>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT MedicineId, MedicineCode, Name, GenericName, Manufacturer, Unit, Description, ImageFile FROM Medicine " +
                                  (string.IsNullOrWhiteSpace(search) ? "" : "WHERE Name LIKE @kw OR MedicineCode LIKE @kw");
                if (!string.IsNullOrWhiteSpace(search)) cmd.Parameters.AddWithValue("@kw", "%" + search + "%");
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Medicine
                        {
                            MedicineId = Convert.ToInt32(rdr["MedicineId"]),
                            MedicineCode = rdr["MedicineCode"].ToString(),
                            Name = rdr["Name"].ToString(),
                            GenericName = rdr["GenericName"] == DBNull.Value ? null : rdr["GenericName"].ToString(),
                            Manufacturer = rdr["Manufacturer"] == DBNull.Value ? null : rdr["Manufacturer"].ToString(),
                            Unit = rdr["Unit"].ToString(),
                            Description = rdr["Description"] == DBNull.Value ? null : rdr["Description"].ToString(),
                            ImageFile = rdr["ImageFile"] == DBNull.Value ? null : rdr["ImageFile"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Medicine GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return null;
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 MedicineId, MedicineCode, Name, GenericName, Manufacturer, Unit, Description, ImageFile FROM Medicine WHERE MedicineCode=@c";
                cmd.Parameters.AddWithValue("@c", code);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    return new Medicine
                    {
                        MedicineId = Convert.ToInt32(rdr["MedicineId"]),
                        MedicineCode = rdr["MedicineCode"].ToString(),
                        Name = rdr["Name"].ToString(),
                        GenericName = rdr["GenericName"] == DBNull.Value ? null : rdr["GenericName"].ToString(),
                        Manufacturer = rdr["Manufacturer"] == DBNull.Value ? null : rdr["Manufacturer"].ToString(),
                        Unit = rdr["Unit"].ToString(),
                        Description = rdr["Description"] == DBNull.Value ? null : rdr["Description"].ToString(),
                        ImageFile = rdr["ImageFile"] == DBNull.Value ? null : rdr["ImageFile"].ToString()
                    };
                }
            }
        }

        public int Add(Medicine m)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Medicine(MedicineCode, Name, GenericName, Manufacturer, Unit, Description, ImageFile)
VALUES(@code, @name, @gen, @manu, @unit, @desc, @img); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@code", m.MedicineCode);
                cmd.Parameters.AddWithValue("@name", m.Name);
                cmd.Parameters.AddWithValue("@gen", (object)(m.GenericName ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@manu", (object)(m.Manufacturer ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@unit", m.Unit ?? "viên");
                cmd.Parameters.AddWithValue("@desc", (object)(m.Description ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@img", (object)(m.ImageFile ?? (object)DBNull.Value));
                conn.Open();
                var idObj = cmd.ExecuteScalar();
                return Convert.ToInt32(idObj);
            }
        }

        public void Update(Medicine m)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Medicine SET MedicineCode=@code, Name=@name, GenericName=@gen, Manufacturer=@manu, Unit=@unit, Description=@desc, ImageFile=@img
WHERE MedicineId=@id";
                cmd.Parameters.AddWithValue("@code", m.MedicineCode);
                cmd.Parameters.AddWithValue("@name", m.Name);
                cmd.Parameters.AddWithValue("@gen", (object)(m.GenericName ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@manu", (object)(m.Manufacturer ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@unit", m.Unit ?? "viên");
                cmd.Parameters.AddWithValue("@desc", (object)(m.Description ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@img", (object)(m.ImageFile ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@id", m.MedicineId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int medicineId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Medicine WHERE MedicineId=@id";
                cmd.Parameters.AddWithValue("@id", medicineId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
