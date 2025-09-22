using System;
using System.Collections.Generic;
using HieuThuoc.Services.DTOs;

namespace HieuThuoc.Services.Interfaces
{
    public interface ISaleLookupService
    {
        IEnumerable<SimpleLookup> GetMedicinesByName();
        IEnumerable<SimpleLookup> GetMedicinesByCode();
        IEnumerable<PackagingLookup> GetPackagingsByMedicine(int medicineId);
        IEnumerable<BatchLookup> GetBatchesByPackaging(int packagingId);
        IEnumerable<SaleGridRow> SearchSales(string keyword);
        IEnumerable<SaleGridRow> SearchSalesByDate(DateTime date);
    }

    public class BatchLookup
    {
        public int BatchId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int QuantityPills { get; set; }
    }
}
