using System;

namespace HieuThuoc.Domain.Entities
{
    public class Batch
    {
        public int BatchId { get; set; }
        public int PackagingId { get; set; }
        public int MedicineId { get; set; }
        public string BatchCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int QuantityPills { get; set; }
        public decimal PurchasePrice { get; set; }
        public int? ReceivedPacks { get; set; }
        public int? ReceivedLoosePills { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
