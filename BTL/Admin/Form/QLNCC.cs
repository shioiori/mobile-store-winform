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
    public partial class QLNCC : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        Dictionary<string, string> TT = new Dictionary<string, string>();
        public QLNCC()
        {
            InitializeComponent();
        }

        private void ReloadDatabaseNCC()
        {
            dgvNCC.DataSource = processDatabase.DocBang("SELECT * FROM dbo.NhaCungCap");
            dgvNCC.ClearSelection();
        }

        private void ReloadDatabaseTT(string name)
        {
            dgvTT.DataSource = processDatabase.DocBang($"select * from {name}");
            dgvTT.ClearSelection();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            txtMaNCC.ReadOnly = false;
            DataTable dt = processDatabase.DocBang($"SELECT * FROM dbo.NhaCungCap where mancc = '{txtMaNCC.Text}'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có nhà cung cấp này trong database!");
            }
            else
            {
                ReloadDatabaseNCC();
                foreach (DataRow dr in dt.Rows)
                {
                    txtTenNCC.Text = dr["TenNCC"].ToString();
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                    txtSDT.Text = dr["SDT"].ToString();                }
            }
        }

        private void QLNCC_Load(object sender, EventArgs e)
        {
            cbType.Items.Add("Loại");
            cbType.Items.Add("Màn hình");
            cbType.Items.Add("Nhãn hiệu");
            TT["Loại"] = "Loai";
            TT["Màn hình"] = "ManHinh";
            TT["Nhãn hiệu"] = "NhanHieu";
            cbType.Text = "Loại";
            ReloadDatabaseTT(TT["Loại"]);
            ReloadDatabaseNCC();
        }

        private void btnTaoMaNCC_Click(object sender, EventArgs e)
        {
            txtMaNCC.ReadOnly = true;
            txtMaNCC.Text = processDatabase.Function("select dbo.sinhkhoamaNCC()");
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            dgvNCC.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.ReadOnly = true;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            dgvNCC.ClearSelection();
            dgvTT.ClearSelection();
        }
        private bool ValidateDGVNCC()
        {
            if (Regex.Replace(txtMaNCC.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa sinh mã nhà cung cấp mới!");
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
            if (!Regex.IsMatch(txtSDT.Text, "^[0-9]*[1-9][0-9]*$"))
            {
                MessageBox.Show("Số điện thoại chỉ có thể bao gồm các số!");
                return false;
            }
            return true;
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVNCC())
            {
                return;
            }
            if (processDatabase.IsInTable($"select * from nhacungcap where mancc = '{txtMaNCC.Text}'"))
            {
                MessageBox.Show("Đã có nhân viên này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"insert nhacungcap(mancc, tenncc, diachi, sdt) values ('{txtMaNCC.Text}', N'{txtTenNCC.Text}', N'{txtDiaChi.Text}', '{txtSDT.Text}')");
            MessageBox.Show("Thêm nhà cung cấp thành công!");
            ReloadDatabaseNCC();
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVNCC())
            {
                return;
            }
            if (!processDatabase.IsInTable($"select * from nhacungcap where mancc = '{txtMaNCC.Text}'"))
            {
                MessageBox.Show("Chưa có nhà cung cấp này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"update nhacungcap set tenncc = N'{txtTenNCC.Text}', diachi = N'{txtDiaChi.Text}', sdt = '{txtSDT.Text}' where mancc = '{txtMaNCC.Text}'");
            MessageBox.Show("Sửa thông tin nhân viên thành công!");
            ReloadDatabaseNCC();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (!processDatabase.IsInTable($"select * from nhacungcap where mancc = '{txtMaNCC.Text}'"))
            {
                MessageBox.Show("Chưa có nhà cung cấp này trong database!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá nhà cung cấp này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    processDatabase.ThiHanhLenh($"delete from nhacungcap where mancc = '{txtMaNCC.Text}'");
                    MessageBox.Show("Xoá nhà cung cấp thành công!");
                    txtMaNCC.Text = "";
                    txtTenNCC.Text = "";
                    txtSDT.Text = "";
                    txtDiaChi.Text = "";
                    ReloadDatabaseNCC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn không thể xoá nhà cung cấp này do nhà cung cấp vẫn còn xuất hiện trong các hoá đơn khác. Để xoá nhà cung cấp này, hãy xử lý các hoá đơn nhập được cung cấp bởi nhà cung cấp đó.");
                }
            }
        }

        private bool ValidateDGVTT()
        {
            if (cbType.Text == null)
            {
                MessageBox.Show("Chưa chọn thông tin cần xử lý!");
                return false;
            }
            if (Regex.Replace(txtId.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền mã!");
                return false;
            }
            if (Regex.Replace(txtName.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền tên!");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVTT())
            {
                return;
            }
            string x = TT[cbType.Text];
            if (processDatabase.IsInTable($"select * from {x} where ma{x} = '{txtId.Text}'"))
            {
                MessageBox.Show("Đã có mã này trong database!");
                return;
            }
            processDatabase.ThiHanhLenh($"insert {x}(ma{x}, ten{x}) values ('{txtId.Text}', N'{txtName.Text}')");
            MessageBox.Show("Thêm mã thành công!");
            ReloadDatabaseTT(x);
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dgvNCC.SelectedRows[0].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNCC.SelectedRows[0].Cells[1].Value.ToString();
            txtSDT.Text = dgvNCC.SelectedRows[0].Cells[3].Value.ToString(); ;
            txtDiaChi.Text = dgvNCC.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateDGVTT())
            {
                return;
            }
            string x = TT[cbType.Text];
            if (!processDatabase.IsInTable($"select * from {x} where ma{x} = '{txtId.Text}'"))
            {
                MessageBox.Show("Chưa có mã này trong database!");
                return;
            }
            
            processDatabase.ThiHanhLenh($"update {x} set ten{x} = N'{txtName.Text}' where ma{x} = '{txtId.Text}'");
            MessageBox.Show("Sửa thông tin mã thành công!");
            ReloadDatabaseTT(x);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Regex.Replace(txtId.Text, @"\s+", "") == "")
            {
                MessageBox.Show("Chưa điền mã!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá mã này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string x = TT[cbType.Text];
                    processDatabase.ThiHanhLenh($"delete from {x} where ma{x} = '{txtId.Text}'");
                    MessageBox.Show("Xoá mã thành công!");
                    ReloadDatabaseTT(x);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn chưa thể xoá mã này do có những sản phẩm đang chứa thông tin của mã này.");
                }
            }
        }

        private void dgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvTT.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dgvTT.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    ReloadDatabaseTT(TT["Loại"]);
                    break;
                case 1:
                    ReloadDatabaseTT(TT["Màn hình"]);
                    break;
                case 2:
                    ReloadDatabaseTT(TT["Nhãn hiệu"]);
                    break;
            }
        }
    }
}
