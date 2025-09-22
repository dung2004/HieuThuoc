using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HieuThuoc.UI.Views;
using HieuThuoc.UI.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace HieuThuoc.UI.Forms
{
    public partial class FormCreateUser : Form, ICreateUserView
    {
        private CreateUserPresenter _presenter;
        public FormCreateUser()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Create User";

            this.Load += FormCreateUser_Load;
            this.btnCreateUser.Click += BtnCreateUser_Click;

            tbPassword.UseSystemPasswordChar = true;
            tbConfirmPassword.UseSystemPasswordChar = true;

            var userService = HieuThuoc.UI.Program.ServiceProvider.GetService<HieuThuoc.Services.Interfaces.IUserService>();
            _presenter = new CreateUserPresenter(this, userService);
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

        private void FormCreateUser_Load(object sender, EventArgs e)
        {
            _presenter.Init();
        }

        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            _presenter.Create();
        }

        // ICreateUserView implementation
        public string Username => tbUsername?.Text?.Trim() ?? string.Empty;
        public string FullName => tbFullName?.Text?.Trim() ?? string.Empty;
        public string Email => tbEmail?.Text?.Trim() ?? string.Empty;
        public string SDT => tbSDT?.Text?.Trim() ?? string.Empty;
        public string Password => tbPassword?.Text ?? string.Empty;
        public string ConfirmPassword => tbConfirmPassword?.Text ?? string.Empty;
        public int SelectedRoleId { get; private set; }
        public bool SelectedIsActive { get; private set; }

        public void BindRoles(IEnumerable<HieuThuoc.Domain.Entities.Role> roles)
        {
            cbRole.DisplayMember = "RoleName";
            cbRole.ValueMember = "RoleID";
            cbRole.DataSource = roles.ToList();
            cbRole.SelectedIndexChanged += (s, e) =>
            {
                if (cbRole.SelectedValue is int rid) SelectedRoleId = rid;
                else SelectedRoleId = Convert.ToInt32(cbRole.SelectedValue);
            };
            if (cbRole.SelectedValue != null)
            {
                SelectedRoleId = Convert.ToInt32(cbRole.SelectedValue);
            }
        }

        public void BindIsActiveOptions()
        {
            cbIsActived.Items.Clear();
            cbIsActived.Items.Add(new { Text = "0", Value = false });
            cbIsActived.Items.Add(new { Text = "1", Value = true });
            cbIsActived.DisplayMember = "Text";
            cbIsActived.ValueMember = "Value";
            cbIsActived.SelectedIndexChanged += (s, e) =>
            {
                if (cbIsActived.SelectedItem != null)
                {
                    dynamic item = cbIsActived.SelectedItem;
                    SelectedIsActive = item.Value;
                }
            };
            cbIsActived.SelectedIndex = 1; // mặc định Active
            SelectedIsActive = true;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseView()
        {
            this.Close();
        }

        private void cbShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (tbPassword == null) return;
            tbPassword.UseSystemPasswordChar = !cbShowPassword.Checked;
        }

        private void cbShowConfirmPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (tbConfirmPassword == null) return;
            tbConfirmPassword.UseSystemPasswordChar = !cbShowConfirmPassword.Checked;
        }
    }
}
