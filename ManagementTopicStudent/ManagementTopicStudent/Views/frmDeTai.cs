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
    public partial class frmDeTai : Form
    {
        private bool flag = false;
        public frmDeTai()
        {
            InitializeComponent();
            this.cMaDeTai.DataPropertyName = nameof(DeTai.MaDT);
            this.cTenDT.DataPropertyName = nameof(DeTai.TenDT);
            this.cLoaiDT.DataPropertyName = nameof(DeTai.LoaiDT);
            this.cNhom.DataPropertyName = nameof(DeTai.MaNhom);
            this.cGiaoVien.DataPropertyName = nameof(DeTai.MaGV);
            this.cNoiDung.DataPropertyName = nameof(DeTai.NoiDung);
            
            BindingSource source = new BindingSource();
            source.DataSource = DeTaiController.getListDT();
            this.dataGridView1.DataSource = source;
            //  dgrDSSV.AutoGenerateColumns = false;

            List<Nhom> searchnhom = SinhVienController.getListNhom();

            for (int i = 0; i < searchnhom.Count; i++)
            {
                this.cboNhom.Items.Add(searchnhom[i]);
            }
            List<GiaoVien> searchgiaovien = GiaoVienController.getListgiaovien();

            for (int i = 0; i < searchgiaovien.Count; i++)
            {
                this.cboGiaoVien.Items.Add(searchgiaovien[i]);
            }

        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtMaDeTai.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMaDeTai, "Phai nhap ma de tai");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtMaDeTai, null);
            if (this.txtTenDT.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtTenDT, "Phai nhap ten de tai");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtTenDT, null);
            if (this.cboNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.cboNhom, "Phai chon nhom");
                dem++;
            }
            else this.errorProvider4.SetError(this.cboNhom, null);
            if (this.cboLoaiDeTai.Text.Trim().Length <= 0)
            {
                this.errorProvider4.SetError(this.cboLoaiDeTai, "Phai chon loai de tai");
                dem++;
            }
            else this.errorProvider4.SetError(this.cboLoaiDeTai, null);
            if (this.cboGiaoVien.Text.Trim().Length <= 0)
            {
                this.errorProvider5.SetError(this.cboGiaoVien, "Phai nhap giao vien huong dan");
                dem++;
            }
            else this.errorProvider5.SetError(this.cboGiaoVien, null);
            if (dem != 0)
                return;
            DeTai dt = new DeTai();
            dt.MaDT = this.txtMaDeTai.Text.Trim();
            dt.TenDT = this.txtTenDT.Text.Trim();
            dt.LoaiDT = this.cboLoaiDeTai.Text.Trim();            
            dt.MaNhom = this.cboNhom.Text.Trim();
            dt.MaGV = this.cboGiaoVien.Text.Trim();
            dt.NoiDung = this.txtNoiDung.Text.Trim();
           
            if (DeTaiController.AddDT(dt) == false)
            {
                MessageBox.Show("Mã đề tài bị trùng");
                return;
            }
            DeTaiController.AddDT(dt);
            BindingSource source = new BindingSource();
            source.DataSource = DeTaiController.getListDT();
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns["Nhom"].Visible = false;
            this.dataGridView1.Columns["GiaoVien"].Visible = false;
            this.dataGridView1.Columns["TienDoes"].Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }

            DeTai dt = DeTaiController.getDT(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DeTaiController.DeleteDT(dt);
            //Hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = DeTaiController.getListDT();
            this.dataGridView1.DataSource = source;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMaDeTai.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.txtTenDT.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.cboLoaiDeTai.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.cboNhom.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.cboGiaoVien.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.txtNoiDung.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            flag = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtMaDeTai.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMaDeTai, "Phai nhap ma de tai");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtMaDeTai, null);
            if (this.txtTenDT.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtTenDT, "Phai nhap ten de tai");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtTenDT, null);
            if (this.cboNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.cboNhom, "Phai chon nhom");
                dem++;
            }
            else this.errorProvider4.SetError(this.cboNhom, null);
            if (this.cboLoaiDeTai.Text.Trim().Length <= 0)
            {
                this.errorProvider4.SetError(this.cboLoaiDeTai, "Phai chon loai de tai");
                dem++;
            }
            else this.errorProvider4.SetError(this.cboLoaiDeTai, null);
            if (this.cboGiaoVien.Text.Trim().Length <= 0)
            {
                this.errorProvider5.SetError(this.cboGiaoVien, "Phai nhap giao vien huong dan");
                dem++;
            }
            else this.errorProvider5.SetError(this.cboGiaoVien, null);
            if (dem != 0)
                return;
            if (flag == true)
            {
                try
                {
                    this.dataGridView1.SelectedCells[0].Value = this.txtMaDeTai.Text.Trim();
                    this.dataGridView1.SelectedCells[1].Value = this.txtTenDT.Text.Trim();
                    this.dataGridView1.SelectedCells[2].Value = this.cboLoaiDeTai.Text.Trim();
                    this.dataGridView1.SelectedCells[4].Value = this.cboNhom.Text.Trim();
                    this.dataGridView1.SelectedCells[5].Value = this.cboGiaoVien.Text.Trim();
                    this.dataGridView1.SelectedCells[3].Value = this.txtNoiDung.Text.Trim();
                }
                catch
                {
                    MessageBox.Show("Hãy nhấn vào ô trống đầu tiên của mỗi dòng để chọn dòng cần cập nhật!");
                    return;
                }
            }
            DeTai dt = new DeTai();
            dt.MaDT = this.txtMaDeTai.Text.Trim();
            dt.TenDT = this.txtTenDT.Text.Trim();
            dt.LoaiDT = this.cboLoaiDeTai.Text.Trim();
            dt.MaNhom = this.cboNhom.Text.Trim();
            dt.MaGV = this.cboGiaoVien.Text.Trim();
            dt.NoiDung = this.txtNoiDung.Text.Trim();
            //update
            DeTaiController.UpdateDT(dt);
            //hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = DeTaiController.getListDT();
            this.dataGridView1.DataSource = source;
        }
    }
}
