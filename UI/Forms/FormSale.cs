using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HieuThuoc.Services.DTOs;
using HieuThuoc.Services.Implementations;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Presenters;
using HieuThuoc.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using HieuThuoc.Common;

namespace HieuThuoc.UI.Forms
{
    public partial class FormSale : Form, ISaleView
    {
        private SalePresenter _presenter;
        private BindingSource _cartSource = new BindingSource();
        private ISaleLookupService _lookup;
        private bool _loadingLookups = false;
        public FormSale()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Sale";
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
                else if (btns.HasChildren)
                {
                    // recurse
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var svc = HieuThuoc.UI.Program.ServiceProvider.GetService<ISaleService>();
            _lookup = HieuThuoc.UI.Program.ServiceProvider.GetService<ISaleLookupService>();
            _presenter = new SalePresenter(this, svc, _lookup);

            // set current user as SaleBy
            tbSaleBy.Text = CurrentUser.IsAuthenticated ? CurrentUser.AccId.ToString() : string.Empty;

            HookAutoCalc();
            dgvCartSale.DataSource = _cartSource;

            // load lookups
            LoadMedicineLookups();
            // initial load for grid (all)
            BindLoadGrid(_lookup?.SearchSales(null) ?? Enumerable.Empty<SaleGridRow>());
        }

        private void LoadMedicineLookups()
        {
            if (_lookup == null) return;
            _loadingLookups = true;
            try
            {
                // Medicine Name
                var medsByName = _lookup.GetMedicinesByName().ToList();
                cbMedicineName.DisplayMember = "Name";
                cbMedicineName.ValueMember = "Id";
                cbMedicineName.DataSource = medsByName;

                // Medicine Code
                var medsByCode = _lookup.GetMedicinesByCode().ToList();
                cbMedicineCode.DisplayMember = "Name";
                cbMedicineCode.ValueMember = "Id";
                cbMedicineCode.DataSource = medsByCode;
            }
            finally { _loadingLookups = false; }
        }

        private void LoadPackagingLookups(int medicineId)
        {
            if (_lookup == null) return;
            var packs = _lookup.GetPackagingsByMedicine(medicineId).ToList();
            cbPackagingName.DisplayMember = "PackagingName";
            cbPackagingName.ValueMember = "PackagingId";
            cbPackagingName.DataSource = packs;
        }

        private void LoadBatchLookups(int packagingId)
        {
            if (_lookup == null) return;
            var batches = _lookup.GetBatchesByPackaging(packagingId).ToList();
            cbBatchId.DisplayMember = "BatchId";
            cbBatchId.ValueMember = "BatchId";
            cbBatchId.DataSource = batches;
        }

        private void HookAutoCalc()
        {
            nudQuantityPacks.Minimum = 0; nudQuantityPills.Minimum = 0; nudPillsPerPack.Minimum = 0; nudPricePerPill.Minimum = 0; nudTotalPills.Minimum = 0; nudTotalAmount.Minimum = 0;
            EventHandler recalc = (s, e) =>
            {
                var total = (int)nudPillsPerPack.Value * (int)nudQuantityPacks.Value + (int)nudQuantityPills.Value;
                nudTotalPills.Value = total < 0 ? 0 : total;
                nudTotalAmount.Value = nudTotalPills.Value * nudPricePerPill.Value;
            };
            nudPillsPerPack.ValueChanged += recalc;
            nudQuantityPacks.ValueChanged += recalc;
            nudQuantityPills.ValueChanged += recalc;
            nudPricePerPill.ValueChanged += recalc;
        }

        private void dgvCartSale_SelectionChanged(object sender, EventArgs e)
        {
            // THINKING: load selected cart row back to inputs
        }

        private void dgvLoadSale_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvLoadSale.CurrentRow?.DataBoundItem as SaleGridRow;
            if (row == null) return;
            tbSaleId.Text = row.SaleId.ToString();
            tbSaleDetailId.Text = row.SaleDetailId.ToString();
            tbMedicineId.Text = row.MedicineId?.ToString();
            tbMedicineName.Text = row.MedicineName;
            tbMedicineCode.Text = row.MedicineCode;
            tbCustomerName.Text = row.CustomerName;
            tbPackagingId.Text = row.PackagingId?.ToString();
            tbPackagingName.Text = row.PackagingName;
            tbBatchId.Text = row.BatchId?.ToString();
            nudTotalQuantityPills.Value = row.TotalQuantityPills;
            nudQuantityPacks.Value = row.QuantityPacks;
            nudQuantityPills.Value = row.QuantityPills;
            nudPillsPerPack.Value = row.PillsPerPack;
            nudTotalPills.Value = row.TotalPills;
            nudPricePerPill.Value = row.PricePerPill;
            nudTotalAmount.Value = row.TotalAmount;
            dtpSaleDate.Value = row.SaleDate.Date;
            tbSaleDate.Text = row.SaleDate.ToString("HH:mm");
            // Do not override tbSaleBy from selected row; keep current user value
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            _presenter.AddToCart();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var kw = tbSearch?.Text?.Trim();
            _presenter.Search(kw);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _presenter.CancelCart();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            _presenter.SellAll();
        }

