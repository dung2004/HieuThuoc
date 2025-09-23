using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HieuThuoc.UI.Forms
{
    public partial class FormChoseReport : Form
    {
        public FormChoseReport()
        {
            InitializeComponent();
        }

        private void btnBatchReport_Click(object sender, EventArgs e)
        {
            FormReport f = new FormReport("Batch");
            f.Show();
            this.Close();
        }
    }
}
