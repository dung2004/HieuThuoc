using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Views
{
    public interface ISupplierView
    {
        int SelectedSupplierId { get; }
        string SupplierName { get; }
        string SupplierPhone { get; }
        string SupplierAddress { get; }
        string SearchKeyword { get; }

        void BindSuppliers(IEnumerable<Supplier> suppliers);
        void ShowMessage(string msg);
        void ShowError(string msg);
    }
}
