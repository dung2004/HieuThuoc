using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Services.Interfaces
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> Search(string keyword);
        Medicine GetByCode(string code);
        int Add(Medicine m);
        void Update(Medicine m);
        void Delete(int id);
    }
}
