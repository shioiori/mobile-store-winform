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
    public partial class DangNhap : Form
    {
        ProcessDatabase processDatabase = new ProcessDatabase();
        public static DangNhap Instance = null;
        public DangNhap()
        {
            InitializeComponent();
            DangNhap.Instance = this;
            txtMatKhau.PasswordChar = '*';
        }
        private bool ValidateForm()
        {
            if (Regex.Replace(txtMatKhau.Text, @"\s+", "") == "" || Regex.Replace(txtTenDN.Text, @"\s+", "") == "")
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin!", "Thông báo");
                return;
            }
            string str;
            processDatabase.SetConnection("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=DIENTHOAI;Integrated Security=True");
            DataTable dt = processDatabase.DocBang($"select * from dbo.[User] where taikhoan = '{txtTenDN.Text}' and matkhau = '{txtMatKhau.Text}'");
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Không có người này trong hệ thống!");
                return;
            }
            else
            {
                if (dt.Rows[0][5].ToString() == "khách hàng")
                {
                    UserInfo.per = dt.Rows[0][5].ToString();
                    UserInfo.id = dt.Rows[0][4].ToString();
                    DataTable tbname = processDatabase.DocBang($"select tenkhach from khachhang where makh = '{UserInfo.id}'");
                    UserInfo.name = tbname.Rows[0][0].ToString();
                }
                else if (dt.Rows[0][5].ToString() == "nhân viên")
                {
                    UserInfo.per = dt.Rows[0][5].ToString();
                    UserInfo.id = dt.Rows[0][3].ToString();
                    DataTable tbname = processDatabase.DocBang($"select tennv from nhanvien where manv = '{UserInfo.id}'");
                    UserInfo.name = tbname.Rows[0][0].ToString();
                }
                else
                {
                    UserInfo.per = dt.Rows[0][5].ToString();
                    UserInfo.name = "Admin";
                }
                TrangChu mainform = new TrangChu();
                mainform.Show();
                this.Hide();
            }
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
