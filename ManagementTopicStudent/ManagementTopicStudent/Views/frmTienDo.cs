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
    public partial class frmTienDo : Form
    {
        private bool flag = false;
        public frmTienDo()
        {
            InitializeComponent();
            List<Nhom> searchnhom = SinhVienController.getListNhom();

            for (int i = 0; i < searchnhom.Count; i++)
            {
                this.cboNhom.Items.Add(searchnhom[i]);
            }
            //List<DeTai> searchdetai = DeTaiController.getListDeTaicb();

            //for (int i = 0; i < searchdetai.Count; i++)
            //{
            //    this.cboDeTai.Items.Add(searchdetai[i]);
            //}
            this.cTenTienDo.DataPropertyName = nameof(TienDo.MaTienDo);
            this.cDeTai.DataPropertyName = nameof(TienDo.MaDT);
            this.cNhom.DataPropertyName = nameof(TienDo.MaNhom);
            this.cTaiLieu.DataPropertyName = nameof(TienDo.TaiLieu);
            this.cTrangThai.DataPropertyName = nameof(TienDo.TrangThai);
            this.cThoiGianKT.DataPropertyName = nameof(TienDo.ThoiGianKT);
            this.cNhanXet.DataPropertyName = nameof(TienDo.NhanXet);
           
            BindingSource source = new BindingSource();
            source.DataSource = TienDoController.getListTienDo();
            this.dataGridView1.DataSource = source;            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                DeTai dt = TienDoController.layDeTai(cboNhom.Text.ToString());
                cboDeTai.Text = dt.ToString();
            }
            catch
            {
                MessageBox.Show("Nhóm này chưa có đề tài!");
                cboDeTai.Text="";
                cboNhom.Text="";
                return;
            }
        }

        private void labelnhom_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            if (this.txtTenTienDo.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtTenTienDo, "Phai nhap ten tien do");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtTenTienDo, null);
            if (this.cboDeTai.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.cboDeTai, "Phai chon de tai");
                dem++;
            }
            else this.errorProvider2.SetError(this.cboDeTai, null);
            if (this.cboNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.cboNhom, "Phai chon nhom");
                dem++;
            }
            else this.errorProvider3.SetError(this.cboNhom, null);          
            if (this.txtTrangThai.Text.Trim().Length <= 0)
            {
                this.errorProvider4.SetError(this.txtTrangThai, "Phai nhap trang thai cua de tai");
                dem++;
            }
            else this.errorProvider4.SetError(this.txtTrangThai, null);                  
            if (dem != 0)
                return;
            TienDo td = new TienDo();
            td.MaTienDo = this.txtTenTienDo.Text.Trim();
            td.MaDT = this.cboDeTai.Text.Trim();
            td.MaNhom = this.cboNhom.Text.Trim();
            td.TaiLieu = this.txtTaiLieu.Text.Trim();
            td.TrangThai = this.txtTrangThai.Text.Trim();
            td.ThoiGianKT = this.dataTimeKT.Value;
            td.NhanXet = this.txtNhanXet.Text.Trim();
            if (TienDoController.AddTienDo(td) == false)
            {
                MessageBox.Show("Mã đề tài bị trùng");
                return;
            }
            //TienDoController.AddTienDo(td);
            BindingSource source = new BindingSource();
            source.DataSource = TienDoController.getListTienDo();
            this.dataGridView1.DataSource = source;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }

            TienDo td = TienDoController.getTienDo(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            TienDoController.DeleteTienDo(td);
            //Hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = TienDoController.getListTienDo();
            this.dataGridView1.DataSource = source;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtTenTienDo.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.cboDeTai.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.cboNhom.Text = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.txtTaiLieu.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.txtTrangThai.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.dataTimeKT.Value = DateTime.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            this.txtNhanXet.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            flag = true;
            //MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtTenTienDo.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtTenTienDo, "Phai nhap ten tien do");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtTenTienDo, null);
            if (this.cboDeTai.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.cboDeTai, "Phai chon de tai");
                dem++;
            }
            else this.errorProvider2.SetError(this.cboDeTai, null);
            if (this.cboNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.cboNhom, "Phai chon nhom");
                dem++;
            }
            else this.errorProvider3.SetError(this.cboNhom, null);
            if (this.txtTrangThai.Text.Trim().Length <= 0)
            {
                this.errorProvider4.SetError(this.txtTrangThai, "Phai nhap trang thai cua de tai");
                dem++;
            }
            else this.errorProvider4.SetError(this.txtTrangThai, null);
            if (dem != 0)
                return;
            if (flag == true)
            {
                try
                {
                    this.dataGridView1.SelectedCells[0].Value = this.txtTenTienDo.Text.Trim();
                    this.dataGridView1.SelectedCells[5].Value = this.cboDeTai.Text.Trim();
                    this.dataGridView1.SelectedCells[6].Value = this.cboNhom.Text.Trim();
                    this.dataGridView1.SelectedCells[2].Value = this.txtTaiLieu.Text.Trim();
                    this.dataGridView1.SelectedCells[1].Value = this.txtTrangThai.Text.Trim();
                    this.dataGridView1.SelectedCells[3].Value = this.dataTimeKT.Value;
                    this.dataGridView1.SelectedCells[4].Value = this.txtNhanXet.Text.Trim();                   
                }
                catch
                {
                    MessageBox.Show("Hãy nhấn vào ô trống đầu tiên của mỗi dòng để chọn dòng cần cập nhật!");
                    return;
                }
            }
            flag = false;
            TienDo td = new TienDo();
            td.MaTienDo = this.txtTenTienDo.Text.Trim();
            td.MaDT = this.cboDeTai.Text.Trim();
            td.MaNhom = this.cboNhom.Text.Trim();
            td.TaiLieu = this.txtTaiLieu.Text.Trim();
            td.TrangThai = this.txtTrangThai.Text.Trim();
            td.ThoiGianKT = this.dataTimeKT.Value;
            td.NhanXet = this.txtNhanXet.Text.Trim();
            TienDoController.UpdateTienDo(td);
            BindingSource source = new BindingSource();
            source.DataSource = TienDoController.getListTienDo();
            this.dataGridView1.DataSource = source;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns["Nhom"].Visible = false;
            this.dataGridView1.Columns["DeTai"].Visible = false;
           
        }
    }
}
