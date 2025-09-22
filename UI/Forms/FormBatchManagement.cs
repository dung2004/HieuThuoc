using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HieuThuoc.Domain.Entities;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Presenters;
using HieuThuoc.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace HieuThuoc.UI.Forms
{
    public partial class FormBatchManagement : Form, IBatchView
    {
        private BatchPresenter _presenter;
        private int _selectedBatchId = 0;
        public FormBatchManagement()
        {
            InitializeComponent();
            LoadTheme();
            this.Text = "BatchManagement";

            var batchSvc = HieuThuoc.UI.Program.ServiceProvider.GetService<IBatchService>();
            var medSvc = HieuThuoc.UI.Program.ServiceProvider.GetService<IMedicineService>();
            _presenter = new BatchPresenter(this, batchSvc, medSvc);

            this.Load += (s, e) => { _presenter.LoadFilters(); _presenter.ReloadAll(); };
            this.btnSearch.Click += (s, e) => _presenter.Search();
            this.btnReloadAll.Click += (s, e) => _presenter.ReloadAll();
            this.btnEdit.Click += (s, e) => _presenter.Update();
            this.btnDelete.Click += (s, e) => _presenter.Delete();

            // set constraints non-negative
            nudPurchasePrice.Minimum = 0; nudReceivedPacks.Minimum = 0; nudReceivedLoosePills.Minimum = 0;
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

        private void DgvLoadBatch_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvLoadBatch.CurrentRow?.DataBoundItem as Batch;
            if (row == null) return;
            _selectedBatchId = row.BatchId;
            tbBatchId.Text = row.BatchId.ToString();
            tbPackagingId.Text = row.PackagingId.ToString();
            tbBatchCode.Text = row.BatchCode;
            dtpExpiryDay.Value = row.ExpiryDate;
            nudQuantityPills.Value = row.QuantityPills;
            nudPurchasePrice.Value = row.PurchasePrice;
            nudReceivedPacks.Value = (row.ReceivedPacks ?? 0);
            nudReceivedLoosePills.Value = (row.ReceivedLoosePills ?? 0);
            dtpCreatedAt.Value = row.CreatedAt.Date;
            if (tbCreatedAt != null) tbCreatedAt.Text = row.CreatedAt.ToString("HH:mm");
        }

        // IBatchView
        public int? SelectedMedicineId
        {
            get
            {
                if (cbMedicine.SelectedValue == null) return null;
                int v; return int.TryParse(cbMedicine.SelectedValue.ToString(), out v) ? (int?)v : null;
            }
        }
        public string SearchKeyword => tbSearch.Text?.Trim();
        // Sử dụng khoảng ngày chỉ khi checkbox cbUsePeriod được chọn
        public DateTime? FromExpiry
        {
            get { return (cbUsePeriod != null && cbUsePeriod.Checked) ? (DateTime?)dtpFrom.Value.Date : null; }
        }
        public DateTime? ToExpiry
        {
            get { return (cbUsePeriod != null && cbUsePeriod.Checked) ? (DateTime?)dtpTo.Value.Date : null; }
        }

        public int SelectedBatchId => _selectedBatchId;
        public int PackagingId
        {
            get
            {
                int v; return int.TryParse(tbPackagingId.Text, out v) ? v : 0;
            }
        }
        public string BatchCode => tbBatchCode.Text?.Trim();
        public DateTime ExpiryDate => dtpExpiryDay.Value.Date;
        public decimal PurchasePrice => nudPurchasePrice.Value;
        public int? ReceivedPacks => (int?)nudReceivedPacks.Value;
        public int? ReceivedLoosePills => (int?)nudReceivedLoosePills.Value;
        public DateTime CreatedAt
        {
            get
            {
                // Kết hợp ngày từ dtpCreatedAt và giờ:phút từ tbCreatedAt (HH:mm)
                var date = dtpCreatedAt.Value.Date;
                TimeSpan time;
                if (tbCreatedAt != null && TimeSpan.TryParse(tbCreatedAt.Text, out time))
                {
                    return date.Add(time);
                }
                // fallback: giữ nguyên giờ của dtp hoặc 00:00 nếu cần
                return date;
            }
        }

        public void BindBatches(IEnumerable<Batch> items)
        {
            var list = items.ToList();
            dgvLoadBatch.AutoGenerateColumns = true;
            dgvLoadBatch.DataSource = list;

            // Highlight top 3 nearest expiries
            if (list.Count > 0)
            {
                var ordered = list.OrderBy(x => x.ExpiryDate).ToList();
                var first = ordered.ElementAtOrDefault(0)?.BatchId;
                var second = ordered.ElementAtOrDefault(1)?.BatchId;
                var third = ordered.ElementAtOrDefault(2)?.BatchId;
                foreach (DataGridViewRow r in dgvLoadBatch.Rows)
                {
                    var b = r.DataBoundItem as Batch; if (b == null) continue;
                    if (b.BatchId == first) r.DefaultCellStyle.BackColor = Color.Red;
                    else if (b.BatchId == second) r.DefaultCellStyle.BackColor = Color.Orange;
                    else if (b.BatchId == third) r.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        public void BindMedicines(IEnumerable<Medicine> items)
        {
            var list = items.Select(m => new { m.MedicineId, m.Name }).ToList();
            list.Insert(0, new { MedicineId = 0, Name = "(All)" });
            cbMedicine.DisplayMember = "Name";
            cbMedicine.ValueMember = "MedicineId";
            cbMedicine.DataSource = list;
        }

        public void ShowMessage(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

    }
}
