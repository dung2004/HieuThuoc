using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role GetByName(string roleName);
    }
}
