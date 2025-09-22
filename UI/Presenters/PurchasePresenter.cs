using System;
using System.Linq;
using HieuThuoc.Services.DTOs;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class PurchasePresenter
    {
        private readonly IPurchaseView _view;
        private readonly IPurchaseService _service;
        public PurchasePresenter(IPurchaseView view, IPurchaseService service)
        {
            _view = view; _service = service;
        }

        public void LoadLookups()
        {
            _view.BindSuppliers(_service.GetSuppliers());
            _view.BindPackagings(_service.GetPackagings());
        }

        public void LoadGrid()
        {
            _view.BindGrid(_service.LoadGrid());
        }

        public void Save()
        {
            try
            {
                ValidateInputs();
                var req = new PurchaseSaveRequest
                {
                    SupplierId = _view.SupplierId,
                    PackagingId = _view.PackagingId,
                    BatchCode = _view.BatchCode,
                    ExpiryDate = _view.ExpiryDate,
                    ReceivedPacks = _view.ReceivedPacks,
                    PillsPerPack = _view.PillsPerPack,
                    ReceivedLoosePills = _view.ReceivedLoosePills,
                    QuantityPills = _view.QuantityPills,
                    UnitPricePerPill = _view.UnitPricePerPill,
                    TotalAmount = _view.TotalAmount,
                    // dùng giờ local thay vì UTC để không lệch -7 tiếng
                    PurchaseDate = DateTime.Now
                };
                var id = _service.SavePurchaseTransaction(req);
                _view.ShowMessage($"Update Completed (PurchaseId={id}).");
                LoadGrid();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        public void Update()
        {
            try
            {
                ValidateInputs();
                var req = new PurchaseUpdateRequest
                {
                    PurchaseId = _view.PurchaseId,
                    PurchaseDetailId = _view.PurchaseDetailId,
                    SupplierId = _view.SupplierId,
                    PackagingId = _view.PackagingId,
                    BatchCode = _view.BatchCode,
                    ExpiryDate = _view.ExpiryDate,
                    ReceivedPacks = _view.ReceivedPacks,
                    PillsPerPack = _view.PillsPerPack,
                    ReceivedLoosePills = _view.ReceivedLoosePills,
                    QuantityPills = _view.QuantityPills,
                    UnitPricePerPill = _view.UnitPricePerPill,
                    TotalAmount = _view.TotalAmount,
                    PurchaseDate = _view.PurchaseDate
                };
                _service.UpdatePurchase(req);
                _view.ShowMessage("Update Completed");
                LoadGrid();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        private void ValidateInputs()
        {
            if (_view.ReceivedPacks < 0 || _view.PillsPerPack < 0 || _view.ReceivedLoosePills < 0 || _view.QuantityPills < 0 || _view.UnitPricePerPill < 0 || _view.TotalAmount < 0)
                throw new InvalidOperationException("Giá trị không hợp lệ (âm).");

            // ExpiryDate phải lớn hơn ngày hôm nay ít nhất 1 ngày
            if (_view.ExpiryDate.Date <= DateTime.Today)
                throw new InvalidOperationException("ExpiryDate phải lớn hơn ngày hôm nay ít nhất 1 ngày.");
        }
    }
}
