using System;

namespace HieuThuoc.Services.DTOs
{
    public class PurchaseGridRow
    {
        public int PurchaseId { get; set; }
        public int PurchaseDetailId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int PackagingId { get; set; }
        public string PackagingName { get; set; }
        public string MedicineName { get; set; }
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

    public class SimpleLookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PackagingLookup
    {
        public int PackagingId { get; set; }
        public string PackagingName { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int PillsPerPack { get; set; }
        public decimal? PricePerPill { get; set; }
    }
}
