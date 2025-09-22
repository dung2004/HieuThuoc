using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;
        public RoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Role> GetAll()
        {
            var list = new List<Role>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT RoleID, RoleName, RoleDescription FROM Roles ORDER BY RoleID";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Role
                        {
                            RoleID = rdr["RoleID"] != DBNull.Value ? Convert.ToInt32(rdr["RoleID"]) : 0,
                            RoleName = rdr["RoleName"].ToString(),
                            RoleDescription = rdr["RoleDescription"] == DBNull.Value ? null : rdr["RoleDescription"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Role GetByName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return null;
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT RoleID, RoleName, RoleDescription FROM Roles WHERE RoleName = @name";
                cmd.Parameters.AddWithValue("@name", roleName);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    return new Role
                    {
                        RoleID = rdr["RoleID"] != DBNull.Value ? Convert.ToInt32(rdr["RoleID"]) : 0,
                        RoleName = rdr["RoleName"].ToString(),
                        RoleDescription = rdr["RoleDescription"] == DBNull.Value ? null : rdr["RoleDescription"].ToString()
                    };
                }
            }
        }
    }
}