        private void btnDeleteCart_Click(object sender, EventArgs e)
        {
            if (dgvCartSale.CurrentRow != null)
            {
                _presenter.DeleteCartSelected(dgvCartSale.CurrentRow.Index);
            }
        }

        private void cbMedicineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingLookups) return;
            var sel = cbMedicineName.SelectedItem as SimpleLookup;
            if (sel == null) return;
            tbMedicineId.Text = sel.Id.ToString();
            tbMedicineName.Text = sel.Name;
            // sync code combo
            cbMedicineCode.SelectedValue = sel.Id;
            LoadPackagingLookups(sel.Id);
        }

        private void cbMedicineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingLookups) return;
            var sel = cbMedicineCode.SelectedItem as SimpleLookup;
            if (sel == null) return;
            tbMedicineId.Text = sel.Id.ToString();
            tbMedicineCode.Text = sel.Name;
            // sync name combo
            cbMedicineName.SelectedValue = sel.Id;
            LoadPackagingLookups(sel.Id);
        }

        private void cbPackagingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pack = cbPackagingName.SelectedItem as PackagingLookup;
            if (pack == null) return;
            tbPackagingId.Text = pack.PackagingId.ToString();
            tbPackagingName.Text = pack.PackagingName;
            nudPillsPerPack.Value = pack.PillsPerPack;
            if (pack.PricePerPill.HasValue) nudPricePerPill.Value = pack.PricePerPill.Value;
            LoadBatchLookups(pack.PackagingId);
        }

        private void cbBatchId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var b = cbBatchId.SelectedItem as HieuThuoc.Services.Interfaces.BatchLookup;
            if (b == null) return;
            tbBatchId.Text = b.BatchId.ToString();
            nudTotalQuantityPills.Value = b.QuantityPills;
        }

        // ISaleView
        public void BindLoadGrid(IEnumerable<SaleGridRow> items)
        {
            dgvLoadSale.AutoGenerateColumns = true;
            dgvLoadSale.DataSource = items.ToList();
        }

        public void BindCart(IEnumerable<SaleCartItem> items)
        {
            _cartSource.DataSource = items.ToList();
        }

        public int? MedicineId => int.TryParse(tbMedicineId.Text, out var v) ? (int?)v : null;
        public string MedicineName => tbMedicineName.Text?.Trim();
        public string MedicineCode => tbMedicineCode.Text?.Trim();
        public string CustomerName => tbCustomerName.Text?.Trim();
        public int? PackagingId => int.TryParse(tbPackagingId.Text, out var v) ? (int?)v : null;
        public string PackagingName => tbPackagingName.Text?.Trim();
        public int? BatchId => int.TryParse(tbBatchId.Text, out var v) ? (int?)v : null;
        public int TotalQuantityPills => (int)nudTotalQuantityPills.Value;
        public int QuantityPacks => (int)nudQuantityPacks.Value;
        public int QuantityPills => (int)nudQuantityPills.Value;
        public int PillsPerPack => (int)nudPillsPerPack.Value;
        public int TotalPills => (int)nudTotalPills.Value;
        public decimal PricePerPill => nudPricePerPill.Value;
        public decimal TotalAmount => nudTotalAmount.Value;
        public DateTime SaleDate
        {
            get
            {
                var date = dtpSaleDate.Value.Date;
                TimeSpan ts; if (TimeSpan.TryParse(tbSaleDate.Text, out ts)) return date.Add(ts);
                return date;
            }
        }
        public int? SaleBy => int.TryParse(tbSaleBy.Text, out var v) ? (int?)v : null;
        public string SearchKeyword => (this.Controls.Find("tbSearch", true).FirstOrDefault() as TextBox)?.Text?.Trim();
        public DateTime? SearchDate
        {
            get
            {
                var d = this.Controls.Find("dtpSearchSaleDate", true).FirstOrDefault() as DateTimePicker;
                return d != null && d.Checked ? (DateTime?)d.Value.Date : null;
            }
        }

        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
