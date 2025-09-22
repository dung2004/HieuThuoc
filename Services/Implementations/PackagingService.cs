using System;
using System.Collections.Generic;
using HieuThuoc.Data.Repositories;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class PackagingService : IPackagingService
    {
        private readonly IPackagingRepository _repo;
        public PackagingService(IPackagingRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Packaging> GetAll(string keyword = null)
        {
            return _repo.GetAll(keyword);
        }

        public IEnumerable<Packaging> GetByMedicine(int medicineId, string keyword = null)
        {
            if (medicineId <= 0) return _repo.GetAll(keyword);
            return _repo.GetByMedicine(medicineId, keyword);
        }

        public int Add(Packaging p)
        {
            if (p.MedicineId <= 0) throw new ArgumentException("MedicineId required");
            if (string.IsNullOrWhiteSpace(p.PackagingCode)) throw new ArgumentException("PackagingCode required");
            if (p.PillsPerPack <= 0) throw new ArgumentException("PillsPerPack must be > 0");
            var exist = _repo.GetByMedicineAndCode(p.MedicineId, p.PackagingCode);
            if (exist != null) throw new InvalidOperationException("Packaging code already exists for this medicine");
            return _repo.Add(p);
        }

        public void Update(Packaging p)
        {
            if (p.MedicineId <= 0 || p.PackagingId <= 0) throw new ArgumentException("Invalid entity");
            if (string.IsNullOrWhiteSpace(p.PackagingCode)) throw new ArgumentException("PackagingCode required");
            if (p.PillsPerPack <= 0) throw new ArgumentException("PillsPerPack must be > 0");
            var exist = _repo.GetByMedicineAndCode(p.MedicineId, p.PackagingCode);
            if (exist != null && exist.PackagingId != p.PackagingId)
                throw new InvalidOperationException("Packaging code already exists for this medicine");
            _repo.Update(p);
        }

        public void Delete(int packagingId)
        {
            if (packagingId <= 0) throw new ArgumentException("Invalid Id");
            _repo.Delete(packagingId);
        }
    }
}
