using System;
using System.Collections.Generic;
using HieuThuoc.Data.Repositories;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repo;
        public MedicineService(IMedicineRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Medicine> Search(string keyword) => _repo.GetAll(keyword);

        public Medicine GetByCode(string code) => _repo.GetByCode(code);

        public int Add(Medicine m)
        {
            if (string.IsNullOrWhiteSpace(m.Name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(m.MedicineCode)) throw new ArgumentException("MedicineCode is required");
            if (_repo.GetByCode(m.MedicineCode) != null) throw new InvalidOperationException("MedicineCode already exists");
            return _repo.Add(m);
        }

        public void Update(Medicine m)
        {
            if (string.IsNullOrWhiteSpace(m.Name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(m.MedicineCode)) throw new ArgumentException("MedicineCode is required");
            var exist = _repo.GetByCode(m.MedicineCode);
            if (exist != null && exist.MedicineId != m.MedicineId) throw new InvalidOperationException("MedicineCode already exists");
            _repo.Update(m);
        }

        public void Delete(int id) => _repo.Delete(id);
    }
}
