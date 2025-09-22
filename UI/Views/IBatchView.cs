using System;
using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Views
{
    public interface IBatchView
    {
        // Filters
        int? SelectedMedicineId { get; }
        string SearchKeyword { get; }
        DateTime? FromExpiry { get; }
        DateTime? ToExpiry { get; }

        // Selected row
        int SelectedBatchId { get; }
        int PackagingId { get; }

        // Editable fields
        string BatchCode { get; }
        DateTime ExpiryDate { get; }
        decimal PurchasePrice { get; }
        int? ReceivedPacks { get; }
        int? ReceivedLoosePills { get; }
        DateTime CreatedAt { get; }

        // Binding
        void BindBatches(IEnumerable<Batch> items);
        void BindMedicines(IEnumerable<Medicine> items);

        // Feedback
        void ShowMessage(string msg);
        void ShowError(string msg);
    }
}
