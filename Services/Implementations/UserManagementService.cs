using System.Collections.Generic;
using HieuThuoc.Data.Repositories;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IAccountRepository _accRepo;
        private readonly IRoleRepository _roleRepo;
        public UserManagementService(IAccountRepository accRepo, IRoleRepository roleRepo)
        {
            _accRepo = accRepo;
            _roleRepo = roleRepo;
        }

        public IEnumerable<Account> GetAll() => _accRepo.GetAll();
        public void Update(Account account) => _accRepo.Update(account);
        public void Delete(int accId) => _accRepo.Delete(accId);
        public IEnumerable<Role> GetRoles() => _roleRepo.GetAll();
    }
}
