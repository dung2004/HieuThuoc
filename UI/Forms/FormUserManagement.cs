using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HieuThuoc.UI.Views;
using HieuThuoc.UI.Presenters;
using HieuThuoc.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace HieuThuoc.UI.Forms
{
    public partial class FormUserManagement : Form, IUserManagementView
    {
        private const string ImageFolder = @"D:\\Document\\University\\Subject\\Year4\\Semester1\\C#\\Project\\HieuThuoc\\Resources\\ImageFile\\";
        private const string DefaultImageFile = "null.jpg";
        private UserManagementPresenter _presenter;
        private int _selectedAccId = 0;
        private string _pendingImageFileName = null; // giữ tên file đã chọn, chỉ lưu vào DB khi nhấn Sửa

        public FormUserManagement()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "User Management";

            this.Load += FormUserManagement_Load;
            this.dgvLoadUsers.SelectionChanged += DgvLoadUsers_SelectionChanged;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;
            // XÓA đăng ký trùng sự kiện, Designer đã gán Click cho btnEditImage

            var svc = HieuThuoc.UI.Program.ServiceProvider.GetService<HieuThuoc.Services.Interfaces.IUserManagementService>();
            _presenter = new UserManagementPresenter(this, svc);
        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            _presenter.LoadAll();
        }

        private void LoadTheme()
        {
            LoadThemeRecurse(this);
        }

        private void LoadThemeRecurse(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    Button btn = (Button)ctrl;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                else if (ctrl.HasChildren)
                {
                    LoadThemeRecurse(ctrl);
                }
            }
        }

        private void DgvLoadUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoadUsers.CurrentRow == null) return;
            var row = dgvLoadUsers.CurrentRow.DataBoundItem as Account;
            if (row != null)
            {
                _presenter.OnGridRowSelected(row);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            _presenter.UpdateSelected();
            // Sau khi lưu thành công, nếu _pendingImageFileName null thì giữ ảnh cũ; presenter/service đã lưu ImageFile tương ứng
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedAccId <= 0)
            {
                ShowError("Chưa chọn tài khoản.");
                return;
            }
            var confirm = MessageBox.Show("Xóa tài khoản?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            _presenter.DeleteSelected();
        }

        // IUserManagementView
        public void BindUsers(IEnumerable<Account> accounts)
        {
            dgvLoadUsers.AutoGenerateColumns = true;
            dgvLoadUsers.DataSource = accounts.ToList();
        }

        public void BindRoles(IEnumerable<HieuThuoc.Domain.Entities.Role> roles)
        {
            cbRoleID.DisplayMember = "RoleName";
            cbRoleID.ValueMember = "RoleID";
            cbRoleID.DataSource = roles.ToList();
            cbRoleID.SelectedIndexChanged += (s, e) => { /* no-op: SelectedRoleId reads Value */ };
        }

        public void BindIsActiveOptions()
        {
            cbIsActived.Items.Clear();
            cbIsActived.Items.Add(new { Text = "0", Value = false });
            cbIsActived.Items.Add(new { Text = "1", Value = true });
            cbIsActived.DisplayMember = "Text";
            cbIsActived.ValueMember = "Value";
            cbIsActived.SelectedIndex = 1;
        }

        public void PopulateSelected(Account account)
        {
            _selectedAccId = account.AccId;
            tbUserName.Text = account.Username;
            tbFullName.Text = account.FullName;
            tbEmail.Text = account.Email;
            tbSDT.Text = account.SDT;
            // set dtp from account.CreatedAt (Format before in SQL is only for display; we keep DateTime in entity)
            if (account.CreatedAt.HasValue)
            {
                dtpDateCreated.Value = account.CreatedAt.Value;
            }
            else
            {
                dtpDateCreated.Value = DateTime.Now;
            }
            cbRoleID.SelectedValue = account.RoleID;
            for (int i = 0; i < cbIsActived.Items.Count; i++)
            {
                dynamic item = cbIsActived.Items[i];
                if ((bool)item.Value == account.IsActive)
                {
                    cbIsActived.SelectedIndex = i;
                    break;
                }
            }
            // Khi chọn user khác: reset pending image, hiển thị ảnh theo DB hiện tại
            _pendingImageFileName = account?.ImageFile;
            LoadUserImage(_pendingImageFileName);
        }

        private void LoadUserImage(string fileName)
        {
            if (pbImageUser == null) return;
            try
            {
                string fullPath = null;
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    var maybe = Path.Combine(ImageFolder, fileName);
                    if (File.Exists(maybe)) fullPath = maybe;
                }
                if (fullPath == null)
                {
                    var def = Path.Combine(ImageFolder, DefaultImageFile);
                    if (File.Exists(def)) fullPath = def;
                }

                if (fullPath != null)
                {
                    using (var img = Image.FromFile(fullPath))
                    {
                        pbImageUser.Image = new Bitmap(img);
                    }
                    pbImageUser.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbImageUser.Image = null;
                }
            }
            catch (Exception ex)
            {
                pbImageUser.Image = null;
                System.Diagnostics.Debug.WriteLine("Load user image error: " + ex.Message);
            }
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    dlg.Multiselect = false;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var srcPath = dlg.FileName;
                        var fileName = Path.GetFileName(srcPath);
                        var destPath = Path.Combine(ImageFolder, fileName);
                        if (File.Exists(destPath))
                        {
                            MessageBox.Show("hãy đổi tên ảnh thành tên khác", "Trùng tên ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Directory.CreateDirectory(ImageFolder);
                        File.Copy(srcPath, destPath);

                        // Chỉ set pending file name, chưa lưu DB. Sẽ lưu khi nhấn Sửa.
                        _pendingImageFileName = fileName;
                        LoadUserImage(_pendingImageFileName);
                        ShowMessage("Đã chọn ảnh. Nhấn Sửa để lưu vào tài khoản.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi chọn ảnh: " + ex.Message);
            }
        }

        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public int SelectedAccId => _selectedAccId;
        public string Username => tbUserName.Text?.Trim() ?? string.Empty;
        public string FullName => tbFullName.Text?.Trim() ?? string.Empty;
        public string Email => tbEmail.Text?.Trim() ?? string.Empty;
        public string SDT => tbSDT.Text?.Trim() ?? string.Empty;
        public int SelectedRoleId => cbRoleID.SelectedValue != null ? Convert.ToInt32(cbRoleID.SelectedValue) : 0;
        public bool SelectedIsActive
        {
            get
            {
                if (cbIsActived.SelectedItem == null) return true;
                dynamic item = cbIsActived.SelectedItem;
                return (bool)item.Value;
            }
        }
        public string SelectedImageFileName => _pendingImageFileName;
        public DateTime SelectedCreatedAt => dtpDateCreated.Value;
    }
}
