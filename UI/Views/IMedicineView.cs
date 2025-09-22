using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Views
{
    public interface IMedicineView
    {
        void BindMedicine(IEnumerable<Medicine> items);
        // read inputs
        int SelectedMedicineId { get; }
        string MedicineCode { get; }
        string MedicineName { get; }
        string GenericName { get; }
        string Manufacturer { get; }
        string Unit { get; }
        string Description { get; }
        string SearchKeyword { get; }
        string SelectedImageFileName { get; } // tên file ?nh ?ã ch?n

        void ShowMessage(string msg);
        void ShowError(string msg);
    }
}
