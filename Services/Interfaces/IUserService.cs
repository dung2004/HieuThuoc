using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Services.Interfaces
{
    public interface IUserService
    {
        int CreateUser(string username, string fullName, string email, string sdt, string passwordPlain, int roleId, bool isActive, int? createdBy);
        IEnumerable<Role> GetRoles();
    }
}
