namespace ManagementTopicStudent.Views
{
    partial class frmTimKiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiem));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cMaDeTai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTenDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLoaiDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(523, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 51);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Location = new System.Drawing.Point(277, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 32);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Mã đề tài",
            "Tên đề tài",
            "Loại đề tài",
            "Nhóm ",
            "Giáo viên ",
            "Nội dung"});
            this.cboTimKiem.Location = new System.Drawing.Point(137, 58);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(134, 24);
            this.cboTimKiem.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cMaDeTai,
            this.cTenDT,
            this.cLoaiDT,
            this.cNhom,
            this.cGiaoVien,
            this.cNoiDung});
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(809, 323);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // cMaDeTai
            // 
            this.cMaDeTai.HeaderText = "Mã đề tài";
            this.cMaDeTai.MinimumWidth = 6;
            this.cMaDeTai.Name = "cMaDeTai";
            this.cMaDeTai.Width = 125;
            // 
            // cTenDT
            // 
            this.cTenDT.HeaderText = "Tên đề tài";
            this.cTenDT.MinimumWidth = 6;
            this.cTenDT.Name = "cTenDT";
            this.cTenDT.Width = 125;
            // 
            // cLoaiDT
            // 
            this.cLoaiDT.HeaderText = "Loại đề tài";
            this.cLoaiDT.MinimumWidth = 6;
            this.cLoaiDT.Name = "cLoaiDT";
            this.cLoaiDT.Width = 125;
            // 
            // cNhom
            // 
            this.cNhom.HeaderText = "Nhóm";
            this.cNhom.MinimumWidth = 6;
            this.cNhom.Name = "cNhom";
            this.cNhom.Width = 125;
            // 
            // cGiaoVien
            // 
            this.cGiaoVien.HeaderText = "Giáo viên hướng dẫn";
            this.cGiaoVien.MinimumWidth = 6;
            this.cGiaoVien.Name = "cGiaoVien";
            this.cGiaoVien.Width = 125;
            // 
            // cNoiDung
            // 
            this.cNoiDung.HeaderText = "Nội dung";
            this.cNoiDung.MinimumWidth = 6;
            this.cNoiDung.Name = "cNoiDung";
            this.cNoiDung.Width = 125;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(603, 31);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 53);
            this.btnThoat.TabIndex = 53;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboTimKiem);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "frmTimKiem";
            this.Text = "frmTimKiem";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaDeTai;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTenDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLoaiDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoiDung;
        private System.Windows.Forms.Button btnThoat;
    }
}