using System;
using System.Collections.Generic;
using HieuThuoc.Services.DTOs;

namespace HieuThuoc.UI.Views
{
    public interface ISaleView
    {
        // Load grid and cart
        void BindLoadGrid(IEnumerable<SaleGridRow> items);
        void BindCart(IEnumerable<SaleCartItem> items);

        // Inputs from controls
        int? MedicineId { get; }
        string MedicineName { get; }
        string MedicineCode { get; }
        string CustomerName { get; }
        int? PackagingId { get; }
        string PackagingName { get; }
        int? BatchId { get; }
        int TotalQuantityPills { get; }
        int QuantityPacks { get; }
        int QuantityPills { get; }
        int PillsPerPack { get; }
        int TotalPills { get; }
        decimal PricePerPill { get; }
        decimal TotalAmount { get; }
        DateTime SaleDate { get; }
        int? SaleBy { get; }
        string SearchKeyword { get; }
        DateTime? SearchDate { get; }

        // Feedback
        void ShowMessage(string msg);
        void ShowError(string msg);
    }
}
