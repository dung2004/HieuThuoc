using System;
using System.Collections.Generic;
using HieuThuoc.Services.DTOs;

namespace HieuThuoc.Services.Interfaces
{
    public interface IPurchaseService
    {
        IEnumerable<PurchaseGridRow> LoadGrid();
        IEnumerable<SimpleLookup> GetSuppliers();
        IEnumerable<PackagingLookup> GetPackagings();

        int SavePurchaseTransaction(PurchaseSaveRequest req);
        void UpdatePurchase(PurchaseUpdateRequest req);
    }

    public class PurchaseSaveRequest
    {
        public int SupplierId { get; set; }
        public int PackagingId { get; set; }
        public string BatchCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ReceivedPacks { get; set; }
        public int PillsPerPack { get; set; }
        public int ReceivedLoosePills { get; set; }
        public int QuantityPills { get; set; }
        public decimal UnitPricePerPill { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class PurchaseUpdateRequest
    {
        public int PurchaseId { get; set; }
        public int PurchaseDetailId { get; set; }
        public int SupplierId { get; set; }
        public int PackagingId { get; set; }
        public string BatchCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ReceivedPacks { get; set; }
        public int PillsPerPack { get; set; }
        public int ReceivedLoosePills { get; set; }
        public int QuantityPills { get; set; }
        public decimal UnitPricePerPill { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
