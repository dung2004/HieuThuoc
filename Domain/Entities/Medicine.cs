using System;

namespace HieuThuoc.Domain.Entities
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineCode { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public string Manufacturer { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; } // tên file ảnh thuốc (không kèm path)
    }
}
