namespace BTL
{
    partial class TimKiemHDN
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
            this.rdbMaNCC = new System.Windows.Forms.RadioButton();
            this.rdbTenNV = new System.Windows.Forms.RadioButton();
            this.rdbMaNV = new System.Windows.Forms.RadioButton();
            this.rdbTenNCC = new System.Windows.Forms.RadioButton();
            this.rdbMaHDN = new System.Windows.Forms.RadioButton();
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
            this.dgvTimKiem.Location = new System.Drawing.Point(36, 176);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.RowHeadersWidth = 51;
            this.dgvTimKiem.RowTemplate.Height = 24;
            this.dgvTimKiem.Size = new System.Drawing.Size(989, 447);
            this.dgvTimKiem.TabIndex = 61;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Location = new System.Drawing.Point(215, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(140, 23);
            this.btnTim.TabIndex = 60;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(36, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(158, 22);
            this.txtInput.TabIndex = 59;
            // 
            // rdbMaNCC
            // 
            this.rdbMaNCC.AutoSize = true;
            this.rdbMaNCC.Location = new System.Drawing.Point(159, 83);
            this.rdbMaNCC.Name = "rdbMaNCC";
            this.rdbMaNCC.Size = new System.Drawing.Size(130, 20);
            this.rdbMaNCC.TabIndex = 58;
            this.rdbMaNCC.TabStop = true;
            this.rdbMaNCC.Text = "Mã nhà cung cấp";
            this.rdbMaNCC.UseVisualStyleBackColor = true;
            // 
            // rdbTenNV
            // 
            this.rdbTenNV.AutoSize = true;
            this.rdbTenNV.Location = new System.Drawing.Point(315, 109);
            this.rdbTenNV.Name = "rdbTenNV";
            this.rdbTenNV.Size = new System.Drawing.Size(145, 20);
            this.rdbTenNV.TabIndex = 57;
            this.rdbTenNV.TabStop = true;
            this.rdbTenNV.Text = "Tên nhân viên nhập";
            this.rdbTenNV.UseVisualStyleBackColor = true;
            // 
            // rdbMaNV
            // 
            this.rdbMaNV.AutoSize = true;
            this.rdbMaNV.Location = new System.Drawing.Point(159, 109);
            this.rdbMaNV.Name = "rdbMaNV";
            this.rdbMaNV.Size = new System.Drawing.Size(140, 20);
            this.rdbMaNV.TabIndex = 56;
            this.rdbMaNV.TabStop = true;
            this.rdbMaNV.Text = "Mã nhân viên nhập";
            this.rdbMaNV.UseVisualStyleBackColor = true;
            // 
            // rdbTenNCC
            // 
            this.rdbTenNCC.AutoSize = true;
            this.rdbTenNCC.Location = new System.Drawing.Point(315, 83);
            this.rdbTenNCC.Name = "rdbTenNCC";
            this.rdbTenNCC.Size = new System.Drawing.Size(135, 20);
            this.rdbTenNCC.TabIndex = 55;
            this.rdbTenNCC.TabStop = true;
            this.rdbTenNCC.Text = "Tên nhà cung cấp";
            this.rdbTenNCC.UseVisualStyleBackColor = true;
            // 
            // rdbMaHDN
            // 
            this.rdbMaHDN.AutoSize = true;
            this.rdbMaHDN.Location = new System.Drawing.Point(159, 57);
            this.rdbMaHDN.Name = "rdbMaHDN";
            this.rdbMaHDN.Size = new System.Drawing.Size(132, 20);
            this.rdbMaHDN.TabIndex = 54;
            this.rdbMaHDN.TabStop = true;
            this.rdbMaHDN.Text = "Mã hoá đơn nhập";
            this.rdbMaHDN.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // rdbTenSP
            // 
            this.rdbTenSP.AutoSize = true;
            this.rdbTenSP.Location = new System.Drawing.Point(315, 135);
            this.rdbTenSP.Name = "rdbTenSP";
            this.rdbTenSP.Size = new System.Drawing.Size(114, 20);
            this.rdbTenSP.TabIndex = 63;
            this.rdbTenSP.TabStop = true;
            this.rdbTenSP.Text = "Tên sản phẩm";
            this.rdbTenSP.UseVisualStyleBackColor = true;
            // 
            // rdbMaSP
            // 
            this.rdbMaSP.AutoSize = true;
            this.rdbMaSP.Location = new System.Drawing.Point(159, 135);
            this.rdbMaSP.Name = "rdbMaSP";
            this.rdbMaSP.Size = new System.Drawing.Size(109, 20);
            this.rdbMaSP.TabIndex = 62;
            this.rdbMaSP.TabStop = true;
            this.rdbMaSP.Text = "Mã sản phẩm";
            this.rdbMaSP.UseVisualStyleBackColor = true;
            // 
            // TimKiemHDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.rdbTenSP);
            this.Controls.Add(this.rdbMaSP);
            this.Controls.Add(this.dgvTimKiem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.rdbMaNCC);
            this.Controls.Add(this.rdbTenNV);
            this.Controls.Add(this.rdbMaNV);
            this.Controls.Add(this.rdbTenNCC);
            this.Controls.Add(this.rdbMaHDN);
            this.Controls.Add(this.label1);
            this.Name = "TimKiemHDN";
            this.Text = "Tìm Kiếm Hoá Đơn Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.RadioButton rdbMaNCC;
        private System.Windows.Forms.RadioButton rdbTenNV;
        private System.Windows.Forms.RadioButton rdbMaNV;
        private System.Windows.Forms.RadioButton rdbTenNCC;
        private System.Windows.Forms.RadioButton rdbMaHDN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbTenSP;
        private System.Windows.Forms.RadioButton rdbMaSP;
    }
}