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
using Microsoft.Extensions.DependencyInjection;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Forms
{
    public partial class FormMedicineManagement : Form, IMedicineView
    {
        private const string ImageFolder = @"D:\\Document\\University\\Subject\\Year4\\Semester1\\C#\\Project\\HieuThuoc\\Resources\\Medicine\\";
        private const string DefaultImageFile = "null.jpg";
        private MedicinePresenter _presenter;
        private int _selectedId = 0;
        private string _pendingImageFileName = null; // giữ tên ảnh đã chọn, lưu khi nhấn Edit
        public FormMedicineManagement()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Medicine Management";

            this.Load += FormMedicineManagement_Load;
            this.dgvLoadMedicine.SelectionChanged += DgvLoadMedicine_SelectionChanged;
            this.btnEditImage.Click += BtnEditImage_Click;

            var svc = HieuThuoc.UI.Program.ServiceProvider.GetService<HieuThuoc.Services.Interfaces.IMedicineService>();
            _presenter = new MedicinePresenter(this, svc);
        }

        private void FormMedicineManagement_Load(object sender, EventArgs e)
        {
            _presenter.Load(null);
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
        private void DgvLoadMedicine_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvLoadMedicine.CurrentRow?.DataBoundItem as Medicine;
            if (row != null)
            {
                _selectedId = row.MedicineId;
                tbCode.Text = row.MedicineCode;
                tbName.Text = row.Name;
                tbGeneric.Text = row.GenericName;
                tbManufacturer.Text = row.Manufacturer;
                tbUnit.Text = row.Unit;
                tbDescription.Text = row.Description;
                _pendingImageFileName = row.ImageFile;
                LoadMedicineImage(_pendingImageFileName);
            }
        }

        private void LoadMedicineImage(string fileName)
        {
            if (pbImageMedi == null) return;
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
                        pbImageMedi.Image = new Bitmap(img);
                    }
                    pbImageMedi.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbImageMedi.Image = null;
                }
            }
            catch (Exception ex)
            {
                pbImageMedi.Image = null;
                System.Diagnostics.Debug.WriteLine("Load medicine image error: " + ex.Message);
            }
        }

        private void BtnEditImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    dlg.Multiselect = false;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var src = dlg.FileName;
                        var fileName = Path.GetFileName(src);
                        var dest = Path.Combine(ImageFolder, fileName);
                        if (File.Exists(dest))
                        {
                            MessageBox.Show("hãy đổi tên ảnh thành tên khác", "Trùng tên ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Directory.CreateDirectory(ImageFolder);
                        File.Copy(src, dest);
                        _pendingImageFileName = fileName;
                        LoadMedicineImage(_pendingImageFileName);
                        ShowMessage("Đã chọn ảnh. Nhấn Edit để lưu vào thuốc.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi chọn ảnh: " + ex.Message);
            }
        }

        // IMedicineView
        public void BindMedicine(IEnumerable<Medicine> items)
        {
            dgvLoadMedicine.AutoGenerateColumns = true;
            dgvLoadMedicine.DataSource = items.ToList();
        }

        public int SelectedMedicineId => _selectedId;
        public string MedicineCode => tbCode.Text?.Trim() ?? string.Empty;
        public string MedicineName => tbName.Text?.Trim() ?? string.Empty;
        public string GenericName => tbGeneric.Text?.Trim() ?? string.Empty;
        public string Manufacturer => tbManufacturer.Text?.Trim() ?? string.Empty;
        public string Unit => tbUnit.Text?.Trim() ?? string.Empty;
        public string Description => tbDescription.Text?.Trim() ?? string.Empty;
        public string SearchKeyword => tbSearch.Text?.Trim() ?? string.Empty;
        public string SelectedImageFileName => _pendingImageFileName;

        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                ShowError("Chưa chọn thuốc.");
                return;
            }
            _presenter.Update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Load(tbSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                ShowError("Chưa chọn thuốc.");
                return;
            }
            var confirm = MessageBox.Show("Xóa thuốc đã chọn?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            _presenter.Delete();
        }
    }
}
