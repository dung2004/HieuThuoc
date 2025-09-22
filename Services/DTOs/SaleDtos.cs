using System;

namespace HieuThuoc.Services.DTOs
{
    public class SaleGridRow
    {
        public int SaleId { get; set; }
        public int SaleDetailId { get; set; }
        public int? MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCode { get; set; }
        public string CustomerName { get; set; }
        public int? PackagingId { get; set; }
        public string PackagingName { get; set; }
        public int? BatchId { get; set; }
        public int TotalQuantityPills { get; set; } // from Batch at sale time 
        public int QuantityPacks { get; set; }
        public int QuantityPills { get; set; }
        public int PillsPerPack { get; set; }
        public int TotalPills { get; set; }
        public decimal PricePerPill { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public int? SaleBy { get; set; }
    }

    public class SaleCartItem
    {
        public int? MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCode { get; set; }
        public int? PackagingId { get; set; }
        public string PackagingName { get; set; }
        public int? BatchId { get; set; }
        public int TotalQuantityPills { get; set; }
        public int QuantityPacks { get; set; }
        public int QuantityPills { get; set; }
        public int PillsPerPack { get; set; }
        public int TotalPills { get; set; }
        public decimal PricePerPill { get; set; }
        public decimal LineTotalAmount { get; set; }
        public string CustomerName { get; set; }
        public DateTime SaleDate { get; set; }
        public int? SaleBy { get; set; }
    }
}
