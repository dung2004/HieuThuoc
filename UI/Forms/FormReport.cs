using HieuThuoc.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HieuThuoc.UI.Forms
{
    public partial class FormReport : Form
    {
        private string _option;
        string strcon = @"Data Source=Diary\TANDUNGSV;Initial Catalog=HieuThuoc;Integrated Security=True";
        private SqlConnection sqlcon;
        private SqlDataAdapter da;
        private DataTable dt;
        public FormReport(string option)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _option=option;
        }

        private void btnQL_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable GetDataFromQuery(string query)
        {
            try
            {
                if (sqlcon == null)
                {
                    sqlcon = new SqlConnection(strcon);
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            da = new SqlDataAdapter(query, sqlcon);
            dt = new DataTable();
            da.Fill(dt);
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }

            return dt;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            if (_option == "batch")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportBatch.rdlc";
                    string query = @"select 
BatchId, PackagingId, BatchCode, Format(CreatedAt, 'dd/MM/yyyy') as ExpiryDate, QuantityPills, PurchasePrice, ReceivedPacks, ReceivedLoosePills, CreatedAt
from Batch;";
                    DataTable dt = GetDataFromQuery(query);
                    ReportDataSource reportDataSource = new ReportDataSource("DataSetBatch", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else if (_option == "accounts")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportAccounts.rdlc";
                    string query = @"select 
AccId, Username, PasswordHash, FullName, email, SDT, RoleID, CreatedBy, CreatedAt, IsActive, ImageFile
from Accounts;";
                    DataTable dt = GetDataFromQuery(query);
                    ReportDataSource reportDataSource = new ReportDataSource("DataSetAccounts", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else if (_option == "medicine")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportMedicine.rdlc";
                    string query = @"select 
MedicineId, MedicineCode, Name, GenericName, Manufacturer, Unit, Description, ImageFile 
from Medicine;";
                    DataTable dt = GetDataFromQuery(query);
                    ReportDataSource reportDataSource = new ReportDataSource("DataSetMedicine", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else if (_option == "packaging")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportPackaging.rdlc";
                    string query = @"select 
*
from Packaging;";
                    DataTable dt = GetDataFromQuery(query);
                    ReportDataSource reportDataSource = new ReportDataSource("DataSetPackaging", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }//PackagingId, MedicineId, PackagingCode, Name, PillsPerPack, PricePerPack, PricePerPill 
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else if (_option == "purchase")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportPurchase.rdlc";
                    string query1 = @"SELECT 
    p.PurchaseId,
    p.SupplierId,
    p.PurchaseDate,
    p.TotalAmount
FROM Purchase p
INNER JOIN PurchaseDetail pd 
    ON p.PurchaseId = pd.PurchaseId
ORDER BY p.PurchaseId, pd.PurchaseDetailId;";
                    string query2 = @"SELECT 
    pd.PurchaseDetailId,
    pd.BatchId,
    pd.QuantityPacks,
    pd.QuantityPills,
    pd.UnitPricePerPill
FROM Purchase p
INNER JOIN PurchaseDetail pd 
    ON p.PurchaseId = pd.PurchaseId
ORDER BY p.PurchaseId, pd.PurchaseDetailId;";
                    DataTable dt1 = GetDataFromQuery(query1);
                    DataTable dt2 = GetDataFromQuery(query2);
                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSetPurchase", dt1);
                    ReportDataSource reportDataSource2 = new ReportDataSource("DataSetPurchaseDetail", dt2);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else if (_option == "sale")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportSale.rdlc";
                    string query1 = @"SELECT 
    s.SaleId,
    s.CustomerName,
    s.SaleDate,
    s.TotalAmount,
    s.SaleBy
FROM Sale s
INNER JOIN SaleDetail sd 
    ON s.SaleId = sd.SaleId
INNER JOIN SaleBatchAllocation sba 
    ON sd.SaleDetailId = sba.SaleDetailId
   AND s.SaleId = sba.SaleId
ORDER BY s.SaleId, sd.SaleDetailId, sba.AllocationId;";
                    string query2 = @"SELECT 
    sd.SaleDetailId,
    sd.MedicineId,
    sd.PackagingId,
    sd.QuantityPacks,
    sd.QuantityPills,
    sd.UnitPrice
FROM Sale s
INNER JOIN SaleDetail sd 
    ON s.SaleId = sd.SaleId
INNER JOIN SaleBatchAllocation sba 
    ON sd.SaleDetailId = sba.SaleDetailId
   AND s.SaleId = sba.SaleId
ORDER BY s.SaleId, sd.SaleDetailId, sba.AllocationId;";
                    string query3 = @"SELECT 
    sba.AllocationId,
    sba.BatchId,
    sba.AllocatedPills
FROM Sale s
INNER JOIN SaleDetail sd 
    ON s.SaleId = sd.SaleId
INNER JOIN SaleBatchAllocation sba 
    ON sd.SaleDetailId = sba.SaleDetailId
   AND s.SaleId = sba.SaleId
ORDER BY s.SaleId, sd.SaleDetailId, sba.AllocationId;";
                    DataTable dt1 = GetDataFromQuery(query1);
                    DataTable dt2 = GetDataFromQuery(query2);
                    DataTable dt3 = GetDataFromQuery(query3);
                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSetSale", dt1);
                    ReportDataSource reportDataSource2 = new ReportDataSource("DataSetSaleDetail", dt2);
                    ReportDataSource reportDataSource3 = new ReportDataSource("DataSetSaleBatchAllocation", dt3);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else if (_option == "supplier")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportSupplier.rdlc";
                    string query = @"select * from Supplier;";
                    DataTable dt = GetDataFromQuery(query);
                    ReportDataSource reportDataSource = new ReportDataSource("DataSetSupplier", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else if (_option == "roles")
            {
                try
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "HieuThuoc.UI.Reports.ReportRoles.rdlc";
                    string query = @"select * from Roles;";
                    DataTable dt = GetDataFromQuery(query);
                    ReportDataSource reportDataSource = new ReportDataSource("DataSetRoles", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    ReportParameter rp = new ReportParameter("ShowCount", dt.Rows.Count.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Option không hợp lệ.");
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
