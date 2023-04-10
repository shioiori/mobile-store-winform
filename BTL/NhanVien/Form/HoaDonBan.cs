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

namespace BTL
{
    public partial class HoaDonBan : Form
    {
        public ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> NhanVien = new Dictionary<string, string>();
        Dictionary<string, string> KhachHang = new Dictionary<string, string>();
        public HoaDonBan()
        {
            InitializeComponent();
        }

        private void ReloadDatabase()
        {
            dgvHoaDon.DataSource = processDatabase.DocBang($"select ChiTietHDB.MaSP, TenSP, TenLoai, TenNhanHieu, GiaBan, ChiTietHDB.SoLuong, KhuyenMai, ThanhTien from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh JOIN dbo.ChiTietHDB ON ChiTietHDB.MaSP = SanPham.MaSP JOIN dbo.HoaDonBan ON HoaDonBan.MaHDB = ChiTietHDB.MaHDB WHERE HoaDonBan.MaHDB = '{txtMaHDB.Text}'");
            dgvHoaDon.ClearSelection();
            processDatabase.ThiHanhLenh($"update hoadonban set tongtien = {lbTongTien.Text} where mahdb = '{txtMaHDB.Text}'");
            dgvSanPham.DataSource = processDatabase.DocBang("select MaSP, TenSP, TenLoai, TenNhanHieu, GiaBan, SoLuong, TGBH from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh");
            dgvSanPham.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form HoaDon = new HoaDon(cbKH.Text, txtDiaChi.Text, txtNgayBan.Value.ToString(), txtKhuyenMai.Text, dgvHoaDon);
            HoaDon.Show();
        }

