using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Services.Interfaces
{
    public interface IUserManagementService
    {
        IEnumerable<Account> GetAll();
        void Update(Account account);
        void Delete(int accId);
        IEnumerable<Role> GetRoles();
    }
}
