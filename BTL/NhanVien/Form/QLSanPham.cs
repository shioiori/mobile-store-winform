using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.IO;

namespace BTL
{
    public partial class QLSanPham : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> Loai = new Dictionary<string, string>();
        Dictionary<string, string> NhanHieu = new Dictionary<string, string>();
        Dictionary<string, string> ManHinh = new Dictionary<string, string>();
        public QLSanPham()
        {
            InitializeComponent();
        }

        private void ReloadDatabase()
        {
            dgvDSSP.DataSource = processDatabase.DocBang("select MaSP, TenSP, TenLoai, TenNhanHieu, GiaNhap, GiaBan, SoLuong, TGBH, TenManHinh, AmThanh, ChupAnh, Anh from sanpham join loai on sanpham.maloai = loai.maloai join nhanhieu on sanpham.manhanhieu = nhanhieu.manhanhieu join manhinh on sanpham.mamanhinh = manhinh.mamanhinh");
            dgvDSSP.ClearSelection();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = "Nhập mã sản phẩm...";
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
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSP_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMaSP.Text == "Nhập mã sản phẩm...")
            {
                txtMaSP.Text = "";
            }
        }

        private void btnGenMaSP_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = true;
            txtMaSP.Text = processDatabase.Function("select dbo.sinhkhoamasp()");
        }


        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Chưa sinh mã sản phẩm mới!");
            }
            DataTable dt = processDatabase.DocBang($"select * from sanpham where masp = '{txtMaSP.Text}'");
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
                    txtGiaNhap.Text = dr["GiaNhap"].ToString();
                    cbLoaiSP.Text = Loai[dr["MaLoai"].ToString()];
                    cbNhanHieu.Text = NhanHieu[dr["MaNhanHieu"].ToString()];
                    cbTenMH.Text = ManHinh[dr["MaManHinh"].ToString()];
                    txtAmThanh.Text = dr["AmThanh"].ToString();
                    txtTGBH.Text = dr["TGBH"].ToString();
                    txtSL.Text = dr["SoLuong"].ToString();
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

        private string GetLoai()
        {
            foreach (var x in Loai)
            {
                if (x.Value == cbLoaiSP.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private string GetNhanHieu()
        {
            foreach (var x in NhanHieu)
            {
                if (x.Value == cbNhanHieu.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private string GetManHinh()
        {
            foreach (var x in ManHinh)
            {
                if (x.Value == cbTenMH.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private int GetChupAnh()
        {
            if (rdbTrue.Checked)
            {
                return 1;
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from sanpham where masp = '{txtMaSP.Text}'"))
            {
                MessageBox.Show("Sản phẩm này đã có trong database!");
                return;
            }
            else
            {
                processDatabase.ThiHanhLenh($"INSERT [dbo].[SanPham]([MaSP], [TenSP], [MaLoai], [MaNhanHieu], [GiaNhap], [GiaBan], [SoLuong], [TGBH], [MaManHinh], [AmThanh], [Anh], [ChupAnh]) VALUES ('{txtMaSP.Text}', N'{txtTenSP.Text}', N'{GetLoai()}', N'{GetNhanHieu()}',{txtGiaNhap.Text},{txtGiaBan.Text},{txtSL.Text},{txtTGBH.Text}, N'{GetManHinh()}', N'{txtAmThanh.Text}', N'{pbAnh.Tag}',{GetChupAnh()})");
                MessageBox.Show("Thêm sản phẩm thành công vào database!");
                ReloadDatabase();
            }
        }

        private string TypeImage(string path)
        {
            string x = "";
            for (int i = path.Length - 1 ; i >= 0; i--)
            {
                x += path[i];
                if (path[i] == '.')
                {
                    string y = "";
                    for (int j = x.Length - 1; j >= 0; j--)
                    {
                        y += x[j];
                    }
                    return y;
                }
                
            }
            return "";
        }

        private void pbAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog save = new OpenFileDialog();
            save.ShowDialog();
            string filename = save.FileName;
            try
            {
                string serverPath = AppDomain.CurrentDomain.BaseDirectory;
                string destinationPath = serverPath.Substring(0, serverPath.Length - 10) + "Resources\\images\\";
                string source = System.IO.Path.GetFullPath(filename);
                string fname = Guid.NewGuid().ToString() + TypeImage(source);
                System.IO.File.Copy(source, destinationPath + fname);
                pbAnh.Image = Image.FromFile(destinationPath + fname);
                pbAnh.Tag = fname;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm ảnh không thành công!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from sanpham where masp = '{txtMaSP.Text}'"))
            {
                MessageBox.Show("Sản phẩm này chưa có trong database!");
                return;
            }
            else
            {
                processDatabase.ThiHanhLenh($"UPDATE sanpham SET tensp = N'{txtTenSP.Text}', maloai = N'{GetLoai()}', manhanhieu = N'{GetNhanHieu()}', gianhap = {txtGiaNhap.Text}, giaban = {txtGiaBan.Text}, soluong = {txtSL.Text}, tgbh = {txtTGBH.Text}, mamanhinh = N'{GetManHinh()}', amthanh = N'{txtAmThanh.Text}', chupanh = {GetChupAnh()}, anh = N'{pbAnh.Tag}' WHERE masp = '{txtMaSP.Text}'");
                MessageBox.Show("Sửa sản phẩm thành công!");
                ReloadDatabase();
            }
        }

        private void dgvDSSP_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLamMoi.PerformClick();
            txtMaSP.Text = dgvDSSP.SelectedRows[0].Cells[0].Value.ToString();
            btnTraCuu.PerformClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!processDatabase.IsInTable($"select * from sanpham where masp = '{txtMaSP.Text}'"))
            {
                MessageBox.Show("Sản phẩm này chưa có trong database!");
                return;
            }
            else
            {
                processDatabase.ThiHanhLenh($"delete from sanpham where masp = '{txtMaSP.Text}'");
                MessageBox.Show("Xoá sản phẩm thành công!");
                ReloadDatabase();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            //Microsoft.Office.Interop.Excel.Application 
            Excel.Application excel;
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                //đặt tên cho sheet
                worksheet.Name = "Data";
                //export header trong DataGridView
                //Range range 
                Excel.Range TieuDe = worksheet.get_Range("A1", "F1");
                TieuDe.Merge();
                TieuDe.Font.Size = 20;
                TieuDe.Font.Bold = true;
                TieuDe.Font.Name = "Times New Roman";
                TieuDe.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                TieuDe.Value2 = "Thống kê sản phẩm";
                TieuDe.Font.Color = Color.Red;
                for (int i = 0; i < dgvDSSP.ColumnCount; i++)
                {
                    worksheet.Cells[2, i + 1] = dgvDSSP.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dgvDSSP.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvDSSP.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = dgvDSSP.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.Activate();
                SaveFileDialog saved = new SaveFileDialog();
                saved.ShowDialog();
                workbook.SaveAs(saved.FileName);
                excel.Quit();
                MessageBox.Show("Xuất file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất file thất bại!");
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private bool Validate()
        {
            if (Regex.Replace(txtTenSP.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập tên sản phẩm!");
                txtTenSP.Focus();
                return false;
            }
            if (Regex.Replace(txtGiaNhap.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập giá nhập!");
                txtGiaNhap.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtGiaNhap.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Giá nhập chỉ có thể chứa số!");
                txtGiaNhap.Focus();
                return false;
            }
            if (Regex.Replace(txtGiaBan.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập giá bán!");
                txtGiaBan.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtGiaBan.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Giá bán chỉ có thể chứa số!");
                txtGiaBan.Focus();
                return false;
            }
            if (Regex.Replace(txtSL.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập số lượng!");
                txtSL.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtSL.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Số lượng chỉ có thể chứa số!");
                txtSL.Focus();
                return false;
            }
            if (Regex.Replace(txtTGBH.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa nhập thời gian bảo hành!");
                txtTGBH.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtTGBH.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Thời gian bảo hành chỉ có thể chứa số!");
                txtTGBH.Focus();
                return false;
            }
            if (!rdbTrue.Checked && !rdbFalse.Checked)
            {
                MessageBox.Show("Chưa chọn option chụp ảnh!");
                rdbTrue.Focus();
                return false;
            }
            if (cbLoaiSP.Text == "")
            {
                MessageBox.Show("Chưa chọn loại sản phẩm!");
                cbLoaiSP.Focus();
                return false;
            }
            if (cbNhanHieu.Text == "")
            {
                MessageBox.Show("Chưa chọn nhãn hiệu!");
                cbNhanHieu.Focus();
                return false;
            }
            if (cbTenMH.Text == "")
            {
                MessageBox.Show("Chưa chọn tên màn hình!");
                cbTenMH.Focus();
                return false;
            }
            return true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            cbLoaiSP.Text = "";
            cbNhanHieu.Text = "";
            cbTenMH.Text = "";
            txtAmThanh.Text = "";
            txtTGBH.Text = "";
            txtSL.Text = "";
            pbAnh.Image = null;
            rdbFalse.Checked = false;
            rdbTrue.Checked = false;
            cbLoaiSP.SelectedItem = null;
            cbNhanHieu.SelectedItem = null;
            cbTenMH.SelectedItem = null;
            
        }
    }
}
