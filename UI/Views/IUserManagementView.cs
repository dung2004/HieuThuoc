using System.Collections.Generic;
using HieuThuoc.Domain.Entities;
using System;

namespace HieuThuoc.UI.Views
{
    public interface IUserManagementView
    {
        void BindUsers(IEnumerable<Account> accounts);
        void BindRoles(IEnumerable<Role> roles);
        void BindIsActiveOptions();
        void PopulateSelected(Account account);
        void ShowMessage(string msg);
        void ShowError(string msg);

        // Read user-edited fields
        int SelectedAccId { get; }
        string Username { get; }
        string FullName { get; }
        string Email { get; }
        string SDT { get; }
        int SelectedRoleId { get; }
        bool SelectedIsActive { get; }
        string SelectedImageFileName { get; } // tên file ảnh hiện hành
        DateTime SelectedCreatedAt { get; } // đọc từ dtpDateCreated
    }
}
