using HieuThuoc.Domain.Entities;
using HieuThuoc.UI.Presenters;
using HieuThuoc.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HieuThuoc.UI.Forms
{
    public partial class FormPackagingManagement : Form, IPackagingView
    {
        private PackagingPresenter _presenter;
        private int _selectedPackagingId = 0;
        private int _selectedMedicineId = 0;
        private bool _loadingMedicines = false;
        public FormPackagingManagement()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Packaging Management";

            var svc = HieuThuoc.UI.Program.ServiceProvider.GetService<HieuThuoc.Services.Interfaces.IPackagingService>();
            _presenter = new PackagingPresenter(this, svc);
            // Lưu ý: các sự kiện đã được gắn trong Designer (InitializeComponent)
            // Tránh gắn trùng sự kiện tại đây để không bị chạy 2 lần.
        }

        private void FormPackagingManagement_Load(object sender, EventArgs e)
        {
            LoadMedicinesIntoCombo();
            _presenter.Load();
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

        private void LoadMedicinesIntoCombo()
        {
            _loadingMedicines = true;
            try
            {
                var medSvc = HieuThuoc.UI.Program.ServiceProvider.GetService<HieuThuoc.Services.Interfaces.IMedicineService>();
                var meds = medSvc.Search(null).ToList();
                var comboItems = meds.Select(m => new { m.MedicineId, Display = string.Format("{0} ({1})", m.Name, m.MedicineCode) }).ToList();
                // prepend (none)
                comboItems.Insert(0, new { MedicineId = 0, Display = "(All Package)" });
                cbMedicine.DisplayMember = "Display";
                cbMedicine.ValueMember = "MedicineId";
                cbMedicine.DataSource = comboItems;

                if (_selectedMedicineId > 0 && comboItems.Any(x => x.MedicineId == _selectedMedicineId))
                {
                    cbMedicine.SelectedValue = _selectedMedicineId;
                }
                else
                {
                    _selectedMedicineId = 0;
                    cbMedicine.SelectedValue = 0; // default to (none)
                }
            }
            finally
            {
                _loadingMedicines = false;
            }
        }

        private void CbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingMedicines) return;
            if (cbMedicine.SelectedValue == null) return;

            try
            {
                _selectedMedicineId = Convert.ToInt32(cbMedicine.SelectedValue);
                _presenter.Load();
            }
            catch
            {
                int tmp;
                if (int.TryParse(cbMedicine.SelectedValue.ToString(), out tmp))
                {
                    _selectedMedicineId = tmp;
                    _presenter.Load();
                }
            }
        }

        private void DgvLoadMedicine_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoadPackage.CurrentRow == null || dgvLoadPackage.CurrentRow.Index < 0)
                return;
            var row = dgvLoadPackage.CurrentRow?.DataBoundItem as Packaging;
            if (row == null) return;
            try
            {
                _selectedPackagingId = row.PackagingId;

                int currentComboVal = 0;
                if (cbMedicine.SelectedValue != null)
                {
                    int.TryParse(cbMedicine.SelectedValue.ToString(), out currentComboVal);
                }

                if (currentComboVal != 0)
                {
                    _selectedMedicineId = row.MedicineId;
                }

                tbPackageId.Text = row.PackagingId.ToString();
                tbPackageCode.Text = row.PackagingCode;
                tbNamePackage.Text = row.Name;
                tbPillsPerPack.Text = row.PillsPerPack.ToString();
                nudPricePerPack.Value = row.PricePerPack.HasValue ? row.PricePerPack.Value : 0m;
                nudPricePerPill.Value = row.PricePerPill.HasValue ? row.PricePerPill.Value : 0m;
                tbMedicineId.Text = row.MedicineId.ToString(); // hiển thị MedicineId lên textbox

                // Không đổi combobox nếu đang là (none); chỉ đồng bộ khi khác (none)
                if (currentComboVal != 0 && (cbMedicine.SelectedValue == null || cbMedicine.SelectedValue.ToString() != row.MedicineId.ToString()))
                {
                    _loadingMedicines = true;
                    cbMedicine.SelectedValue = row.MedicineId;
                    _loadingMedicines = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Load();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedPackagingId <= 0)
            {
                ShowError("Chưa chọn dòng.");
                return;
            }
            _presenter.Update();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedPackagingId <= 0)
            {
                ShowError("Chưa chọn dòng.");
                return;
            }
            var confirm = MessageBox.Show("Xóa packaging đã chọn?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            _presenter.Delete();
        }

        // IPackagingView
        public int SelectedMedicineId
        {
            get
            {
                int v;
                if (cbMedicine != null && cbMedicine.SelectedValue != null && int.TryParse(cbMedicine.SelectedValue.ToString(), out v))
                {
                    return v; // dùng cho filter
                }
                return _selectedMedicineId;
            }
        }
        public int InputMedicineId
        {
            get
            {
                int v; return int.TryParse(tbMedicineId.Text, out v) ? v : 0; // dùng cho Add/Edit
            }
        }
        public int SelectedPackagingId => _selectedPackagingId;
        public string PackagingCode => tbPackageCode.Text?.Trim() ?? string.Empty;
        public string PackagingName => tbNamePackage.Text?.Trim() ?? string.Empty;
        public int PillsPerPack
        {
            get
            {
                int v; return int.TryParse(tbPillsPerPack.Text, out v) ? v : 0;
            }
        }
        public decimal? PricePerPack => nudPricePerPack.Value;
        public decimal? PricePerPill => nudPricePerPill.Value;
        public string SearchKeyword => tbSearch.Text?.Trim() ?? string.Empty;

        public void BindPackages(IEnumerable<Packaging> items)
        {
            dgvLoadPackage.AutoGenerateColumns = true;
            dgvLoadPackage.DataSource = items.ToList();
        }

        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
