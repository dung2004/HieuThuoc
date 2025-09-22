using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Domain.Entities
{
    public class Account
    {
        public int AccId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string SDT { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public string ImageFile { get; set; } // chỉ lưu tên file  (không kèm path)
        public DateTime? CreatedAt { get; set; }
    }
}
