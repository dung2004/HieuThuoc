using HieuThuoc.Common;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.UI.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IAuthService _authService;

        public LoginPresenter(ILoginView view, IAuthService authService)
        {
            _view = view;
            _authService = authService;
            _view.SetPresenter(this);
        }

        public void Login()
        {
            var username = _view.Username != null ? _view.Username.Trim() : string.Empty;
            var password = _view.Password != null ? _view.Password : string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                _view.ShowError("Vui lòng nhập username và password.");
                return;
            }

            try
            {
                var account = _authService.Authenticate(username, password);
                if (account == null)
                {
                    _view.ShowError("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản chưa kích hoạt.");
                    return;
                }

                // Set CurrentUser
                CurrentUser.Set(account.AccId, account.RoleId, account.Username, account.FullName);

                _view.OnLoginSucceeded(account);
            }
            catch (Exception ex)
            {
                _view.ShowError("Lỗi khi đăng nhập: " + ex.Message);
            }
        }
    }
}
