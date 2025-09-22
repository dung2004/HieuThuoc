using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class BatchPresenter
    {
        private readonly IBatchView _view;
        private readonly IBatchService _service;
        private readonly IMedicineService _medicineService;
        public BatchPresenter(IBatchView view, IBatchService service, IMedicineService medicineService)
        {
            _view = view;
            _service = service;
            _medicineService = medicineService;
        }

        public void LoadFilters()
        {
            var meds = _medicineService.Search(null);
            _view.BindMedicines(meds);
        }

        public void Search()
        {
            var list = _service.SearchBatches(_view.SelectedMedicineId, _view.FromExpiry, _view.ToExpiry, _view.SearchKeyword);
            _view.BindBatches(list);
        }

        public void ReloadAll()
        {
            var list = _service.SearchBatches(null, null, null, null);
            _view.BindBatches(list);
        }

        public void Update()
        {
            try
            {
                var b = new Batch
                {
                    BatchId = _view.SelectedBatchId,
                    PackagingId = _view.PackagingId,
                    BatchCode = _view.BatchCode,
                    ExpiryDate = _view.ExpiryDate,
                    PurchasePrice = _view.PurchasePrice,
                    ReceivedPacks = _view.ReceivedPacks,
                    ReceivedLoosePills = _view.ReceivedLoosePills,
                    CreatedAt = _view.CreatedAt
                };
                if (b.BatchId <= 0) { _view.ShowError("Chưa chọn lô."); return; }
                if (b.PurchasePrice < 0 || (b.ReceivedPacks ?? 0) < 0 || (b.ReceivedLoosePills ?? 0) < 0)
                {
                    _view.ShowError("Invalid value (negative).");
                    return;
                }
                _service.UpdateBatch(b);
                _view.ShowMessage("Update completed.");
                Search();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                _service.DeleteBatch(_view.SelectedBatchId);
                _view.ShowMessage("Delete completed.");
                Search();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
