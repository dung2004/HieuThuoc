using System;

namespace HieuThuoc.Domain.Entities
{
    public class Packaging
    {
        public int PackagingId { get; set; }
        public int MedicineId { get; set; }
        public string PackagingCode { get; set; }
        public string Name { get; set; }
        public int PillsPerPack { get; set; }
        public decimal? PricePerPack { get; set; }
        public decimal? PricePerPill { get; set; }
    }
}
