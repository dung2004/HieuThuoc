using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Domain.DTOs
{
    public class AccountDto
    {
        public int AccId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
