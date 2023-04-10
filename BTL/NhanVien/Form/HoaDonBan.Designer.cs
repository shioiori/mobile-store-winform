namespace BTL
{
    partial class HoaDonBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTaoHDB = new System.Windows.Forms.Button();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbKH = new System.Windows.Forms.ComboBox();
            this.btnSuaHDB = new System.Windows.Forms.Button();
            this.btnXoaHDB = new System.Windows.Forms.Button();
            this.btnThemHDB = new System.Windows.Forms.Button();
            this.cbNVBan = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.RichTextBox();
            this.txtNgayBan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKhuyenMai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLamLai = new System.Windows.Forms.Button();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.txtSLMua = new System.Windows.Forms.TextBox();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTaoHDB
            // 
            this.btnTaoHDB.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTaoHDB.FlatAppearance.BorderSize = 0;
            this.btnTaoHDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoHDB.Location = new System.Drawing.Point(359, 7);
            this.btnTaoHDB.Name = "btnTaoHDB";
            this.btnTaoHDB.Size = new System.Drawing.Size(140, 23);
            this.btnTaoHDB.TabIndex = 20;
            this.btnTaoHDB.Text = "Sinh mã hoá đơn";
            this.btnTaoHDB.UseVisualStyleBackColor = false;
            this.btnTaoHDB.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtMaHDB
            // 
            this.txtMaHDB.Location = new System.Drawing.Point(28, 7);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.Size = new System.Drawing.Size(158, 22);
            this.txtMaHDB.TabIndex = 26;
            this.txtMaHDB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMaHDB_MouseClick);
            this.txtMaHDB.TextChanged += new System.EventHandler(this.txtMaHDB_TextChanged);
            // 
            // lbTongTien
            // 
            this.lbTongTien.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(890, 583);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(14, 16);
            this.lbTongTien.TabIndex = 25;
            this.lbTongTien.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(754, 583);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Tổng tiền thanh toán:";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(28, 379);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1007, 185);
            this.dgvHoaDon.TabIndex = 23;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbKH);
            this.groupBox1.Controls.Add(this.btnSuaHDB);
            this.groupBox1.Controls.Add(this.btnXoaHDB);
            this.groupBox1.Controls.Add(this.btnThemHDB);
            this.groupBox1.Controls.Add(this.cbNVBan);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtNgayBan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(28, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 299);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cbKH
            // 
            this.cbKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKH.FormattingEnabled = true;
            this.cbKH.Location = new System.Drawing.Point(149, 29);
            this.cbKH.Name = "cbKH";
            this.cbKH.Size = new System.Drawing.Size(250, 24);
            this.cbKH.TabIndex = 35;
            this.cbKH.SelectedIndexChanged += new System.EventHandler(this.cbKH_SelectedIndexChanged);
            // 
            // btnSuaHDB
            // 
            this.btnSuaHDB.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSuaHDB.FlatAppearance.BorderSize = 0;
            this.btnSuaHDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaHDB.Location = new System.Drawing.Point(241, 251);
            this.btnSuaHDB.Name = "btnSuaHDB";
            this.btnSuaHDB.Size = new System.Drawing.Size(76, 23);
            this.btnSuaHDB.TabIndex = 34;
            this.btnSuaHDB.Text = "Sửa";
            this.btnSuaHDB.UseVisualStyleBackColor = false;
            this.btnSuaHDB.Click += new System.EventHandler(this.btnSuaHDB_Click);
            // 
            // btnXoaHDB
            // 
            this.btnXoaHDB.BackColor = System.Drawing.Color.SkyBlue;
            this.btnXoaHDB.FlatAppearance.BorderSize = 0;
            this.btnXoaHDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaHDB.Location = new System.Drawing.Point(323, 251);
            this.btnXoaHDB.Name = "btnXoaHDB";
            this.btnXoaHDB.Size = new System.Drawing.Size(76, 23);
            this.btnXoaHDB.TabIndex = 33;
            this.btnXoaHDB.Text = "Xoá";
            this.btnXoaHDB.UseVisualStyleBackColor = false;
            this.btnXoaHDB.Click += new System.EventHandler(this.btnXoaHDB_Click);
            // 
            // btnThemHDB
            // 
            this.btnThemHDB.BackColor = System.Drawing.Color.SkyBlue;
            this.btnThemHDB.FlatAppearance.BorderSize = 0;
            this.btnThemHDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHDB.Location = new System.Drawing.Point(149, 251);
            this.btnThemHDB.Name = "btnThemHDB";
            this.btnThemHDB.Size = new System.Drawing.Size(86, 23);
            this.btnThemHDB.TabIndex = 32;
            this.btnThemHDB.Text = "Thêm";
            this.btnThemHDB.UseVisualStyleBackColor = false;
            this.btnThemHDB.Click += new System.EventHandler(this.btnThemHDB_Click);
            // 
            // cbNVBan
            // 
            this.cbNVBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNVBan.FormattingEnabled = true;
            this.cbNVBan.Location = new System.Drawing.Point(149, 211);
            this.cbNVBan.Name = "cbNVBan";
            this.cbNVBan.Size = new System.Drawing.Size(250, 24);
            this.cbNVBan.TabIndex = 30;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(149, 67);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(250, 90);
            this.txtDiaChi.TabIndex = 17;
            this.txtDiaChi.Text = "";
            // 
            // txtNgayBan
            // 
            this.txtNgayBan.Location = new System.Drawing.Point(149, 177);
            this.txtNgayBan.Name = "txtNgayBan";
            this.txtNgayBan.Size = new System.Drawing.Size(250, 22);
            this.txtNgayBan.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách hàng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Địa chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nhân viên bán:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ngày bán:";
            // 
            // txtKhuyenMai
            // 
            this.txtKhuyenMai.Location = new System.Drawing.Point(133, 216);
            this.txtKhuyenMai.Name = "txtKhuyenMai";
            this.txtKhuyenMai.Size = new System.Drawing.Size(148, 22);
            this.txtKhuyenMai.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Khuyến mãi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.btnLamLai);
            this.panel1.Controls.Add(this.btnLuuHoaDon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 624);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 49);
            this.panel1.TabIndex = 18;
            // 
            // btnLamLai
            // 
            this.btnLamLai.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLamLai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLamLai.FlatAppearance.BorderSize = 0;
            this.btnLamLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamLai.Location = new System.Drawing.Point(120, 0);
            this.btnLamLai.Name = "btnLamLai";
            this.btnLamLai.Size = new System.Drawing.Size(120, 49);
            this.btnLamLai.TabIndex = 1;
            this.btnLamLai.Text = "Huỷ";
            this.btnLamLai.UseVisualStyleBackColor = true;
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLuuHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLuuHoaDon.FlatAppearance.BorderSize = 0;
            this.btnLuuHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(0, 0);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(120, 49);
            this.btnLuuHoaDon.TabIndex = 2;
            this.btnLuuHoaDon.Text = "Lưu hoá đơn";
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            this.btnLuuHoaDon.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSuaSP);
            this.groupBox2.Controls.Add(this.txtSLMua);
            this.groupBox2.Controls.Add(this.btnXoaSP);
            this.groupBox2.Controls.Add(this.txtKhuyenMai);
            this.groupBox2.Controls.Add(this.btnThemSP);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTenSP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dgvSanPham);
            this.groupBox2.Location = new System.Drawing.Point(515, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 299);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sản phẩm";
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSuaSP.FlatAppearance.BorderSize = 0;
            this.btnSuaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSP.Location = new System.Drawing.Point(334, 251);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(76, 23);
            this.btnSuaSP.TabIndex = 31;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // txtSLMua
            // 
            this.txtSLMua.Location = new System.Drawing.Point(416, 213);
            this.txtSLMua.Name = "txtSLMua";
            this.txtSLMua.Size = new System.Drawing.Size(76, 22);
            this.txtSLMua.TabIndex = 30;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.SkyBlue;
            this.btnXoaSP.FlatAppearance.BorderSize = 0;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Location = new System.Drawing.Point(416, 251);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(76, 23);
            this.btnXoaSP.TabIndex = 29;
            this.btnXoaSP.Text = "Xoá";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            this.btnXoaSP.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.SkyBlue;
            this.btnThemSP.FlatAppearance.BorderSize = 0;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Location = new System.Drawing.Point(242, 251);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(86, 23);
            this.btnThemSP.TabIndex = 28;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Số lượng mua:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(133, 176);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(148, 22);
            this.txtTenSP.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tên sản phẩm:";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(34, 29);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(458, 128);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTraCuu.FlatAppearance.BorderSize = 0;
            this.btnTraCuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraCuu.Location = new System.Drawing.Point(207, 7);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(140, 23);
            this.btnTraCuu.TabIndex = 28;
            this.btnTraCuu.Text = "Tra cứu hoá đơn";
            this.btnTraCuu.UseVisualStyleBackColor = false;
            this.btnTraCuu.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.SkyBlue;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Location = new System.Drawing.Point(511, 7);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 23);
            this.btnLamMoi.TabIndex = 29;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // HoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnTaoHDB);
            this.Controls.Add(this.txtMaHDB);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "HoaDonBan";
            this.Text = "Hoá Đơn Bán";
            this.Load += new System.EventHandler(this.TaoHoaDonBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTaoHDB;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDiaChi;
        private System.Windows.Forms.DateTimePicker txtNgayBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLamLai;
        private System.Windows.Forms.TextBox txtKhuyenMai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ComboBox cbNVBan;
        private System.Windows.Forms.TextBox txtSLMua;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnSuaHDB;
        private System.Windows.Forms.Button btnXoaHDB;
        private System.Windows.Forms.Button btnThemHDB;
        private System.Windows.Forms.ComboBox cbKH;
        private System.Windows.Forms.Button btnLuuHoaDon;
    }
}