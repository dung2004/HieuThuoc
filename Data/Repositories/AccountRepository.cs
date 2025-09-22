using HieuThuoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public Account GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return null;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT AccId, Username, PasswordHash, FullName, Email, SDT, RoleID, IsActive, ImageFile, Format(CreatedAt, 'dd/MM/yyyy') CreatedAt
                                    FROM Accounts
                                    WHERE Username = @username";
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read())
                    {
                        return null;
                    }

                    return Map(rdr);
                }
            }
        }

        public Account GetById(int accId)
        {
            if (accId <= 0) return null;
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT AccId, Username, PasswordHash, FullName, Email, SDT, RoleID, IsActive, ImageFile, Format(CreatedAt, 'dd/MM/yyyy')  CreatedAt
                                    FROM Accounts WHERE AccId = @id";
                cmd.Parameters.AddWithValue("@id", accId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    return Map(rdr);
                }
            }
        }

        public IEnumerable<Account> GetAll()
        {
            var list = new List<Account>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT AccId, Username, PasswordHash, FullName, Email, SDT, RoleID, IsActive, ImageFile, Format(CreatedAt, 'dd/MM/yyyy')  CreatedAt FROM Accounts ORDER BY AccId";
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

        public void Update(Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Accounts
                                    SET Username=@u, FullName=@f, Email=@e, SDT=@s, RoleID=@r, IsActive=@a, ImageFile=@img, CreatedAt=@created
                                    WHERE AccId=@id";
                cmd.Parameters.AddWithValue("@u", account.Username ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@f", account.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)(account.Email ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@s", (object)(account.SDT ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@r", account.RoleID);
                cmd.Parameters.AddWithValue("@a", account.IsActive);
                cmd.Parameters.AddWithValue("@img", (object)(account.ImageFile ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@created", (object)(account.CreatedAt ?? (object)DBNull.Value));
                cmd.Parameters.AddWithValue("@id", account.AccId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int accId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Accounts WHERE AccId=@id";
                cmd.Parameters.AddWithValue("@id", accId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private Account Map(System.Data.IDataRecord rdr)
        {
            var acc = new Account();
            acc.AccId = rdr["AccId"] != DBNull.Value ? (int)rdr["AccId"] : 0;
            acc.Username = rdr["Username"] != DBNull.Value ? rdr["Username"].ToString() : string.Empty;
            acc.PasswordHash = rdr["PasswordHash"] != DBNull.Value ? rdr["PasswordHash"].ToString() : string.Empty;
            acc.FullName = rdr["FullName"] != DBNull.Value ? rdr["FullName"].ToString() : string.Empty;
            acc.Email = rdr["Email"] != DBNull.Value ? rdr["Email"].ToString() : null;
            acc.SDT = rdr["SDT"] != DBNull.Value ? rdr["SDT"].ToString() : null;
            acc.RoleID = rdr["RoleID"] != DBNull.Value ? (int)rdr["RoleID"] : 0;
            acc.IsActive = rdr["IsActive"] != DBNull.Value ? (bool)rdr["IsActive"] : false;
            acc.ImageFile = rdr["ImageFile"] != DBNull.Value ? rdr["ImageFile"].ToString() : null;
            try { acc.CreatedAt = rdr["CreatedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(rdr["CreatedAt"]) : null; } catch { }
            return acc;
        }
    }
}
