using HieuThuoc.Domain.DTOs;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;
using HieuThuoc.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuThuoc.UI.Views
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        void ShowError(string message);
        void ShowMessage(string message);
        void SetPresenter(HieuThuoc.UI.Presenters.LoginPresenter presenter);
        void OnLoginSucceeded(AccountDto account);
    }
}
