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

namespace BTL
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        public HoaDon(string KH, string DiaChi, string NgayBan, string KhuyenMai, DataGridView HoaDon)
        {
            InitializeComponent();
            lbKH.Text = KH;
            lbDiaChi.Text = DiaChi; 
            lbNgayBan.Text = NgayBan;
            lbKhuyenMai.Text = KhuyenMai;
            dgvListSP = HoaDon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                // export header trong DataGridView
                //Range range 
                Excel.Range TieuDe = worksheet.get_Range("A1", "F1");
                TieuDe.Merge();
                TieuDe.Font.Size = 20;
                TieuDe.Font.Bold = true;
                TieuDe.Font.Name = "Times New Roman";
                TieuDe.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                TieuDe.Value2 = "Thống kê công dân";
                TieuDe.Font.Color = Color.Red;
                for (int i = 0; i < dgvListSP.ColumnCount; i++)
                {
                    worksheet.Cells[2, i + 1] = dgvListSP.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dgvListSP.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvListSP.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = dgvListSP.Rows[i].Cells[j].Value.ToString();
                    }
                }
                SaveFileDialog saved = new SaveFileDialog();
                saved.ShowDialog();
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(saved.FileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
