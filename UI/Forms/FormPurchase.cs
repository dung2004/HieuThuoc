using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HieuThuoc.Services.DTOs;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Presenters;
using HieuThuoc.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace HieuThuoc.UI.Forms
{
    public partial class FormPurchase : Form, IPurchaseView
    {
        private PurchasePresenter _presenter;
        public FormPurchase()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "Purchase";

            var svc = HieuThuoc.UI.Program.ServiceProvider.GetService<IPurchaseService>();
            _presenter = new PurchasePresenter(this, svc);

            this.Load += (s, e) => { _presenter.LoadLookups(); _presenter.LoadGrid(); HookAutoCalc(); };
        }

        private void LoadTheme()
        {
            LoadThemeRecurse(this);
        }

        private void LoadThemeRecurse(Control parent){
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

        private void HookAutoCalc()
        {
            nudReceivedPacks.Minimum = 0; nudPillsPerPack.Minimum = 0; nudReceivedLoosePills.Minimum = 0; nudUnitPricePerPill.Minimum = 0; nudTotalAmount.Minimum = 0; nudQuantityPills.Minimum = 0;
            EventHandler recalc = (s, e) =>
            {
                var qty = (int)nudReceivedPacks.Value * (int)nudPillsPerPack.Value + (int)nudReceivedLoosePills.Value;
                nudQuantityPills.Value = qty < 0 ? 0 : qty;
                nudTotalAmount.Value = nudQuantityPills.Value * nudUnitPricePerPill.Value;
            };
            nudReceivedPacks.ValueChanged += recalc;
            nudPillsPerPack.ValueChanged += recalc;
            nudReceivedLoosePills.ValueChanged += recalc;
            nudUnitPricePerPill.ValueChanged += recalc;
        }

        private void DgvLoad_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvLoad.CurrentRow?.DataBoundItem as PurchaseGridRow;
            if (row == null) return;
            tbPurchaseId.Text = row.PurchaseId.ToString();
            tbPurchaseDetailId.Text = row.PurchaseDetailId.ToString();
            tbSupplierId.Text = row.SupplierId.ToString();
            tbSupplierName.Text = row.SupplierName;
            tbPackagingId.Text = row.PackagingId.ToString();
            tbPackagingName.Text = row.PackagingName;
            tbMedicineName.Text = row.MedicineName;
            tbBatchCode.Text = row.BatchCode;
            dtpExpiryDate.Value = row.ExpiryDate;
            nudReceivedPacks.Value = row.ReceivedPacks;
            nudPillsPerPack.Value = row.PillsPerPack;
            nudReceivedLoosePills.Value = row.ReceivedLoosePills;
            nudQuantityPills.Value = row.QuantityPills;
            nudUnitPricePerPill.Value = row.UnitPricePerPill;
            nudTotalAmount.Value = row.TotalAmount;
            // split PurchaseDate: date to DTP, time to tbPurchaseDate (HH:mm:ss)
            dtpPurchasDate.Value = row.PurchaseDate.Date;
            var tbTime = this.Controls.Find("tbPurchaseDate", true).FirstOrDefault() as TextBox;
            if (tbTime != null) tbTime.Text = row.PurchaseDate.ToString("HH:mm:ss");
        }

        // IPurchaseView
        public int PurchaseId => int.TryParse(tbPurchaseId.Text, out var v) ? v : 0;
        public int PurchaseDetailId => int.TryParse(tbPurchaseDetailId.Text, out var v) ? v : 0;
        public int SupplierId => int.TryParse(tbSupplierId.Text, out var v) ? v : 0;
        public string SupplierName => tbSupplierName.Text?.Trim();
        public int PackagingId => int.TryParse(tbPackagingId.Text, out var v) ? v : 0;
        public string PackagingName => tbPackagingName.Text?.Trim();
        public string MedicineName => tbMedicineName.Text?.Trim();
        public string BatchCode => tbBatchCode.Text?.Trim();
        public DateTime ExpiryDate => dtpExpiryDate.Value.Date;
        public int ReceivedPacks => (int)nudReceivedPacks.Value;
        public int PillsPerPack => (int)nudPillsPerPack.Value;
        public int ReceivedLoosePills => (int)nudReceivedLoosePills.Value;
        public int QuantityPills => (int)nudQuantityPills.Value;
        public decimal UnitPricePerPill => nudUnitPricePerPill.Value;
        public decimal TotalAmount => nudTotalAmount.Value;
        public DateTime PurchaseDate
        {
            get
            {
                var date = dtpPurchasDate.Value.Date;
                var tbTime = this.Controls.Find("tbPurchaseDate", true).FirstOrDefault() as TextBox;
                TimeSpan ts;
                if (tbTime != null && TimeSpan.TryParse(tbTime.Text, out ts))
                {
                    return date.Add(ts);
                }
                return date;
            }
        }

        public void BindGrid(IEnumerable<PurchaseGridRow> rows)
        {
            dgvLoad.AutoGenerateColumns = true;
            dgvLoad.DataSource = rows.ToList();
        }

        public void BindSuppliers(IEnumerable<SimpleLookup> suppliers)
        {
            var list = suppliers.ToList();
            cbSupplierName.DisplayMember = "Name";
            cbSupplierName.ValueMember = "Id";
            cbSupplierName.DataSource = list;
            cbSupplierName.SelectedIndexChanged += (s, e) =>
            {
                var cur = cbSupplierName.SelectedItem as SimpleLookup;
                if (cur != null)
                {
                    tbSupplierId.Text = cur.Id.ToString();
                    tbSupplierName.Text = cur.Name;
                }
            };
        }

        public void BindPackagings(IEnumerable<PackagingLookup> packagings)
        {
            var list = packagings.ToList();
            cbPackagingName.DisplayMember = "PackagingName";
            cbPackagingName.ValueMember = "PackagingId";
            cbPackagingName.DataSource = list;
            cbPackagingName.SelectedIndexChanged += (s, e) =>
            {
                var cur = cbPackagingName.SelectedItem as PackagingLookup;
                if (cur != null)
                {
                    tbPackagingId.Text = cur.PackagingId.ToString();
                    tbPackagingName.Text = cur.PackagingName;
                    tbMedicineName.Text = cur.MedicineName;
                    nudPillsPerPack.Value = cur.PillsPerPack;
                }
            };
        }


        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnSavePurchase_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _presenter.LoadGrid();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            var c = MessageBox.Show("Có chắc muốn hủy không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c != DialogResult.Yes) return;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox t) t.Clear();
            }
            foreach (var n in new[] { nudReceivedPacks, nudPillsPerPack, nudReceivedLoosePills, nudQuantityPills, nudUnitPricePerPill, nudTotalAmount })
            {
                n.Value = 0;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _presenter.Update();
        }
    }
}
