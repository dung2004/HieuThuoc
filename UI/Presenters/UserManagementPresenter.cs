using System;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class UserManagementPresenter
    {
        private readonly IUserManagementView _view;
        private readonly IUserManagementService _service;
        public UserManagementPresenter(IUserManagementView view, IUserManagementService service)
        {
            _view = view;
            _service = service;
        }

        public void LoadAll()
        {
            _view.BindIsActiveOptions();
            _view.BindRoles(_service.GetRoles());
            _view.BindUsers(_service.GetAll());
        }

        public void OnGridRowSelected(Account acc)
        {
            _view.PopulateSelected(acc);
        }

        public void UpdateSelected()
        {
            try
            {
                var acc = new Account
                {
                    AccId = _view.SelectedAccId,
                    Username = _view.Username,
                    FullName = _view.FullName,
                    Email = _view.Email,
                    SDT = _view.SDT,
                    RoleID = _view.SelectedRoleId,
                    IsActive = _view.SelectedIsActive,
                    ImageFile = _view.SelectedImageFileName,
                    CreatedAt = _view.SelectedCreatedAt
                };
                if (acc.AccId <= 0)
                {
                    _view.ShowError("Please chose an account.");
                    return;
                }
                _service.Update(acc);
                _view.ShowMessage("Update completed.");
                _view.BindUsers(_service.GetAll());
            }
            catch (Exception ex)
            {
                _view.ShowError("Update error: " + ex.Message);
            }
        }

        public void DeleteSelected()
        {
            try
            {
                var id = _view.SelectedAccId;
                if (id <= 0)
                {
                    _view.ShowError("Please chose an account.");
                    return;
                }
                _service.Delete(id);
                _view.ShowMessage("Delete completed.");
                _view.BindUsers(_service.GetAll());
            }
            catch (Exception ex)
            {
                _view.ShowError("Delete error: " + ex.Message);
            }
        }
    }
}
