using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.KhachHang
{
    public partial class ThanhToan : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> SanPham = new Dictionary<string, string>();

        public ThanhToan()
        {
            InitializeComponent();
        }

        private void ReloadDatabase()
        {
            dgvHoaDon.DataSource = processDatabase.DocBang($"SELECT TenSP, TenLoai, TenNhanHieu, GiaBan, SLMua, SUM(SLMua * GiaBan) AS ThanhTien FROM dbo.GioHang JOIN dbo.SanPham ON SanPham.MaSP = GioHang.MaSP JOIN dbo.Loai ON Loai.MaLoai = SanPham.MaLoai JOIN dbo.NhanHieu ON NhanHieu.MaNhanHieu = SanPham.MaNhanHieu WHERE MaKH = 'KH0001' GROUP BY GioHang.MaSP, TenSP, TenNhanHieu, TenLoai, GiaBan, SLMua");
            dgvHoaDon.ClearSelection();
            TinhTongTien();
            txtSL.Text = "";
            txtTenSP.Text = "";
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSP.Text = dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            txtTenSP.ReadOnly = true;
            txtSL.Text = dgvHoaDon.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            ReloadDatabase();
            DataTable dtSanPham = processDatabase.DocBang("select * from SanPham");
            foreach (DataRow dr in dtSanPham.Rows)
            {
                SanPham[dr["MaSP"].ToString()] = dr["TenSP"].ToString();
            }
        }

        private bool Validate()
        {
            if (Regex.Replace(txtSL.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập số lượng mua!");
                return false;
            }
            if (!Regex.IsMatch(txtSL.Text, "^[0-9]*[1-9][0-9]*$"))
            {
                MessageBox.Show("Số lượng mua chỉ có thể chứa số dương!");
                return false;
            }
            return true;
        }

        private string GetSanPham()
        {
            foreach (var x in SanPham)
            {
                if (x.Value == txtTenSP.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private string GetSanPham(string val)
        {
            foreach (var x in SanPham)
            {
                if (x.Value == val)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm muốn sửa!");
                return;
            }
            if (!Validate())
            {
                return;
            }
            processDatabase.ThiHanhLenh($"update giohang set slmua = {txtSL.Text} where makh = '{UserInfo.id}' and masp = '{GetSanPham()}'");
            ReloadDatabase(); 
        }

        private void TinhTongTien()
        {
            DataTable dtHDB = dgvHoaDon.DataSource as DataTable;
            decimal sum = 0;
            foreach (DataRow dr in dtHDB.Rows)
            {
                decimal tt = Decimal.Parse(dr["ThanhTien"].ToString());
                sum += tt;

            }
            lbTongTien.Text = sum.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn xác nhận thanh toán?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string MaHDB = processDatabase.Function("select dbo.sinhkhoamaHDB()");
                processDatabase.ThiHanhLenh($"insert hoadonban(mahdb, ngayban, manv, makh, tongtien) values ('{MaHDB}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', 'NV0001', '{UserInfo.id}', {lbTongTien.Text})");
                DataTable dtHDB = dgvHoaDon.DataSource as DataTable;
                foreach (DataRow dr in dtHDB.Rows) {
                    processDatabase.ThiHanhLenh($"INSERT dbo.ChiTietHDB (MaHDB, MaSP, SoLuong, ThanhTien, KhuyenMai) VALUES ('{MaHDB}', '{GetSanPham(dr["TenSP"].ToString())}', {dr["SLMua"].ToString()},  {dr["ThanhTien"].ToString()}, 0)");
                }
                processDatabase.ThiHanhLenh($"delete from giohang where makh = '{UserInfo.id}'");
                MessageBox.Show("Chúng tôi đã nhận được đơn hàng của bạn. Đơn hàng của bạn sẽ được xử lý sớm nhất có thể.");
                ReloadDatabase();
                var frm = (TrangChu)this.Owner;
                if (frm != null)
                    frm.DonHangDaMua();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm muốn xoá!");
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xoá sản phẩm {txtTenSP.Text} ra khỏi giỏ hàng?", "Thông báo", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                processDatabase.ThiHanhLenh($"delete from giohang where makh = '{UserInfo.id}' and masp = '{GetSanPham()}'");
                MessageBox.Show("Đã xoá sản phẩm ra khỏi giỏ hàng!");
                ReloadDatabase();
            }
        }
    }
}
