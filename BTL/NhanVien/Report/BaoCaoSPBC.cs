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
    public partial class BaoCaoSPBC : Form
    {
        public BaoCaoSPBC()
        {
            InitializeComponent();
        }
        ProcessDatabase db = new ProcessDatabase();

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "BTL.NhanVien.Report.BaoCaoSPBC.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dtSPBC";
            reportDataSource.Value = db.DocBang($"Select * from SanPhamBanChay({cbbThang1.SelectedIndex+1},{txtNam.Text})");
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbThang1.Text = "Tháng 1";
            txtNam.Text = "";
        }
    }
}
