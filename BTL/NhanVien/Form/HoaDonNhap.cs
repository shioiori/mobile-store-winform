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
    public partial class HoaDonNhap : Form
    {
        public ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> NhanVien = new Dictionary<string, string>();
        Dictionary<string, string> NCC = new Dictionary<string, string>();
        public HoaDonNhap()
        {
            InitializeComponent();
        }

        private void ReloadDatabase()
        {
            dgvHoaDon.DataSource = processDatabase.DocBang($"select ChiTietHDN.MaSP, TenSP, TenLoai, TenNhanHieu, GiaNhap, ChiTietHDN.SoLuong, KhuyenMai, ThanhTien from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh JOIN dbo.ChiTietHDN ON ChiTietHDN.MaSP = SanPham.MaSP JOIN dbo.HoaDonNhap ON HoaDonNhap.MaHDN = ChiTietHDN.MaHDN WHERE HoaDonNhap.MaHDN = '{txtMaHDN.Text}'");
            dgvHoaDon.ClearSelection();
            processDatabase.ThiHanhLenh($"update hoadonNhap set tongtien = {lbTongTien.Text} where maHDN = '{txtMaHDN.Text}'");
            dgvSanPham.DataSource = processDatabase.DocBang("select MaSP, TenSP, TenLoai, TenNhanHieu, SoLuong, TGBH from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh");
            dgvSanPham.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaHDN.ReadOnly = false;
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Chưa sinh mã hoá đơn mới!");
            }
            DataTable dt = processDatabase.DocBang($"SELECT TenNCC, NhaCungCap.DiaChi, NhaCungCap.SDT, NgayNhap, TenNV FROM dbo.HoaDonNhap JOIN dbo.NhaCungCap ON dbo.NhaCungCap.MaNCC = HoaDonNhap.MaNCC JOIN dbo.NhanVien ON NhanVien.MaNV = HoaDonNhap.MaNV  WHERE HoaDonNhap.MaHDN = '{txtMaHDN.Text}'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có hoá đơn này trong database!");
            }
            else
            {
                ReloadDatabase();
                DataTable dtHDN = dgvHoaDon.DataSource as DataTable;
                TinhTongTien();
                foreach (DataRow dr in dt.Rows)
                {
                    cbNCC.Text = dr["TenNCC"].ToString();
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                    txtNgayNhap.Value = (DateTime)dr["NgayNhap"];
                    txtSDT.Text = dr["SDT"].ToString();
                    cbNVNhap.Text = dr["TenNV"].ToString();
                }
            }
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
            if (!processDatabase.Find(cbNVNhap.Text))
            {
                MessageBox.Show("Không có nhân viên này trong database!");
                return false;
            }
            return true;
        }

        private void HoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = processDatabase.DocBang("select MaSP, TenSP, TenLoai, TenNhanHieu, SoLuong, TGBH from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh");
            txtMaHDN.Text = "Nhập mã hoá đơn...";
            DataTable dtNV = processDatabase.DocBang("select * from NhanVien");
            foreach (DataRow dr in dtNV.Rows)
            {
                cbNVNhap.Items.Add(dr["TenNV"].ToString());
                NhanVien[dr["MaNV"].ToString()] = dr["TenNV"].ToString();
            }
            DataTable dtKH = processDatabase.DocBang("select * from NhaCungCap");
            foreach (DataRow dr in dtKH.Rows)
            {
                cbNCC.Items.Add(dr["TenNCC"].ToString());
                NCC[dr["MaNCC"].ToString()] = dr["TenNCC"].ToString();
            }
            dgvSanPham.ClearSelection();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtMaHDN.ReadOnly = true;
            txtMaHDN.Text = processDatabase.Function("select dbo.sinhkhoamaHDN()");
            cbNCC.Text = null;
            txtDiaChi.Text = "";
            txtNgayNhap.Value = DateTime.Now;
            cbNVNhap.Text = null;
            txtSDT.Text = "";
            dgvHoaDon.DataSource = null;
            dgvSanPham.ClearSelection();
        }

        private void TinhTongTien()
        {
            DataTable dtHDN = dgvHoaDon.DataSource as DataTable;
            decimal sum = 0;
            foreach (DataRow dr in dtHDN.Rows)
            {
                decimal tt = Decimal.Parse(dr["ThanhTien"].ToString());
                sum += tt;

            }
            lbTongTien.Text = sum.ToString();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSP.Text = dgvSanPham.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.DataSource == null)
            {
                MessageBox.Show("Hãy thêm mới hoặc chọn hoá đơn nhập đã tồn tại!");
                return;
            }
            if (!processDatabase.IsInTable($"select * from chitietHDN where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}' and maHDN = '{txtMaHDN.Text}'"))
            {
                MessageBox.Show("Sản phẩm này chưa có trong hoá đơn!");
                return;
            }
            else
            {
                processDatabase.ThiHanhLenh($"delete from chitietHDN where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}' and maHDN = '{txtMaHDN.Text}'");
                MessageBox.Show("Xoá sản phẩm thành công!");
                ReloadDatabase();
                TinhTongTien();
                txtKhuyenMai.Text = "";
                txtGiaNhap.Text = "";
                txtSLNhap.Text = "";
                txtTenSP.Text = "";
            }
        }

        private void txtMaHDN_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMaHDN.Text == "Nhập mã hoá đơn...")
            {
                txtMaHDN.Text = "";
            }
        }

        private bool ValidateDGVSanPham()
        {
            if (Regex.Replace(txtTenSP.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa chọn sản phẩm!");
                return false;
            }
            if (Regex.Replace(txtSLNhap.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập số lượng mua!");
                return false;
            }
            if (Regex.Replace(txtKhuyenMai.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập phần trăm khuyến mãi!");
                return false;
            }
            if (Regex.Replace(txtGiaNhap.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập giá nhập sản phẩm!");
                return false;
            }
            if (!Regex.IsMatch(txtSLNhap.Text, "^[0-9]*[1-9][0-9]*$"))
            {
                MessageBox.Show("Số lượng mua chỉ có thể chứa số dương!");
                return false;
            }
            if (!Regex.IsMatch(txtGiaNhap.Text, "^[0-9]*[1-9][0-9]*$"))
            {
                MessageBox.Show("Giá nhập chỉ có thể chứa số dương!");
                return false;
            }
            if (!Regex.IsMatch(txtSLNhap.Text, "^\\d{1,5}$|(?=^.{1,5}$)^\\d+\\.\\d{0,2}$"))
            {
                MessageBox.Show("Khuyến mãi chỉ có thể là kiểu số thực");
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
                MessageBox.Show("Hãy thêm mới hoặc chọn hoá đơn nhập đã tồn tại!");
                return;
            }
            if (!ValidateDGVSanPham())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from chitietHDN where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}' and maHDN = '{txtMaHDN.Text}'"))
            {
                MessageBox.Show("Đã có sản phẩm này trong hoá đơn!");
                return;
            }
            decimal tt = (Decimal.Parse(txtSLNhap.Text) * Decimal.Parse(dgvHoaDon.SelectedRows[0].Cells[4].Value.ToString())) / 100 * (100 - Decimal.Parse(txtKhuyenMai.Text));
            processDatabase.ThiHanhLenh($"INSERT dbo.ChiTietHDN (MaHDN, MaSP, SoLuong, DonGia, ThanhTien, KhuyenMai) VALUES ('{txtMaHDN.Text}', '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}', {txtSLNhap.Text},  {txtGiaNhap.Text}, {tt}, {txtKhuyenMai.Text})");
            processDatabase.ThiHanhLenh($"update sanpham set gianhap = {txtGiaNhap.Text} where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}'");
            MessageBox.Show("Thêm sản phẩm vào đơn hàng thành công!");
            ReloadDatabase();
            TinhTongTien();
        }



        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.DataSource == null)
            {
                MessageBox.Show("Hãy thêm mới hoặc chọn hoá đơn nhập đã tồn tại!");
                return;
            }
            if (!ValidateDGVSanPham())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from chitietHDN where maHDN = '{txtMaHDN.Text}' and masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}'"))
            {
                MessageBox.Show("Sản phẩm không có trong hoá đơn!");
                return;
            }
            decimal tt = (Decimal.Parse(txtSLNhap.Text) * Decimal.Parse(txtGiaNhap.Text)) / 100 * (100 - Decimal.Parse(txtKhuyenMai.Text));
            processDatabase.ThiHanhLenh($"update chitietHDN set soluong = {txtSLNhap.Text}, dongia = {txtGiaNhap.Text}, khuyenmai = {txtKhuyenMai.Text}, thanhtien = {tt} where maHDN = '{txtMaHDN.Text}' and masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}'");
            processDatabase.ThiHanhLenh($"update sanpham set gianhap = {txtGiaNhap.Text} where masp = '{dgvSanPham.SelectedRows[0].Cells[0].Value.ToString()}'");
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
                        txtGiaNhap.Text = dgvSanPham.SelectedRows[0].Cells[4].Value.ToString();
                        txtKhuyenMai.Text = dgvHoaDon.SelectedRows[0].Cells[6].Value.ToString();
                        txtSLNhap.Text = dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString();
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
                if (x.Value == cbNVNhap.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }
        private string GetNCC()
        {
            foreach (var x in NCC)
            {
                if (x.Value == cbNCC.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private bool ValidateDGVHoaDon()
        {
            if (cbNCC.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn nhà cung cấp!");
                return false;
            }
            if (cbNVNhap.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn nhân viên nhập");
                return false;
            }
            return true;
        }

        private void btnThemHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVHoaDon())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from hoadonNhap where maHDN = '{txtMaHDN.Text}'"))
            {
                MessageBox.Show("Đã có mã hoá đơn nhập này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"insert hoadonNhap(maHDN, ngayNhap, manv, MaNCC, tongtien) values ('{txtMaHDN.Text}', '{txtNgayNhap.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{GetNhanVien()}', '{GetNCC()}', {lbTongTien.Text})");
            MessageBox.Show("Thêm hoá đơn thành công!");
            ReloadDatabase();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHDN.ReadOnly = false;
            txtMaHDN.Text = "";
            cbNCC.Text = null;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtNgayNhap.Value = DateTime.Now;
            cbNVNhap.Text = null;
            dgvHoaDon.DataSource = null;
            dgvSanPham.ClearSelection();
            dgvHoaDon.DataSource = null;
            txtTenSP.Text = "";
            txtKhuyenMai.Text = "";
            txtSLNhap.Text = "";
            lbTongTien.Text = "0";
            txtGiaNhap.Text = "";
        }

        private void btnSuaHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVHoaDon())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from hoadonNhap where maHDN = '{txtMaHDN.Text}'"))
            {
                MessageBox.Show("Chưa có mã hoá đơn nhập này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"update hoadonNhap set ngayNhap = '{txtNgayNhap.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', manv = '{GetNhanVien()}', MaNCC = '{GetNCC()}', tongtien = {lbTongTien.Text} where maHDN = '{txtMaHDN.Text}'");
            MessageBox.Show("Sửa thông tin hoá đơn thành công!");
        }

        private void btnXoaHDN_Click(object sender, EventArgs e)
        {
            if (!processDatabase.IsInTable($"select * from hoadonNhap where maHDN = '{txtMaHDN.Text}'"))
            {
                MessageBox.Show("Không có mã hoá đơn nhập này trong database!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá hoá đơn này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                processDatabase.ThiHanhLenh($"delete from chitietHDN where maHDN = '{txtMaHDN.Text}'");
                processDatabase.ThiHanhLenh($"delete from hoadonNhap where maHDN = '{txtMaHDN.Text}'");
                MessageBox.Show("Xoá hoá đơn thành công!");
                btnLamMoi.PerformClick();
            }
        }

        private void cbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNCC.SelectedIndex >= 0)
            {
                DataTable dt = processDatabase.DocBang($"select diachi, sdt from NhaCungCap where MaNCC = '{GetNCC()}'");
                txtDiaChi.Text = dt.Rows[0][0].ToString();
                txtDiaChi.ReadOnly = true;
                txtSDT.Text = dt.Rows[0][1].ToString();
                txtSDT.ReadOnly = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVHoaDon())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from hoadonNhap where maHDN = '{txtMaHDN.Text}'"))
            {
                MessageBox.Show("Chưa có mã hoá đơn nhập này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"update hoadonNhap set ngayNhap = '{txtNgayNhap.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', manv = '{GetNhanVien()}', MaNCC = '{GetNCC()}', tongtien = {lbTongTien.Text} where maHDN = '{txtMaHDN.Text}'");
            MessageBox.Show("Lưu thông tin hoá đơn thành công!");
        }
    }
}
