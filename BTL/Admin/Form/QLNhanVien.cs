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

namespace BTL.Admin
{
    public partial class QLNhanVien : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> Que = new Dictionary<string, string>();
        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void ReloadDatabaseNV()
        {
            dgvNhanVien.DataSource = processDatabase.DocBang("SELECT MaNV, TenNV, DiaChi, GioiTinh, NgaySinh, TenQue, SDT FROM dbo.NhanVien JOIN dbo.Que ON Que.MaQue = NhanVien.MaQue");
            dgvNhanVien.ClearSelection();
        }

        private void ReloadDatabaseQue()
        {
            dgvQue.DataSource = processDatabase.DocBang("select * from que");
            dgvQue.ClearSelection();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = false;
            DataTable dt = processDatabase.DocBang($"select * FROM dbo.NhanVien JOIN dbo.Que ON Que.MaQue = NhanVien.MaQue WHERE manv = '{txtMaNV.Text}'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có nhân viên này trong database!");
            }
            else
            {
                ReloadDatabaseNV();
                foreach (DataRow dr in dt.Rows)
                {
                    txtTenNV.Text = dr["TenNV"].ToString();
                    if (dr["GioiTinh"].ToString() == "True")
                    {
                        rdbNam.Checked = true;
                    }
                    else
                    {
                        rdbNu.Checked = true;
                    }
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                    txtNgaySinh.Text = dr["NgaySinh"].ToString();
                    cbQue.Text = dr["TenQue"].ToString();
                }
            }
        }

        private string GetQue()
        {
            foreach (var x in Que)
            {
                if (x.Value == cbQue.Text)
                {
                    return x.Key;
                }
            }
            return "";
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            ReloadDatabaseNV();
            ReloadDatabaseQue();
            DataTable dtKH = processDatabase.DocBang("select * from Que");
            foreach (DataRow dr in dtKH.Rows)
            {
                cbQue.Items.Add(dr["TenQue"].ToString());
                Que[dr["MaQue"].ToString()] = dr["TenQue"].ToString();
            }
        }

        private void btnTaoMaNV_Click(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = true;
            txtMaNV.Text = processDatabase.Function("select dbo.sinhkhoamaNV()");
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtNgaySinh.Value = DateTime.Now;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            cbQue.Text = null;
            dgvNhanVien.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtNgaySinh.Value = DateTime.Now;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            cbQue.Text = null;
            txtMaQue.Text = "";
            txtTenQue.Text = "";
            dgvNhanVien.ClearSelection();
            dgvQue.ClearSelection();
        }
        private bool ValidateDGVNhanVien()
        {
            if (Regex.Replace(txtMaNV.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa sinh mã nhân viên mới!");
            }
            if (cbQue.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn quê!");
                return false;
            }
            if (Regex.Replace(txtDiaChi.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền địa chỉ!");
                return false;
            }
            if (Regex.Replace(txtSDT.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền số điện thoại!");
                return false;
            }
            if (Regex.Replace(txtTenNV.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền tên nhân viên!");
                return false;
            }
            if (!rdbNam.Checked && !rdbNu.Checked)
            {
                MessageBox.Show("Chưa chọn giới tính!");
                return false;
            }
            if (!Regex.IsMatch(txtSDT.Text, "^[0-9]*[1-9][0-9]*$"))
            {
                MessageBox.Show("Số điện thoại chỉ có thể bao gồm các số!");
                return false;
            }
            return true;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVNhanVien())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from nhanvien where manv = '{txtMaNV.Text}'"))
            {
                MessageBox.Show("Đã có nhân viên này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"insert nhanvien(manv, tennv, diachi, gioitinh, ngaysinh, maque, sdt) values ('{txtMaNV.Text}', N'{txtTenNV.Text}', N'{txtDiaChi.Text}', {(rdbNam.Checked == true ? 1 : 0)}, '{txtNgaySinh.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{GetQue()}', '{txtSDT.Text}')");
            MessageBox.Show("Thêm nhân viên thành công!");
            ReloadDatabaseNV();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVNhanVien())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from nhanvien where manv = '{txtMaNV.Text}'"))
            {
                MessageBox.Show("Chưa có nhân viên này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"update nhanvien set tennv = N'{txtTenNV.Text}', diachi = N'{txtDiaChi.Text}', gioitinh = {(rdbNam.Checked == true ? 1 : 0)}, ngaysinh = '{txtNgaySinh.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', maque = '{GetQue()}', sdt = '{txtSDT.Text}' where manv = '{txtMaNV.Text}'");
            MessageBox.Show("Sửa thông tin nhân viên thành công!");
            ReloadDatabaseNV();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (!processDatabase.IsInTable($"select * from nhanvien where manv = '{txtMaNV.Text}'"))
            {
                MessageBox.Show("Chưa có nhân viên này trong database!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    processDatabase.ThiHanhLenh($"delete from nhanvien where manv = '{txtMaNV.Text}'");
                    MessageBox.Show("Xoá nhân viên thành công!");
                    txtMaNV.Text = "";
                    txtTenNV.Text = "";
                    txtSDT.Text = "";
                    txtDiaChi.Text = "";
                    txtNgaySinh.Value = DateTime.Now;
                    rdbNam.Checked = false;
                    rdbNu.Checked = false;
                    cbQue.Text = null;
                    ReloadDatabaseNV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn không thể xoá nhân viên này do nhân viên vẫn còn xuất hiện trong các hoá đơn khác. Để xoá nhân viên này, hãy xử lý các hoá đơn do nhân viên đó xử lý.");
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString();
            txtSDT.Text = dgvNhanVien.SelectedRows[0].Cells[6].Value.ToString(); ;
            txtDiaChi.Text = dgvNhanVien.SelectedRows[0].Cells[2].Value.ToString(); 
            txtNgaySinh.Value = (DateTime)dgvNhanVien.SelectedRows[0].Cells[4].Value;
            if (dgvNhanVien.SelectedRows[0].Cells[3].Value.ToString() == "True")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
            cbQue.Text = dgvNhanVien.SelectedRows[0].Cells[5].Value.ToString(); 
        }

        private bool ValidateDGVQue()
        {
            if (Regex.Replace(txtMaQue.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền mã quê!");
                return false;
            }
            if (Regex.Replace(txtTenQue.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền tên quê!");
                return false;
            }
            return true;
        }

        private void btnThemQue_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVQue())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from que where maque = '{txtMaQue.Text}'"))
            {
                MessageBox.Show("Đã có mã quê này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"insert que(maque, tenque) values ('{txtMaQue.Text}', N'{txtTenQue.Text}'");
            Que[txtMaQue.Text] = txtTenQue.Text;
            cbQue.Items.Add(txtTenQue.Text);
            MessageBox.Show("Thêm mã quê thành công!");
            ReloadDatabaseQue();
        }

        private void btnSuaQue_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVQue())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from que where maque = '{txtMaQue.Text}'"))
            {
                MessageBox.Show("Chưa có mã quê này trong database!");
                return;
            }
            int index = cbQue.Items.IndexOf(Que[txtMaQue.Text]);
            cbQue.Items[index] = txtTenQue.Text;
            Que[txtMaQue.Text] = txtTenQue.Text;
            processDatabase.ThiHanhLenh($"update que set tenque = N'{txtTenQue.Text}' where maque = '{txtMaQue.Text}'");
            MessageBox.Show("Sửa thông tin mã quê thành công!");
            ReloadDatabaseQue();
        }

        private void btnXoaQue_Click(object sender, EventArgs e)
        {
            if (Regex.Replace(txtMaQue.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền mã quê!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá mã quê này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    processDatabase.ThiHanhLenh($"delete from que where maque = '{txtMaQue.Text}'");
                    MessageBox.Show("Xoá mã quê thành công!");
                    ReloadDatabaseQue();
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn chưa thể xoá mã quê này do có những nhân viên đang có quê quán thuộc mã quê này.");
                }
            }


        }

        private void dgvQue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaQue.Text = dgvQue.SelectedRows[0].Cells[0].Value.ToString();
            txtTenQue.Text = dgvQue.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
