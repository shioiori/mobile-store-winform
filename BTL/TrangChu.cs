using BTL.Admin;
using BTL.KhachHang;
using BTL.NhanVien.Report;
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
    public partial class TrangChu : Form
    {
        public static TrangChu Instance = null;
        Form activeForm = null;
        public TrangChu()
        {
            InitializeComponent();
            TrangChu.Instance = this;
        }


        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelControl.Controls.Add(childForm);
            panelControl.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLSanPham());
        }

        private void hoáĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HoaDonBan());
        }

        public void ThanhToan()
        {
            thanhToánToolStripMenuItem.PerformClick();
        }

        public void DonHangDaMua()
        {
            đơnHàngĐãMuaToolStripMenuItem.PerformClick();
        }

        private void hoáĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HoaDonNhap());
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TimKiemSanPham());
        }

        private void hoáĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TimKiemHDN());
        }

        private void hoáĐơnBánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TimKiemHDB());
        }

        private void đơnHàngĐãMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TraCuuDonHang());
        }

        private void muaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuaHang muaHang = new MuaHang();
            muaHang.Owner = this;
            OpenChildForm(muaHang);
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Owner = this;
            OpenChildForm(thanhToan);
        }

        private void quảnLýToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            lbThongTinUser.Text = $"{UserInfo.name}, bạn đang sử dụng hệ thống với vai trò {UserInfo.per}.";
            if (UserInfo.per == "khách hàng")
            {
                báoCáoToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible = false;
                tìmKiếmToolStripMenuItem.Visible = false;
            }
            else if (UserInfo.per == "nhân viên")
            {
                muaHàngToolStripMenuItem.Visible = false;
                thanhToánToolStripMenuItem.Visible = false;
                đơnHàngĐãMuaToolStripMenuItem.Visible = false;
                nhânViênToolStripMenuItem.Visible = false;
                nhàCungCấpToolStripMenuItem.Visible = false;
                báoCáoToolStripMenuItem.Visible = false;
            }
            else
            {
                muaHàngToolStripMenuItem.Visible = false;
                thanhToánToolStripMenuItem.Visible = false;
                đơnHàngĐãMuaToolStripMenuItem.Visible = false;
            }
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLNCC());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLNhanVien());
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void sảnPhẩmBánChạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoSPBC());
        }

        private void nhânViênBánÍtNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoNV());
        }

        private void tiềnNhậpLớnNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoHDN());        
        }

        private void tiềnBánTheoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoHDB());
        }
    }
}
