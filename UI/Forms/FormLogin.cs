using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HieuThuoc.UI.Views;
using HieuThuoc.UI.Presenters;
using HieuThuoc.Domain.DTOs;
using HieuThuoc.Common;

namespace HieuThuoc.UI.Forms
{
    public partial class FormLogin : Form, ILoginView
    {
        private LoginPresenter _presenter;
        public FormLogin()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Login";
            tbUsername.Text = "Dung";
            tbPassword.Text = "123";
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        // ILoginView implementation
        public string Username
        {
            get
            {
                if (tbUsername == null) return string.Empty;
                return tbUsername.Text ?? string.Empty;
                //return "Phat" ?? string.Empty;
            }
        }

        public string Password
        {
            get
            {
                if (tbPassword == null) return string.Empty;
                //return "123" ?? string.Empty;
                return tbPassword.Text ?? string.Empty;
            }
        }

        public void SetPresenter(LoginPresenter presenter)
        {
            _presenter = presenter;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OnLoginSucceeded(AccountDto account)
        {
            // disable login controls
            if (btnLogin != null) btnLogin.Enabled = false;
            if (tbUsername != null) tbUsername.Enabled = false;
            if (tbPassword != null) tbPassword.Enabled = false;

            ShowMessage("Đăng nhập thành công. Xin chào " + account.FullName + " (" + account.Username + ")");

            foreach (Form f in Application.OpenForms)
            {
                var main = f as FormMainMenu;
                if (main != null)
                {
                    // Cập nhật nút chỉ cho admin thấy Create User
                    main.UpdateLoginButtonState();

                    // Áp role mask theo Role của user
                    main.ApplyRoleMask(CurrentUser.RoleId);
                    break;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_presenter != null)
            {
                _presenter.Login();
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (tbPassword == null) return;
            // Khi checkbox được tick => hiển thị; bỏ tick => che
            tbPassword.UseSystemPasswordChar = !cbShowPassword.Checked;
        }
    }
}
