using System;
using System.Collections.Generic;
using HieuThuoc.Services.DTOs;

namespace HieuThuoc.UI.Views
{
    public interface IPurchaseView
    {
        // IDs
        int PurchaseId { get; }
        int PurchaseDetailId { get; }
        int SupplierId { get; }
        string SupplierName { get; }
        int PackagingId { get; }
        string PackagingName { get; }
        string MedicineName { get; }

        // Batch fields
        string BatchCode { get; }
        DateTime ExpiryDate { get; }
        int ReceivedPacks { get; }
        int PillsPerPack { get; }
        int ReceivedLoosePills { get; }
        int QuantityPills { get; }
        decimal UnitPricePerPill { get; }
        decimal TotalAmount { get; }
        DateTime PurchaseDate { get; }

        // Binding
        void BindGrid(IEnumerable<PurchaseGridRow> rows);
        void BindSuppliers(IEnumerable<SimpleLookup> suppliers);
        void BindPackagings(IEnumerable<PackagingLookup> packagings);

        // Feedback
        void ShowMessage(string msg);
        void ShowError(string msg);
    }
}
