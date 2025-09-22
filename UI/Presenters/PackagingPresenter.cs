using System;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class PackagingPresenter
    {
        private readonly IPackagingView _view;
        private readonly IPackagingService _service;
        public PackagingPresenter(IPackagingView view, IPackagingService service)
        {
            _view = view;
            _service = service;
        }

        public void Load()
        {
            var list = _service.GetByMedicine(_view.SelectedMedicineId, _view.SearchKeyword);
            _view.BindPackages(list);
        }

        public void Add()
        {
            try
            {
                var p = new Packaging
                {
                    MedicineId = _view.InputMedicineId,
                    PackagingCode = _view.PackagingCode,
                    Name = _view.PackagingName,
                    PillsPerPack = _view.PillsPerPack,
                    PricePerPack = _view.PricePerPack,
                    PricePerPill = _view.PricePerPill
                };
                var id = _service.Add(p);
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
                var p = new Packaging
                {
                    PackagingId = _view.SelectedPackagingId,
                    MedicineId = _view.InputMedicineId,
                    PackagingCode = _view.PackagingCode,
                    Name = _view.PackagingName,
                    PillsPerPack = _view.PillsPerPack,
                    PricePerPack = _view.PricePerPack,
                    PricePerPill = _view.PricePerPill
                };
                _service.Update(p);
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
                _service.Delete(_view.SelectedPackagingId);
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
