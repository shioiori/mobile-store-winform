namespace BTL
{
    partial class TimKiemSanPham
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
            this.label1 = new System.Windows.Forms.Label();
            this.rdbMaSP = new System.Windows.Forms.RadioButton();
            this.rdbTenNH = new System.Windows.Forms.RadioButton();
            this.rdbTenSP = new System.Windows.Forms.RadioButton();
            this.rdbMaMH = new System.Windows.Forms.RadioButton();
            this.rdbTenMH = new System.Windows.Forms.RadioButton();
            this.rdbMaNH = new System.Windows.Forms.RadioButton();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // rdbMaSP
            // 
            this.rdbMaSP.AutoSize = true;
            this.rdbMaSP.Location = new System.Drawing.Point(157, 57);
            this.rdbMaSP.Name = "rdbMaSP";
            this.rdbMaSP.Size = new System.Drawing.Size(109, 20);
            this.rdbMaSP.TabIndex = 1;
            this.rdbMaSP.TabStop = true;
            this.rdbMaSP.Text = "Mã sản phẩm";
            this.rdbMaSP.UseVisualStyleBackColor = true;
            // 
            // rdbTenNH
            // 
            this.rdbTenNH.AutoSize = true;
            this.rdbTenNH.Location = new System.Drawing.Point(287, 83);
            this.rdbTenNH.Name = "rdbTenNH";
            this.rdbTenNH.Size = new System.Drawing.Size(112, 20);
            this.rdbTenNH.TabIndex = 2;
            this.rdbTenNH.TabStop = true;
            this.rdbTenNH.Text = "Tên nhãn hiệu";
            this.rdbTenNH.UseVisualStyleBackColor = true;
            // 
            // rdbTenSP
            // 
            this.rdbTenSP.AutoSize = true;
            this.rdbTenSP.Location = new System.Drawing.Point(287, 57);
            this.rdbTenSP.Name = "rdbTenSP";
            this.rdbTenSP.Size = new System.Drawing.Size(114, 20);
            this.rdbTenSP.TabIndex = 3;
            this.rdbTenSP.TabStop = true;
            this.rdbTenSP.Text = "Tên sản phẩm";
            this.rdbTenSP.UseVisualStyleBackColor = true;
            // 
            // rdbMaMH
            // 
            this.rdbMaMH.AutoSize = true;
            this.rdbMaMH.Location = new System.Drawing.Point(157, 109);
            this.rdbMaMH.Name = "rdbMaMH";
            this.rdbMaMH.Size = new System.Drawing.Size(103, 20);
            this.rdbMaMH.TabIndex = 4;
            this.rdbMaMH.TabStop = true;
            this.rdbMaMH.Text = "Mã màn hình";
            this.rdbMaMH.UseVisualStyleBackColor = true;
            // 
            // rdbTenMH
            // 
            this.rdbTenMH.AutoSize = true;
            this.rdbTenMH.Location = new System.Drawing.Point(287, 109);
            this.rdbTenMH.Name = "rdbTenMH";
            this.rdbTenMH.Size = new System.Drawing.Size(108, 20);
            this.rdbTenMH.TabIndex = 5;
            this.rdbTenMH.TabStop = true;
            this.rdbTenMH.Text = "Tên màn hình";
            this.rdbTenMH.UseVisualStyleBackColor = true;
            // 
            // rdbMaNH
            // 
            this.rdbMaNH.AutoSize = true;
            this.rdbMaNH.Location = new System.Drawing.Point(157, 83);
            this.rdbMaNH.Name = "rdbMaNH";
            this.rdbMaNH.Size = new System.Drawing.Size(107, 20);
            this.rdbMaNH.TabIndex = 6;
            this.rdbMaNH.TabStop = true;
            this.rdbMaNH.Text = "Mã nhãn hiệu";
            this.rdbMaNH.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Location = new System.Drawing.Point(213, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(140, 23);
            this.btnTim.TabIndex = 41;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(34, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(158, 22);
            this.txtInput.TabIndex = 40;
            // 
            // dgvTimKiem
            // 
            this.dgvTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiem.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Location = new System.Drawing.Point(34, 154);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.RowHeadersWidth = 51;
            this.dgvTimKiem.RowTemplate.Height = 24;
            this.dgvTimKiem.Size = new System.Drawing.Size(989, 468);
            this.dgvTimKiem.TabIndex = 42;
            // 
            // TimKiemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.dgvTimKiem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.rdbMaNH);
            this.Controls.Add(this.rdbTenMH);
            this.Controls.Add(this.rdbMaMH);
            this.Controls.Add(this.rdbTenSP);
            this.Controls.Add(this.rdbTenNH);
            this.Controls.Add(this.rdbMaSP);
            this.Controls.Add(this.label1);
            this.Name = "TimKiemSanPham";
            this.Text = "Tìm Kiếm Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbMaSP;
        private System.Windows.Forms.RadioButton rdbTenNH;
        private System.Windows.Forms.RadioButton rdbTenSP;
        private System.Windows.Forms.RadioButton rdbMaMH;
        private System.Windows.Forms.RadioButton rdbTenMH;
        private System.Windows.Forms.RadioButton rdbMaNH;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.DataGridView dgvTimKiem;
    }
}