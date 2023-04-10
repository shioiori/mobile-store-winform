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
    public partial class MuaHang : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> Loai = new Dictionary<string, string>();
        Dictionary<string, string> NhanHieu = new Dictionary<string, string>();
        Dictionary<string, string> ManHinh = new Dictionary<string, string>();
        Dictionary<string, string> SanPham = new Dictionary<string, string>();
        public MuaHang()
        {
            InitializeComponent();
        }

        private void ReloadDatabase()
        {
            dgvDSSP.DataSource = processDatabase.DocBang("select TenSP, TenLoai, TenNhanHieu, GiaBan, SoLuong, TGBH, TenManHinh, AmThanh, ChupAnh, Anh from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh");
            dgvDSSP.ClearSelection();
        }

        private void MuaHang_Load(object sender, EventArgs e)
        {
            ReloadDatabase();
            DataTable dtLoai = processDatabase.DocBang("select * from Loai");
            foreach (DataRow dr in dtLoai.Rows)
            {
                cbLoaiSP.Items.Add(dr["TenLoai"].ToString());
                Loai[dr["MaLoai"].ToString()] = dr["TenLoai"].ToString();
            }
            DataTable dtNhanHieu = processDatabase.DocBang("select * from NhanHieu");
            foreach (DataRow dr in dtNhanHieu.Rows)
            {
                cbNhanHieu.Items.Add(dr["TenNhanHieu"].ToString());
                NhanHieu[dr["MaNhanHieu"].ToString()] = dr["TenNhanHieu"].ToString();
            }
            DataTable dtManHinh = processDatabase.DocBang("select * from ManHinh");
            foreach (DataRow dr in dtManHinh.Rows)
            {
                cbTenMH.Items.Add(dr["TenManHinh"].ToString());
                ManHinh[dr["MaManHinh"].ToString()] = dr["TenManHinh"].ToString();
            }
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
            if (Int32.Parse(txtSL.Text) > Int32.Parse(dgvDSSP.SelectedRows[0].Cells[4].Value.ToString()))
            {
                MessageBox.Show("Số lượng mua vượt quá số lượng tồn kho!");
                return false;
            }
            return true;
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSP.Text = dgvDSSP.SelectedRows[0].Cells[0].Value.ToString();
            DataTable dt = processDatabase.DocBang($"select * from sanpham where masp = '{GetSanPham()}'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm này trong database!");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtTenSP.Text = dr["TenSP"].ToString();
                    txtGiaBan.Text = dr["GiaBan"].ToString();
                    cbLoaiSP.Text = Loai[dr["MaLoai"].ToString()];
                    cbNhanHieu.Text = NhanHieu[dr["MaNhanHieu"].ToString()];
                    cbTenMH.Text = ManHinh[dr["MaManHinh"].ToString()];
                    txtAmThanh.Text = dr["AmThanh"].ToString();
                    txtTGBH.Text = dr["TGBH"].ToString();
                    if ((bool)dr["ChupAnh"])
                    {
                        rdbTrue.Checked = true;
                    }
                    else
                    {
                        rdbFalse.Checked = true;
                    }
                    string fname = dr["Anh"].ToString();
                    try
                    {
                        string serverPath = AppDomain.CurrentDomain.BaseDirectory;
                        string destinationPath = serverPath.Substring(0, serverPath.Length - 10) + "Resources\\images\\";
                        pbAnh.Image = Image.FromFile(destinationPath + fname);
                        pbAnh.Tag = fname;
                    }
                    catch (Exception ex) { }
                }
            }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from giohang where makh = '{UserInfo.id}' and masp = '{GetSanPham()}'"))
            {
                MessageBox.Show("Sản phẩm này đã có trong giỏ hàng!");
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn thêm {txtSL.Text} sản phẩm {txtTenSP.Text} vào giỏ hàng không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                processDatabase.ThiHanhLenh($"INSERT dbo.GioHang(MaKH, MaSP, SLMua) VALUES ('{UserInfo.id}','{GetSanPham()}', {txtSL.Text})");
                MessageBox.Show("Thêm sản phẩm vào giỏ hàng thành công!");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            var frm = (TrangChu)this.Owner;
            if (frm != null)
                frm.ThanhToan();
        }
    }
}
