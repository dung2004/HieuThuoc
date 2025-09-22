using System;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class MedicinePresenter
    {
        private readonly IMedicineView _view;
        private readonly IMedicineService _service;
        public MedicinePresenter(IMedicineView view, IMedicineService service)
        {
            _view = view;
            _service = service;
        }

        public void Load(string keyword = null)
        {
            var items = _service.Search(keyword);
            _view.BindMedicine(items);
        }

        public void Add()
        {
            try
            {
                var m = new Medicine
                {
                    MedicineCode = _view.MedicineCode,
                    Name = _view.MedicineName,
                    GenericName = _view.GenericName,
                    Manufacturer = _view.Manufacturer,
                    Unit = _view.Unit,
                    Description = _view.Description,
                    ImageFile = _view.SelectedImageFileName
                };
                var id = _service.Add(m);
                _view.ShowMessage($"Add (ID={id}) completed.");
                Load(_view.SearchKeyword);
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
                var m = new Medicine
                {
                    MedicineId = _view.SelectedMedicineId,
                    MedicineCode = _view.MedicineCode,
                    Name = _view.MedicineName,
                    GenericName = _view.GenericName,
                    Manufacturer = _view.Manufacturer,
                    Unit = _view.Unit,
                    Description = _view.Description,
                    ImageFile = _view.SelectedImageFileName
                };
                _service.Update(m);
                _view.ShowMessage("Update completed.");
                Load(_view.SearchKeyword);
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
                _service.Delete(_view.SelectedMedicineId);
                _view.ShowMessage("Delete completed.");
                Load(_view.SearchKeyword);
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
