using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.NhanVien.Report
{
    public partial class BaoCaoNV : Form
    {
        public BaoCaoNV()
        {
            InitializeComponent();
        }
        ProcessDatabase db = new ProcessDatabase();
        private void btnTimNV_Click(object sender, EventArgs e)
        {
            this.reportViewer4.Reset();
            this.reportViewer4.LocalReport.DataSources.Clear();
            reportViewer4.LocalReport.ReportEmbeddedResource = "BTL.NhanVien.Report.BaoCaoNV.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dtNV";
            reportDataSource.Value = db.DocBang($"Select * from TopNhanVienBanItNhat({cbbThang1.SelectedIndex + 1},{txtNamNV.Text})");
            reportViewer4.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer4.RefreshReport();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbThang1.Text = "Tháng 1";
            txtNamNV.Text = "";
        }
    }
}
