using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class TimKiemHDN : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        public TimKiemHDN()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSP.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDNMaHang(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenSP.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDNTenHang(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaHDN.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDNMaHD(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaNCC.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDNNCCMa(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenNCC.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TTimKiemHDNNCCTen(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaNV.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDNNhanVienMa(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenNV.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDNNhanVienTen(N'{txtInput.Text}')");
                return;
            }

        }
    }
}
