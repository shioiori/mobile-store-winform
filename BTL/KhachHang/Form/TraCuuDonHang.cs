using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.KhachHang
{
    public partial class TraCuuDonHang : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        public TraCuuDonHang()
        {
            InitializeComponent();
        }

        private void TraCuuDonHang_Load(object sender, EventArgs e)
        {
            DataTable dt = processDatabase.DocBang($"select diachi from khachhang where makh = '{UserInfo.id}'");
            txtTenKH.Text = UserInfo.name;
            txtDiaChi.Text = dt.Rows[0][0].ToString();
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            dgvHoaDon.DataSource = processDatabase.DocBang($"SELECT HoaDonBan.MaHDB, NgayBan, TongTien FROM dbo.HoaDonBan WHERE MaKH = '{UserInfo.id}'");
            dt = dgvHoaDon.DataSource as DataTable;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd = dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            dgvSanPham.DataSource = processDatabase.DocBang($"SELECT TenSP, TenLoai, TenNhanHieu, ChiTietHDB.SoLuong AS SoLuongMua, GiaBan, KhuyenMai, ThanhTien FROM dbo.ChiTietHDB JOIN dbo.SanPham ON SanPham.MaSP = ChiTietHDB.MaSP JOIN dbo.Loai ON Loai.MaLoai = SanPham.MaLoai JOIN dbo.NhanHieu ON NhanHieu.MaNhanHieu = SanPham.MaNhanHieu WHERE MaHDB = '{mahd}'");
            lbTongTien.Text = dgvHoaDon.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
