using System;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class SupplierPresenter
    {
        private readonly ISupplierView _view;
        private readonly ISupplierService _service;
        public SupplierPresenter(ISupplierView view, ISupplierService service)
        {
            _view = view;
            _service = service;
        }

        public void Load()
        {
            var list = _service.Search(_view.SearchKeyword);
            _view.BindSuppliers(list);
        }

        public void Add()
        {
            try
            {
                var s = new Supplier
                {
                    Name = _view.SupplierName,
                    Phone = _view.SupplierPhone,
                    Address = _view.SupplierAddress
                };
                var id = _service.Add(s);
                _view.ShowMessage($"Add (ID={id}) completed.");
                Load();
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
                var s = new Supplier
                {
                    SupplierId = _view.SelectedSupplierId,
                    Name = _view.SupplierName,
                    Phone = _view.SupplierPhone,
                    Address = _view.SupplierAddress
                };
                _service.Update(s);
                _view.ShowMessage("Update completed.");
                Load();
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
                _service.Delete(_view.SelectedSupplierId);
                _view.ShowMessage("Delete completed.");
                Load();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