        private bool ValidateForm()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                if (Regex.Replace(button.Text, @"\s+", "") == "")
                {
                    MessageBox.Show("Chưa nhập đủ thông tin!");
                    return false;
                }
            }
            if (!processDatabase.Find(cbNVBan.Text))
            {
                MessageBox.Show("Không có nhân viên này trong database!");
                return false;
            }
            return true;
        }

        private void TaoHoaDonBan_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = processDatabase.DocBang("select MaSP, TenSP, TenLoai, TenNhanHieu, GiaBan, SoLuong, TGBH from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh");
            txtMaHDB.Text = "Nhập mã hoá đơn..."; 
            DataTable dtNV = processDatabase.DocBang("select * from NhanVien");
            foreach (DataRow dr in dtNV.Rows)
            {
                cbNVBan.Items.Add(dr["TenNV"].ToString());
                NhanVien[dr["MaNV"].ToString()] = dr["TenNV"].ToString();
            }
            DataTable dtKH = processDatabase.DocBang("select * from KhachHang");
            foreach (DataRow dr in dtKH.Rows)
            {
                cbKH.Items.Add(dr["TenKhach"].ToString());
                KhachHang[dr["MaKH"].ToString()] = dr["TenKhach"].ToString();
            }
            dgvSanPham.ClearSelection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVHoaDon())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from hoadonban where mahdb = '{txtMaHDB.Text}'"))
            {
                MessageBox.Show("Chưa có mã hoá đơn bán này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"update hoadonban set ngayban = '{txtNgayBan.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', manv = '{GetNhanVien()}', makh = '{GetKhachHang()}', tongtien = {lbTongTien.Text} where mahdb = '{txtMaHDB.Text}'");
            MessageBox.Show("Lưu thông tin hoá đơn thành công!");
            ReloadDatabase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtMaHDB.ReadOnly = true;
            txtMaHDB.Text = processDatabase.Function("select dbo.sinhkhoamaHDB()");
            cbKH.Text = null;
            txtDiaChi.Text = "";
            txtNgayBan.Value = DateTime.Now;
            cbNVBan.Text = null;
            dgvHoaDon.DataSource = null;
            dgvSanPham.ClearSelection();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtMaHDB.ReadOnly = false;
            if (txtMaHDB.Text == "")
            {
                MessageBox.Show("Chưa sinh mã hoá đơn mới!");
            }
            DataTable dt = processDatabase.DocBang($"SELECT TenKhach, KhachHang.DiaChi, NgayBan, TenNV FROM dbo.HoaDonBan JOIN dbo.KhachHang ON KhachHang.MaKH = HoaDonBan.MaKH JOIN dbo.NhanVien ON NhanVien.MaNV = HoaDonBan.MaNV WHERE HoaDonBan.MaHDB = '{txtMaHDB.Text}'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có hoá đơn này trong database!");
            }
            else
            {
                ReloadDatabase();
                DataTable dtHDB = dgvHoaDon.DataSource as DataTable;
                TinhTongTien();
                foreach (DataRow dr in dt.Rows)
                {
                    cbKH.Text = dr["TenKhach"].ToString();
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                    txtNgayBan.Value = (DateTime)dr["NgayBan"];
                    cbNVBan.Text = dr["TenNV"].ToString();
                }
            }
            
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSP.Text = dgvSanPham.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.DataSource == null)
            {
                MessageBox.Show("Hãy thêm mới hoặc chọn hoá đơn bán đã tồn tại!");
                return;
            }
            if (!processDatabase.IsInTable($"select * from chitiethdb where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}' and mahdb = '{txtMaHDB.Text}'"))
            {
                MessageBox.Show("Sản phẩm này chưa có trong hoá đơn!");
                return;
            }
            else
            {
                processDatabase.ThiHanhLenh($"delete from chitiethdb where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}' and mahdb = '{txtMaHDB.Text}'");
                MessageBox.Show("Xoá sản phẩm thành công!");
                ReloadDatabase();
                TinhTongTien();
                txtKhuyenMai.Text = "";
                txtSLMua.Text = "";
                txtTenSP.Text = "";
            }
        }

        private void txtMaHDB_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMaHDB_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMaHDB.Text == "Nhập mã hoá đơn...")
            {
                txtMaHDB.Text = "";
            }
        }

        private bool ValidateDGVSanPham()
        {
            if (Regex.Replace(txtTenSP.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa chọn sản phẩm!");
                return false;
            }
            if (Regex.Replace(txtSLMua.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập số lượng mua!");
                return false;
            }
            if (Regex.Replace(txtKhuyenMai.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập phần trăm khuyến mãi!");
                return false;
            }
            if (!Regex.IsMatch(txtSLMua.Text, "^[0-9]*[1-9][0-9]*$"))
            {
                MessageBox.Show("Số lượng mua chỉ có thể chứa số dương!");
                return false;
            }
            if (!Regex.IsMatch(txtKhuyenMai.Text, "^\\d{1,5}$|(?=^.{1,5}$)^\\d+\\.\\d{0,2}$"))
            {
                MessageBox.Show("Khuyến mãi chỉ có thể là kiểu số thực");
                return false;
            }
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn sản phẩm!");
                return false;
            }
            if (Int32.Parse(txtSLMua.Text) > Int32.Parse(dgvSanPham.SelectedRows[0].Cells[5].Value.ToString()))
            {
                MessageBox.Show("Số lượng mua vượt quá số lượng tồn kho!");
                return false;
            }
            if (Decimal.Parse(txtKhuyenMai.Text) > 100)
            {
                MessageBox.Show("Khuyến mãi không thể vượt quá 100!");
                return false;
            }
            if (Decimal.Parse(txtKhuyenMai.Text) < 0)
            {
                MessageBox.Show("Khuyến mãi không thể là số âm!");
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.DataSource == null)
            {
                MessageBox.Show("Hãy thêm mới hoặc chọn hoá đơn bán đã tồn tại!");
                return;
            }
            if (!ValidateDGVSanPham())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from chitiethdb where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}' and mahdb = '{txtMaHDB.Text}'"))
            {
                MessageBox.Show("Đã có sản phẩm này trong hoá đơn!");
                return;
            }
            decimal tt = (Decimal.Parse(txtSLMua.Text) * Decimal.Parse(dgvSanPham.SelectedRows[0].Cells[4].Value.ToString())) / 100 * (100 - Decimal.Parse(txtKhuyenMai.Text));
            processDatabase.ThiHanhLenh($"INSERT dbo.ChiTietHDB (MaHDB, MaSP, SoLuong, ThanhTien, KhuyenMai) VALUES ('{txtMaHDB.Text}', '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}', {txtSLMua.Text},  {tt}, {txtKhuyenMai.Text})");
            MessageBox.Show("Thêm sản phẩm vào đơn hàng thành công!");
            ReloadDatabase();
            TinhTongTien();
        }

        

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.DataSource == null)
            {
                MessageBox.Show("Hãy thêm mới hoặc chọn hoá đơn bán đã tồn tại!");
                return;
            }
            if (!ValidateDGVSanPham())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from chitiethdb where mahdb = '{txtMaHDB.Text}' and masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}'"))
            {
                MessageBox.Show("Sản phẩm không có trong hoá đơn!");
                return;
            }
            decimal tt = (Decimal.Parse(txtSLMua.Text) * Decimal.Parse(dgvSanPham.SelectedRows[0].Cells[4].Value.ToString())) / 100 * (100 - Decimal.Parse(txtKhuyenMai.Text));
            processDatabase.ThiHanhLenh($"update chitiethdb set soluong = {txtSLMua.Text}, khuyenmai = {txtKhuyenMai.Text}, thanhtien = {tt} where mahdb = '{txtMaHDB.Text}' and masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}'");
            MessageBox.Show("Sửa sản phẩm thành công!");
            ReloadDatabase();
            TinhTongTien();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaSP = dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            dgvSanPham.ClearSelection();
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                //MessageBox.Show((row.Cells[0].Value.ToString() == MaSP).ToString(), row.Cells[0].Value.ToString());
                try
                {
                    if (String.Equals(row.Cells[0].Value.ToString(), MaSP, StringComparison.InvariantCultureIgnoreCase))
                    {
                        dgvSanPham.Rows[0].Selected = false;
                        row.Selected = true;
                        txtTenSP.Text = dgvSanPham.SelectedRows[0].Cells[1].Value.ToString();
                        txtKhuyenMai.Text = dgvHoaDon.SelectedRows[0].Cells[6].Value.ToString();
                        txtSLMua.Text = dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString();
                        return;
                    }
                }
                catch (Exception ex) { }
            }
            
        }
        private string GetNhanVien()
        {
            foreach (var x in NhanVien)
            {
                if (x.Value == cbNVBan.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }
        private string GetKhachHang()
        {
            foreach (var x in KhachHang)
            {
                if (x.Value == cbKH.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private bool ValidateDGVHoaDon()
        {
            if (cbKH.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn khách hàng!");
                return false;
            }
            if (cbNVBan.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn nhân viên bán");
                return false;
            }
            if (Regex.Replace(txtDiaChi.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền địa chỉ!");
                return false;
            }
            return true;
        }

        private void btnThemHDB_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVHoaDon())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from hoadonban where mahdb = '{txtMaHDB.Text}'"))
            {
                MessageBox.Show("Đã có mã hoá đơn bán này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"insert hoadonban(mahdb, ngayban, manv, makh, tongtien) values ('{txtMaHDB.Text}', '{txtNgayBan.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{GetNhanVien()}', '{GetKhachHang()}', {lbTongTien.Text})");
            MessageBox.Show("Thêm hoá đơn thành công!");
            ReloadDatabase();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHDB.ReadOnly = false;
            txtMaHDB.Text = "";
            cbKH.Text = null;
            txtDiaChi.Text = "";
            txtNgayBan.Value = DateTime.Now;
            cbNVBan.Text = null;
            dgvHoaDon.DataSource = null;
            dgvSanPham.ClearSelection();
            dgvHoaDon.DataSource = null;
            txtTenSP.Text = "";
            txtKhuyenMai.Text = "";
            txtSLMua.Text = "";
            lbTongTien.Text = "0";
        }

        private void btnSuaHDB_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVHoaDon())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from hoadonban where mahdb = '{txtMaHDB.Text}'"))
            {
                MessageBox.Show("Chưa có mã hoá đơn bán này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"update hoadonban set ngayban = '{txtNgayBan.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', manv = '{GetNhanVien()}', makh = '{GetKhachHang()}', tongtien = {lbTongTien.Text} where mahdb = '{txtMaHDB.Text}'");
            MessageBox.Show("Sửa thông tin hoá đơn thành công!");
            ReloadDatabase();
        }

        private void btnXoaHDB_Click(object sender, EventArgs e)
        {
            if (!processDatabase.IsInTable($"select * from hoadonban where mahdb = '{txtMaHDB.Text}'"))
            {
                MessageBox.Show("Không có mã hoá đơn bán này trong database!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá hoá đơn này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                processDatabase.ThiHanhLenh($"delete from chitiethdb where mahdb = '{txtMaHDB.Text}'");
                processDatabase.ThiHanhLenh($"delete from hoadonban where mahdb = '{txtMaHDB.Text}'");
                MessageBox.Show("Xoá hoá đơn thành công!");
                btnLamMoi.PerformClick();
            }
        }

        private void cbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKH.SelectedIndex >= 0)
            {
                DataTable dt = processDatabase.DocBang($"select diachi from khachhang where makh = '{GetKhachHang()}'");
                txtDiaChi.Text = dt.Rows[0][0].ToString();
                txtDiaChi.ReadOnly = true;
            }
        }
    }
}
