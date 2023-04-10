namespace BTL.NhanVien.Report
{
    partial class BaoCaoNV
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
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtNamNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbThang1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTimNV = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer4
            // 
            this.reportViewer4.Location = new System.Drawing.Point(32, 64);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.ServerReport.BearerToken = null;
            this.reportViewer4.Size = new System.Drawing.Size(989, 559);
            this.reportViewer4.TabIndex = 18;
            // 
            // txtNamNV
            // 
            this.txtNamNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamNV.Location = new System.Drawing.Point(350, 8);
            this.txtNamNV.Name = "txtNamNV";
            this.txtNamNV.Size = new System.Drawing.Size(124, 22);
            this.txtNamNV.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Chọn năm:";
            // 
            // cbbThang1
            // 
            this.cbbThang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbThang1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbThang1.FormattingEnabled = true;
            this.cbbThang1.Items.AddRange(new object[] {
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cbbThang1.Location = new System.Drawing.Point(112, 8);
            this.cbbThang1.Name = "cbbThang1";
            this.cbbThang1.Size = new System.Drawing.Size(130, 24);
            this.cbbThang1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Chọn tháng:";
            // 
            // btnTimNV
            // 
            this.btnTimNV.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTimNV.FlatAppearance.BorderSize = 0;
            this.btnTimNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimNV.Location = new System.Drawing.Point(881, 11);
            this.btnTimNV.Name = "btnTimNV";
            this.btnTimNV.Size = new System.Drawing.Size(140, 23);
            this.btnTimNV.TabIndex = 29;
            this.btnTimNV.Text = "Tra cứu nhân viên";
            this.btnTimNV.UseVisualStyleBackColor = false;
            this.btnTimNV.Click += new System.EventHandler(this.btnTimNV_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.SkyBlue;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Location = new System.Drawing.Point(726, 11);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 23);
            this.btnLamMoi.TabIndex = 30;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // BaoCaoNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimNV);
            this.Controls.Add(this.cbbThang1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer4);
            this.Controls.Add(this.txtNamNV);
            this.Controls.Add(this.label2);
            this.Name = "BaoCaoNV";
            this.Text = "BaoCaoNV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.TextBox txtNamNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbThang1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTimNV;
        private System.Windows.Forms.Button btnLamMoi;
    }
}