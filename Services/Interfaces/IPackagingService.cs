using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Services.Interfaces
{
    public interface IPackagingService
    {
        IEnumerable<Packaging> GetAll(string keyword = null);
        IEnumerable<Packaging> GetByMedicine(int medicineId, string keyword = null);
        int Add(Packaging p);
        void Update(Packaging p);
        void Delete(int packagingId);
    }
}
