using System;
using System.Collections.Generic;
using HieuThuoc.Data.Repositories;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;

namespace HieuThuoc.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;
        public SupplierService(ISupplierRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Supplier> Search(string keyword)
        {
            return _repo.Search(keyword);
        }

        public Supplier GetById(int id) => _repo.GetById(id);

        public int Add(Supplier s)
        {
            if (string.IsNullOrWhiteSpace(s.Name)) throw new ArgumentException("Name is required");
            return _repo.Add(s);
        }

        public void Update(Supplier s)
        {
            if (s.SupplierId <= 0) throw new ArgumentException("Invalid SupplierId");
            if (string.IsNullOrWhiteSpace(s.Name)) throw new ArgumentException("Name is required");
            _repo.Update(s);
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid SupplierId");
            _repo.Delete(id);
        }
    }
}
