using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _cs;
        public SupplierRepository(string connectionString) { _cs = connectionString; }

        public IEnumerable<Supplier> Search(string keyword)
        {
            var list = new List<Supplier>();
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.CommandText = "SELECT SupplierId, Name, Phone, Address FROM Supplier ORDER BY SupplierId";
                }
                else
                {
                    cmd.CommandText = @"SELECT SupplierId, Name, Phone, Address
                                        FROM Supplier
                                        WHERE CAST(SupplierId AS NVARCHAR(50)) LIKE @kw
                                           OR Name LIKE @kw
                                           OR Phone LIKE @kw
                                           OR Address LIKE @kw
                                        ORDER BY SupplierId";
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                }
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Supplier
                        {
                            SupplierId = Convert.ToInt32(rdr["SupplierId"]),
                            Name = rdr["Name"].ToString(),
                            Phone = rdr["Phone"] == DBNull.Value ? null : rdr["Phone"].ToString(),
                            Address = rdr["Address"] == DBNull.Value ? null : rdr["Address"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Supplier GetById(int id)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT SupplierId, Name, Phone, Address FROM Supplier WHERE SupplierId=@id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    return new Supplier
                    {
                        SupplierId = Convert.ToInt32(rdr["SupplierId"]),
                        Name = rdr["Name"].ToString(),
                        Phone = rdr["Phone"] == DBNull.Value ? null : rdr["Phone"].ToString(),
                        Address = rdr["Address"] == DBNull.Value ? null : rdr["Address"].ToString()
                    };
                }
            }
        }

        public int Add(Supplier s)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Supplier(Name, Phone, Address)
VALUES(@n, @p, @a); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@n", s.Name);
                cmd.Parameters.AddWithValue("@p", (object)(s.Phone ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@a", (object)(s.Address ?? (object)DBNull.Value));
                conn.Open();
                var id = cmd.ExecuteScalar();
                return Convert.ToInt32(id);
            }
        }

        public void Update(Supplier s)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Supplier SET Name=@n, Phone=@p, Address=@a WHERE SupplierId=@id";
                cmd.Parameters.AddWithValue("@n", s.Name);
                cmd.Parameters.AddWithValue("@p", (object)(s.Phone ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@a", (object)(s.Address ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@id", s.SupplierId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Supplier WHERE SupplierId=@id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
