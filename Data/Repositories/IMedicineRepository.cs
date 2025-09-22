using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Data.Repositories
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetAll(string search = null);
        Medicine GetByCode(string code);
        int Add(Medicine m);
        void Update(Medicine m);
        void Delete(int medicineId);
    }
}
