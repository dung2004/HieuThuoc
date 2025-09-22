using HieuThuoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Data.Repositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Trả về Account nếu tồn tại, ngược lại null.
        /// </summary>
        Account GetByUsername(string username);
        /// <summary>
        /// Lấy tài khoản theo AccId
        /// </summary>
        Account GetById(int accId);
        /// <summary>
        /// Lấy tất cả tài khoản
        /// </summary>
        IEnumerable<Account> GetAll();
        /// <summary>
        /// Cập nhật thông tin tài khoản (không đổi mật khẩu ở đây)
        /// </summary>
        void Update(Account account);
        /// <summary>
        /// Xóa tài khoản theo AccId
        /// </summary>
        void Delete(int accId);
    }
}
