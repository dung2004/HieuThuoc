using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> Search(string keyword);
        Supplier GetById(int id);
        int Add(Supplier s);
        void Update(Supplier s);
        void Delete(int id);
    }
}
