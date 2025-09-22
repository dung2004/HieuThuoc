using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.Common
{
    public static class CurrentUser
    {
        public static int AccId { get; private set; } = 0;
        public static int RoleId { get; private set; } = 0;
        public static string Username { get; private set; } = string.Empty;
        public static string FullName { get; private set; } = string.Empty;
        public static bool IsAuthenticated { get; private set; } = false;

        public static void Set(int accId, int roleId, string username, string fullName)
        {
            AccId = accId;
            RoleId = roleId;
            Username = username ?? string.Empty;
            FullName = fullName ?? string.Empty;
            IsAuthenticated = true;
        }

        public static void Clear()
        {
            AccId = 0;
            RoleId = 0;
            Username = string.Empty;
            FullName = string.Empty;
            IsAuthenticated = false;
        }
    }
}
