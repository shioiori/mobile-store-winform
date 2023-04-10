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
    public partial class TimKiemSanPham : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        public TimKiemSanPham()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSP.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemMaSP(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenSP.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemTenSP(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaNH.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemMaNhanHieu(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenNH.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemNhanHieu(N'{txtInput.Text}')");
                return;
            }
            if (rdbMaMH.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemMaManHinh(N'{txtInput.Text}')");
                return;
            }
            if (rdbTenMH.Checked)
            {
                dgvTimKiem.DataSource = processDatabase.DocBang($"SELECT * FROM TimKiemTenManHinh(N'{txtInput.Text}')");
                return;
            }
        }
    }
}
