using System;
using System.Collections.Generic;
using System.Linq;
using HieuThuoc.Services.DTOs;
using HieuThuoc.Services.Implementations;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class SalePresenter
    {
        private readonly ISaleView _view;
        private readonly ISaleService _service;
        private readonly ISaleLookupService _lookup;
        private readonly List<SaleCartItem> _cart = new List<SaleCartItem>();
        public SalePresenter(ISaleView view, ISaleService service, ISaleLookupService lookup = null)
        {
            _view = view; _service = service; _lookup = lookup;
        }

        public void LoadLookups()
        {
            if (_lookup == null) return;
            // Expose via view? For now, form will pull from lookup service directly
        }

        public void Search(string keyword)
        {
            if (_lookup == null) return;
            _view.BindLoadGrid(_lookup.SearchSales(keyword));
        }

        public void SearchByDate(DateTime date)
        {
            if (_lookup == null) return;
            _view.BindLoadGrid(_lookup.SearchSalesByDate(date));
        }

        public void AddToCart()
        {
            try
            {
                ValidateInputs();
                var totalPills = _view.PillsPerPack * _view.QuantityPacks + _view.QuantityPills;
                var item = new SaleCartItem
                {
                    MedicineId = _view.MedicineId,
                    MedicineName = _view.MedicineName,
                    MedicineCode = _view.MedicineCode,
                    PackagingId = _view.PackagingId,
                    PackagingName = _view.PackagingName,
                    BatchId = _view.BatchId,
                    TotalQuantityPills = _view.TotalQuantityPills,
                    QuantityPacks = _view.QuantityPacks,
                    QuantityPills = _view.QuantityPills,
                    PillsPerPack = _view.PillsPerPack,
                    TotalPills = totalPills,
                    PricePerPill = _view.PricePerPill,
                    LineTotalAmount = _view.PricePerPill * totalPills,
                    CustomerName = _view.CustomerName,
                    SaleDate = DateTime.Now,
                    SaleBy = _view.SaleBy
                };
                _cart.Add(item);
                _view.BindCart(_cart.ToList());
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        public void DeleteCartSelected(int index)
        {
            if (index < 0 || index >= _cart.Count) return;
            _cart.RemoveAt(index);
            _view.BindCart(_cart.ToList());
        }

        public void CancelCart()
        {
            _cart.Clear();
            _view.BindCart(_cart);
        }

        public void SellAll()
        {
            try
            {
                if (_cart.Count == 0) throw new InvalidOperationException("Giỏ hàng trống");
                var req = new SaleCreateRequest
                {
                    CustomerName = _cart.First().CustomerName,
                    SaleBy = _cart.First().SaleBy,
                    TotalAmount = _cart.Sum(x => x.LineTotalAmount),
                    Details = _cart.Select(x => new SaleDetailCreate
                    {
                        MedicineId = x.MedicineId,
                        PackagingId = x.PackagingId,
                        BatchId = x.BatchId,
                        QuantityPacks = x.QuantityPacks,
                        QuantityPills = x.QuantityPills,
                        PillsPerPack = x.PillsPerPack,
                        UnitPrice = x.PricePerPill
                    }).ToList()
                };
                var saleId = _service.CreateSaleWithAllocation(req);
                _view.ShowMessage($"Bán thành công (SaleId={saleId}).");
                CancelCart();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        private void ValidateInputs()
        {
            if (!_view.MedicineId.HasValue || !_view.PackagingId.HasValue || !_view.BatchId.HasValue)
                throw new InvalidOperationException("Thiếu thông tin thuốc/bao bì/lô.");
            if (_view.QuantityPacks < 0 || _view.QuantityPills < 0 || _view.PillsPerPack <= 0 || _view.PricePerPill < 0)
                throw new InvalidOperationException("Giá trị không hợp lệ.");
            var total = _view.PillsPerPack * _view.QuantityPacks + _view.QuantityPills;
            if (total <= 0) throw new InvalidOperationException("Tổng viên phải > 0.");
        }
    }
}
