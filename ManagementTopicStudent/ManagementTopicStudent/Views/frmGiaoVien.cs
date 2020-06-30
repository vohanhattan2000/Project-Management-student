using ManagementTopicStudent.Controllers;
using ManagementTopicStudent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementTopicStudent.Views
{
    public partial class frmGiaoVien : Form
    {
        private bool flag = false;
        public frmGiaoVien()
        {
            InitializeComponent();
            this.cMaGV.DataPropertyName = nameof(GiaoVien.MaGV);
            this.cTenGV.DataPropertyName = nameof(GiaoVien.TenGV);
            this.cEmail.DataPropertyName = nameof(GiaoVien.EmailGV);
            this.helpProvider1.SetShowHelp(this.txtMaGV, true);
            this.helpProvider1.SetHelpString(this.txtMaGV, "Nhap Ma Giao Vien!");
            this.helpProvider1.SetShowHelp(this.txtHoTenGV, true);
            this.helpProvider1.SetHelpString(this.txtHoTenGV, "Nhap ho ten giao vien!");
            this.helpProvider1.SetShowHelp(this.txtEmailGV, true);
            this.helpProvider1.SetHelpString(this.txtEmailGV, "Nhap Email giao vien!");
            BindingSource source = new BindingSource();
            source.DataSource = GiaoVienController.GetGV();
            this.dataGridView1.DataSource = source;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtMaGV.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMaGV, "Phải nhập mã giáo viên");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtMaGV, null);
            if (this.txtHoTenGV.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtHoTenGV, "Phải nhập tên Giáo viên");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtHoTenGV, null);
            if (this.txtEmailGV.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.txtEmailGV, "Phải nhập Email Giáo viên");
                dem++;
            }
            else this.errorProvider3.SetError(this.txtEmailGV, null);
            if (dem != 0)
                return;
            GiaoVien gv = new GiaoVien();
            gv.MaGV = this.txtMaGV.Text.Trim();
            gv.TenGV = this.txtHoTenGV.Text.Trim();
            gv.EmailGV = this.txtEmailGV.Text.Trim();
            if (GiaoVienController.AddGV(gv) == false)
            {
                MessageBox.Show("Mã giáo viên bị trùng");
                return;
            }
            GiaoVienController.AddGV(gv);
            BindingSource source = new BindingSource();
            source.DataSource = GiaoVienController.GetGV();
            this.dataGridView1.DataSource = source;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }

            GiaoVien giaoVien = GiaoVienController.getGV(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            GiaoVienController.DeleteGV(giaoVien);
            //Hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = GiaoVienController.GetGV();
            this.dataGridView1.DataSource = source;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                this.txtMaGV.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtHoTenGV.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txtEmailGV.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           
            flag = true;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns["DeTais"].Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtMaGV.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMaGV, "Phải nhập mã giáo viên");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtMaGV, null);
            if (this.txtHoTenGV.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtHoTenGV, "Phải nhập tên Giáo viên");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtHoTenGV, null);
            if (this.txtEmailGV.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.txtEmailGV, "Phải nhập Email Giáo viên");
                dem++;
            }
            else this.errorProvider3.SetError(this.txtEmailGV, null);
            if (dem != 0)
                return;
            if (flag == true)
            {
                try
                {
                    this.dataGridView1.SelectedCells[0].Value = this.txtMaGV.Text.Trim();
                    this.dataGridView1.SelectedCells[1].Value = this.txtHoTenGV.Text.Trim();
                    this.dataGridView1.SelectedCells[2].Value = this.txtEmailGV.Text.Trim();
                }
                catch
                {
                    MessageBox.Show("Hãy nhấn vào ô trống đầu tiên của mỗi dòng để chọn dòng cần cập nhật!");
                    return;
                }
            }
            GiaoVien gv = new GiaoVien();
            gv.MaGV = this.txtMaGV.Text.Trim();
            gv.TenGV = this.txtHoTenGV.Text.Trim();
            gv.EmailGV = this.txtEmailGV.Text.Trim();
            //update
            GiaoVienController.UpdateGV(gv);
            //hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = GiaoVienController.GetGV();
            this.dataGridView1.DataSource = source;
        }
    }
}
