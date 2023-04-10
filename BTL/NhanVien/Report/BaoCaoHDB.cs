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
    public partial class BaoCaoHDB : Form
    {
        public BaoCaoHDB()
        {
            InitializeComponent();
        }
        ProcessDatabase db = new ProcessDatabase();
        private void btnTimHDB_Click(object sender, EventArgs e)
        {
            this.reportViewer3.Reset();
            this.reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.ReportEmbeddedResource = "BTL.NhanVien.Report.BaoCaoHDB.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dtHDB";
            reportDataSource.Value = db.DocBang($"Select * from HDBTheoNam({txtNamHDB.Text})");
            reportViewer3.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer3.RefreshReport();
            DataTable ndb = new DataTable();
            ndb = db.DocBang($"Select * from TongTienBanTheoNam({txtNamHDB.Text})");
            txtTienBan.Text = ndb.Rows[0][0].ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtNamHDB.Text = "";
        }
    }
}
