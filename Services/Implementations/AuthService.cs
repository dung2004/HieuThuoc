using HieuThuoc.Data.Repositories;
using HieuThuoc.Domain.DTOs;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepo;

        public AuthService(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public AccountDto Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;

            Account acc = null;
            try
            {
                acc = _accountRepo.GetByUsername(username);
            }
            catch
            {
                // Có thể log ở đây
                return null;
            }

            if (acc == null) return null;
            if (!acc.IsActive) return null;

            bool ok = false;
            try
            {
                // BCrypt.Net-Next: BCrypt.Net.BCrypt.Verify
                ok = BCrypt.Net.BCrypt.Verify(password, acc.PasswordHash);
            }
            catch
            {
                // Nếu verify lỗi (hash không hợp lệ) => fail
                return null;
            }

            if (!ok) return null;

            var dto = new AccountDto
            {
                AccId = acc.AccId,
                RoleId = acc.RoleID,
                Username = acc.Username ?? string.Empty,
                FullName = acc.FullName ?? string.Empty
            };

            return dto;
        }
    }
}
