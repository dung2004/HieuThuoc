using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Views
{
    public interface IPackagingView
    {
        // Dùng cho filter (cbMedicine + tbSearch)
        int SelectedMedicineId { get; }
        // Dùng khi Add/Edit (??c t? tbMedicineid)
        int InputMedicineId { get; }

        int SelectedPackagingId { get; }
        string PackagingCode { get; }
        string PackagingName { get; }
        int PillsPerPack { get; }
        decimal? PricePerPack { get; }
        decimal? PricePerPill { get; }
        string SearchKeyword { get; }

        void BindPackages(IEnumerable<Packaging> items);
        void ShowMessage(string msg);
        void ShowError(string msg);
    }
}
