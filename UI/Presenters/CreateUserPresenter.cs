using System;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;
using HieuThuoc.Common;

namespace HieuThuoc.UI.Presenters
{
    public class CreateUserPresenter
    {
        private readonly ICreateUserView _view;
        private readonly IUserService _userService;
        public CreateUserPresenter(ICreateUserView view, IUserService userService)
        {
            _view = view;
            _userService = userService;
        }

        public void Init()
        {
            _view.BindIsActiveOptions();
            var roles = _userService.GetRoles();
            _view.BindRoles(roles);
        }

        public void Create()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.Username) || string.IsNullOrWhiteSpace(_view.Password))
                {
                    _view.ShowError("Username and Password is required.");
                    return;
                }
                if (_view.Password != _view.ConfirmPassword)
                {
                    _view.ShowError("Confirm Password not match.");
                    return;
                }
                var createdBy = CurrentUser.IsAuthenticated ? (int?)CurrentUser.AccId : null;
                var newId = _userService.CreateUser(_view.Username, _view.FullName, _view.Email, _view.SDT, _view.Password, _view.SelectedRoleId, _view.SelectedIsActive, createdBy);
                _view.ShowMessage($"Create user (ID={newId}) completed.");
                _view.CloseView();
            }
            catch (Exception ex)
            {
                _view.ShowError("Create user error: " + ex.Message);
            }
        }
    }
}
