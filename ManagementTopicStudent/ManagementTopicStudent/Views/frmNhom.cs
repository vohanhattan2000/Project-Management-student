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
    public partial class frmNhom : Form
    {
       
        private bool flag=false;
        public frmNhom()
        {
            
            InitializeComponent();
            this.cMaNhom.DataPropertyName = nameof(Nhom.MaNhom);
            this.cTenNhom.DataPropertyName = nameof(Nhom.TenNhom);
            this.helpProvider1.SetShowHelp(this.txtMaNhom, true);
            this.helpProvider1.SetHelpString(this.txtMaNhom, "Nhap Ma nhom!");
            this.helpProvider1.SetShowHelp(this.txtTenNhom, true);
            this.helpProvider1.SetHelpString(this.txtTenNhom, "Nhap Ten Nhom!");
            BindingSource source = new BindingSource();
            source.DataSource = NhomController.GetNhoms();
            this.dataGridView1.DataSource = source;
            
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtMaNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMaNhom, "Phải nhập mã nhóm");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtMaNhom, null);
            if (this.txtTenNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtTenNhom, "Phải nhập tên nhóm");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtTenNhom, null);
            if (dem != 0)
                return;
            Nhom nhom = new Nhom();
            nhom.MaNhom = this.txtMaNhom.Text.Trim();
            nhom.TenNhom = this.txtTenNhom.Text.Trim();
            if(NhomController.AddNhom(nhom)==false)
            {
                MessageBox.Show("Mã nhóm bị trùng");
                return;
            }
            NhomController.AddNhom(nhom);
            BindingSource source = new BindingSource();
            source.DataSource = NhomController.GetNhoms();
            this.dataGridView1.DataSource = source;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns["TienDoes"].Visible = false;
            this.dataGridView1.Columns["DeTais"].Visible = false;
            this.dataGridView1.Columns["SinhViens"].Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }

            Nhom nhom = NhomController.getNhom(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            NhomController.DeleteNhom(nhom);
            //Hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = NhomController.GetNhoms();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMaNhom.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.txtTenNhom.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            flag = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtMaNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMaNhom, "Phải nhập mã nhóm");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtMaNhom, null);
            if (this.txtTenNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtTenNhom, "Phải nhập tên nhóm");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtTenNhom, null);
            if (dem != 0)
                return;
            if (flag == true)
            {
                try
                {
                    this.dataGridView1.SelectedCells[0].Value = this.txtMaNhom.Text.Trim();
                    this.dataGridView1.SelectedCells[1].Value = this.txtTenNhom.Text.Trim();
                }
                catch
                {
                    MessageBox.Show("Hãy nhấn vào ô trống đầu tiên của mỗi dòng để chọn dòng cần cập nhật!");
                    return;
                }
            }
            Nhom nhom = new Nhom();
            nhom.MaNhom = this.txtMaNhom.Text.Trim();
            nhom.TenNhom = this.txtTenNhom.Text.Trim();
            //update
            NhomController.UpdateNhom(nhom);
            //hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = NhomController.GetNhoms();
            this.dataGridView1.DataSource = source;

        }

        
    }
}
