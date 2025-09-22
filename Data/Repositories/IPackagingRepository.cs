using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public interface IPackagingRepository
    {
        IEnumerable<Packaging> GetAll(string keyword = null);
        IEnumerable<Packaging> GetByMedicine(int medicineId, string keyword = null);
        Packaging GetByMedicineAndCode(int medicineId, string code);
        int Add(Packaging p);
        void Update(Packaging p);
        void Delete(int packagingId);
    }
}
