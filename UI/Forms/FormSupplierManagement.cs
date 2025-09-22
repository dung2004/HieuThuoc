using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    public partial class FormSupplierManagement : Form, ISupplierView
    {
        private SupplierPresenter _presenter;
        private int _selectedSupplierId = 0;
        public FormSupplierManagement()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Supplier Management";

            var svc = HieuThuoc.UI.Program.ServiceProvider.GetService<HieuThuoc.Services.Interfaces.ISupplierService>();
            _presenter = new SupplierPresenter(this, svc);
            this.Load += (s, e) => _presenter.Load();
            this.dgvLoadSupplier.SelectionChanged += DgvLoadSupplier_SelectionChanged;
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

        private void DgvLoadSupplier_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvLoadSupplier.CurrentRow?.DataBoundItem as Supplier;
            if (row == null) return;
            _selectedSupplierId = row.SupplierId;
            tbSupplierId.Text = row.SupplierId.ToString();
            tbName.Text = row.Name;
            tbPhone.Text = row.Phone;
            tbAddress.Text = row.Address;
        }

        // ISupplierView
        public int SelectedSupplierId => _selectedSupplierId;
        public string SupplierName => tbName.Text?.Trim() ?? string.Empty;
        public string SupplierPhone => tbPhone.Text?.Trim() ?? string.Empty;
        public string SupplierAddress => tbAddress.Text?.Trim() ?? string.Empty;
        public string SearchKeyword => tbSearch.Text?.Trim() ?? string.Empty;

        public void BindSuppliers(IEnumerable<Supplier> suppliers)
        {
            dgvLoadSupplier.AutoGenerateColumns = true;
            dgvLoadSupplier.DataSource = suppliers.ToList();
        }

        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId <= 0)
            {
                ShowError("Chưa chọn nhà cung cấp.");
                return;
            }
            _presenter.Update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId <= 0)
            {
                ShowError("Chưa chọn nhà cung cấp.");
                return;
            }
            var confirm = MessageBox.Show("Xóa nhà cung cấp đã chọn?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            _presenter.Delete();
        }
    }
}
