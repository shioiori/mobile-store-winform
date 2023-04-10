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
    public partial class BaoCaoHDN : Form
    {
        public BaoCaoHDN()
        {
            InitializeComponent();
        }
        ProcessDatabase db = new ProcessDatabase();
        private void BaoCaoHDN_Load(object sender, EventArgs e)
        {
            cbbQuy.Items.Add(1);
            cbbQuy.Items.Add(2);
            cbbQuy.Items.Add(3);
            cbbQuy.Items.Add(4);
        }

        private void btnTimHDN_Click(object sender, EventArgs e)
        {
            this.reportViewer2.Reset();
            this.reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.ReportEmbeddedResource = "BTL.NhanVien.Report.BaoCaoHDN.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dtHDN";
            reportDataSource.Value = db.DocBang($"Select * from Hdntheoquy({cbbQuy.Text},{txtNam.Text})");
            reportViewer2.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer2.RefreshReport();
            DataTable ndb = new DataTable();
            ndb = db.DocBang($"Select * from tongtiennhapmax({cbbQuy.Text},{txtNam.Text})");
            try
            {
                txtTienNhap.Text = ndb.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {
                txtTienNhap.Text = "0";
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbQuy.SelectedIndex = 0;
            txtNam.Text = "";
        }
    }
}
