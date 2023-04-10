namespace BTL
{
    partial class TimKiemHDB
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
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.rdbMaKH = new System.Windows.Forms.RadioButton();
            this.rdbTenNV = new System.Windows.Forms.RadioButton();
            this.rdbMaNV = new System.Windows.Forms.RadioButton();
            this.rdbTenKH = new System.Windows.Forms.RadioButton();
            this.rdbMaHDB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTenSP = new System.Windows.Forms.RadioButton();
            this.rdbMaSP = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimKiem
            // 
            this.dgvTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiem.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Location = new System.Drawing.Point(35, 177);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.RowHeadersWidth = 51;
            this.dgvTimKiem.RowTemplate.Height = 24;
            this.dgvTimKiem.Size = new System.Drawing.Size(989, 445);
            this.dgvTimKiem.TabIndex = 52;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Location = new System.Drawing.Point(214, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(140, 23);
            this.btnTim.TabIndex = 51;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(35, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(158, 22);
            this.txtInput.TabIndex = 50;
            // 
            // rdbMaKH
            // 
            this.rdbMaKH.AutoSize = true;
            this.rdbMaKH.Location = new System.Drawing.Point(158, 83);
            this.rdbMaKH.Name = "rdbMaKH";
            this.rdbMaKH.Size = new System.Drawing.Size(119, 20);
            this.rdbMaKH.TabIndex = 49;
            this.rdbMaKH.TabStop = true;
            this.rdbMaKH.Text = "Mã khách hàng";
            this.rdbMaKH.UseVisualStyleBackColor = true;
            // 
            // rdbTenNV
            // 
            this.rdbTenNV.AutoSize = true;
            this.rdbTenNV.Location = new System.Drawing.Point(309, 109);
            this.rdbTenNV.Name = "rdbTenNV";
            this.rdbTenNV.Size = new System.Drawing.Size(138, 20);
            this.rdbTenNV.TabIndex = 48;
            this.rdbTenNV.TabStop = true;
            this.rdbTenNV.Text = "Tên nhân viên bán";
            this.rdbTenNV.UseVisualStyleBackColor = true;
            // 
            // rdbMaNV
            // 
            this.rdbMaNV.AutoSize = true;
            this.rdbMaNV.Location = new System.Drawing.Point(158, 109);
            this.rdbMaNV.Name = "rdbMaNV";
            this.rdbMaNV.Size = new System.Drawing.Size(133, 20);
            this.rdbMaNV.TabIndex = 47;
            this.rdbMaNV.TabStop = true;
            this.rdbMaNV.Text = "Mã nhân viên bán";
            this.rdbMaNV.UseVisualStyleBackColor = true;
            // 
            // rdbTenKH
            // 
            this.rdbTenKH.AutoSize = true;
            this.rdbTenKH.Location = new System.Drawing.Point(309, 83);
            this.rdbTenKH.Name = "rdbTenKH";
            this.rdbTenKH.Size = new System.Drawing.Size(124, 20);
            this.rdbTenKH.TabIndex = 45;
            this.rdbTenKH.TabStop = true;
            this.rdbTenKH.Text = "Tên khách hàng";
            this.rdbTenKH.UseVisualStyleBackColor = true;
            // 
            // rdbMaHDB
            // 
            this.rdbMaHDB.AutoSize = true;
            this.rdbMaHDB.Location = new System.Drawing.Point(158, 57);
            this.rdbMaHDB.Name = "rdbMaHDB";
            this.rdbMaHDB.Size = new System.Drawing.Size(125, 20);
            this.rdbMaHDB.TabIndex = 44;
            this.rdbMaHDB.TabStop = true;
            this.rdbMaHDB.Text = "Mã hoá đơn bán";
            this.rdbMaHDB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // rdbTenSP
            // 
            this.rdbTenSP.AutoSize = true;
            this.rdbTenSP.Location = new System.Drawing.Point(309, 135);
            this.rdbTenSP.Name = "rdbTenSP";
            this.rdbTenSP.Size = new System.Drawing.Size(114, 20);
            this.rdbTenSP.TabIndex = 54;
            this.rdbTenSP.TabStop = true;
            this.rdbTenSP.Text = "Tên sản phẩm";
            this.rdbTenSP.UseVisualStyleBackColor = true;
            // 
            // rdbMaSP
            // 
            this.rdbMaSP.AutoSize = true;
            this.rdbMaSP.Location = new System.Drawing.Point(158, 135);
            this.rdbMaSP.Name = "rdbMaSP";
            this.rdbMaSP.Size = new System.Drawing.Size(109, 20);
            this.rdbMaSP.TabIndex = 53;
            this.rdbMaSP.TabStop = true;
            this.rdbMaSP.Text = "Mã sản phẩm";
            this.rdbMaSP.UseVisualStyleBackColor = true;
            // 
            // TimKiemHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.rdbTenSP);
            this.Controls.Add(this.rdbMaSP);
            this.Controls.Add(this.dgvTimKiem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.rdbMaKH);
            this.Controls.Add(this.rdbTenNV);
            this.Controls.Add(this.rdbMaNV);
            this.Controls.Add(this.rdbTenKH);
            this.Controls.Add(this.rdbMaHDB);
            this.Controls.Add(this.label1);
            this.Name = "TimKiemHDB";
            this.Text = "Tìm Kiếm Hoá Đơn Bán";
            this.Load += new System.EventHandler(this.TimKiemHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.RadioButton rdbMaKH;
        private System.Windows.Forms.RadioButton rdbTenNV;
        private System.Windows.Forms.RadioButton rdbMaNV;
        private System.Windows.Forms.RadioButton rdbTenKH;
        private System.Windows.Forms.RadioButton rdbMaHDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbTenSP;
        private System.Windows.Forms.RadioButton rdbMaSP;
    }
}