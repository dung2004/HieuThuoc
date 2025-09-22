using HieuThuoc.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Trả về AccountDto nếu authenticate thành công, null nếu thất bại.
        /// </summary>
        AccountDto Authenticate(string username, string password);
    }
}
