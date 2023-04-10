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
    public partial class TimKiemHDB : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        public TimKiemHDB()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSP.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBMaHang(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenSP.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBTenHang(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaHDB.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBMaHD(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaKH.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBKhachHangMa(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenKH.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBKhachHangTen(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaNV.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBNhanVienMa(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenNV.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemHDBNhanVienTen(N'{txtInput.Text}')");
                return;
            }
        }

        private void TimKiemHDB_Load(object sender, EventArgs e)
        {
        }
    }
}
