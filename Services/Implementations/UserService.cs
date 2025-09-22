using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.Data.Repositories;

namespace HieuThuoc.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly IRoleRepository _roleRepo;
        public UserService(string connectionString, IRoleRepository roleRepo)
        {
            _connectionString = connectionString;
            _roleRepo = roleRepo;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _roleRepo.GetAll();
        }

        public int CreateUser(string username, string fullName, string email, string sdt, string passwordPlain, int roleId, bool isActive, int? createdBy)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("username required");
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("fullName required");
            if (string.IsNullOrWhiteSpace(passwordPlain)) throw new ArgumentException("password required");

            var hash = BCrypt.Net.BCrypt.HashPassword(passwordPlain);

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Accounts(Username, PasswordHash, FullName, email, SDT, RoleID, CreatedBy, CreatedAt, IsActive)
VALUES(@u, @h, @f, @e, @s, @r, @cby, GETDATE(), @act);
SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@h", hash);
                cmd.Parameters.AddWithValue("@f", fullName);
                cmd.Parameters.AddWithValue("@e", (object)(string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email));
                cmd.Parameters.AddWithValue("@s", (object)(string.IsNullOrWhiteSpace(sdt) ? DBNull.Value : (object)sdt));
                cmd.Parameters.AddWithValue("@r", roleId);
                cmd.Parameters.AddWithValue("@cby", (object)(createdBy.HasValue ? (object)createdBy.Value : DBNull.Value));
                cmd.Parameters.AddWithValue("@act", isActive);
                conn.Open();
                var idObj = cmd.ExecuteScalar();
                return Convert.ToInt32(idObj);
            }
        }
    }
}
