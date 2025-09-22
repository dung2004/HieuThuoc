using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Views
{
    public interface ICreateUserView
    {
        string Username { get; }
        string FullName { get; }
        string Email { get; }
        string SDT { get; }
        string Password { get; }
        string ConfirmPassword { get; }
        int SelectedRoleId { get; }
        bool SelectedIsActive { get; }

        void BindRoles(IEnumerable<Role> roles);
        void BindIsActiveOptions();
        void ShowMessage(string message);
        void ShowError(string message);
        void CloseView();
    }
}
