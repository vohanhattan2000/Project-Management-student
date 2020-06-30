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
    public partial class frmSinhVien : Form
    {
        private bool flag = false;
        public frmSinhVien()
        {
            InitializeComponent();            
            this.cMaSV.DataPropertyName = nameof(SinhVien.MaSV);
            this.cHoTenSV.DataPropertyName = nameof(SinhVien.TenSV);
            this.cGioiTinh.DataPropertyName = nameof(SinhVien.GioiTinh);
            this.cNgaySinh.DataPropertyName = nameof(SinhVien.NgaySinh);
            this.cDiaChiSV.DataPropertyName = nameof(SinhVien.DiaChi);
            this.cEmailSV.DataPropertyName = nameof(SinhVien.EmailSV);
            this.cDienThoaiSV.DataPropertyName = nameof(SinhVien.DienThoai);
            this.cNhom.DataPropertyName = nameof(SinhVien.MaNhom);
            BindingSource source = new BindingSource();
            source.DataSource = SinhVienController.getListSV();
            this.dgrDSSV.DataSource = source;
            //  dgrDSSV.AutoGenerateColumns = false;

            List<Nhom> searchnhom = SinhVienController.getListNhom();

            for (int i = 0; i < searchnhom.Count; i++)
            {
                this.cboNhom.Items.Add(searchnhom[i]);
            }

        }

        private void dgrDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            if (this.txtHoTen.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtHoTen, "Phai nhap Ho ten sinh vien");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtHoTen, null);
            if (this.txtMaSV.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtMaSV, "Phai nhap ma so sinh vien");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtMaSV, null);
            if (this.cboNhom.Text.Trim().Length <= 0)
            {
                this.errorProvider3.SetError(this.cboNhom, "Phai chon nhom");
                dem++;
            }
            else this.errorProvider3.SetError(this.cboNhom, null);


            if (this.cboGioiTinh.Text.Trim().Length <= 0)
            {
                this.errorProvider5.SetError(this.cboGioiTinh, "Phai chon gioi tinh sinh vien");
                dem++;
            }
            else this.errorProvider5.SetError(this.cboGioiTinh, null);
            if (this.dateTimeBirthday.Text.Trim().Length <= 0)
            {
                this.errorProvider6.SetError(this.dateTimeBirthday, "Phai chon ngay thang nam sinh cua sinh vien");
                dem++;
            }
            else this.errorProvider6.SetError(this.dateTimeBirthday, null);
            if (this.txtDiaChi.Text.Trim().Length <= 0)
            {
                this.errorProvider7.SetError(this.txtDiaChi, "Phai chon dia chi sinh vien");
                dem++;
            }
            else this.errorProvider7.SetError(this.txtDiaChi, null);
            if (this.txtEmail.Text.Trim().Length <= 0)
            {
                this.errorProvider8.SetError(this.txtEmail, "Phai chon Email sinh vien");
                dem++;
            }
            else this.errorProvider8.SetError(this.txtEmail, null);
            if (this.txtSDT.Text.Trim().Length <= 0)
            {
                this.errorProvider9.SetError(this.txtSDT, "Phai chon so dien thoai sinh vien");
                dem++;
            }
            else this.errorProvider9.SetError(this.txtSDT, null);
            
           

            DateTime ht = DateTime.Now;
            TimeSpan k = ht - dateTimeBirthday.Value; //ht.Subtract(dateFrom.Value);
            int ss = int.Parse(Math.Round(k.TotalDays).ToString());
            if (ss < 6570)
            {
                this.errorProvider4.SetError(this.dateTimeBirthday, "phai tren 18 tuoi");
                dem++;
            }
            else this.errorProvider4.SetError(this.dateTimeBirthday, null);
            if (dem != 0)
                return;
            SinhVien sv = new SinhVien();
            sv.MaSV = this.txtMaSV.Text.Trim();
            sv.TenSV = this.txtHoTen.Text.Trim();
            sv.GioiTinh = this.cboGioiTinh.Text.Trim();
            sv.NgaySinh = this.dateTimeBirthday.Value;
            sv.DiaChi = this.txtDiaChi.Text.Trim();
            sv.DienThoai = this.txtSDT.Text.Trim();
            sv.EmailSV = this.txtEmail.Text.Trim();
            sv.MaNhom = this.cboNhom.Text.Trim();
            if (SinhVienController.AddSV(sv) == false)
            {
                MessageBox.Show("Mã sinh viên bị trùng");
                return;
            }
            SinhVienController.AddSV(sv);
            BindingSource source = new BindingSource();
            source.DataSource = SinhVienController.getListSV();
            this.dgrDSSV.DataSource = source;

        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboNhom_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dgrDSSV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }
           
                SinhVien sv = SinhVienController.getSV(this.dgrDSSV.SelectedRows[0].Cells[0].Value.ToString());
                SinhVienController.DeleteSV(sv);                                            
            //Hiển thị
            BindingSource source = new BindingSource();
            source.DataSource = SinhVienController.getListSV();
            this.dgrDSSV.DataSource = source;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dem = 0;
            if (this.txtHoTen.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtHoTen, "Phai nhap Ho ten sinh vien");
                dem++;
            }
            else this.errorProvider1.SetError(this.txtHoTen, null);
            if (this.txtMaSV.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtMaSV, "Phai nhap ma so sinh vien");
                dem++;
            }
            else this.errorProvider2.SetError(this.txtMaSV, null);



            if (this.cboGioiTinh.Text.Trim().Length <= 0)
            {
                this.errorProvider5.SetError(this.cboGioiTinh, "Phai chon gioi tinh sinh vien");
                dem++;
            }
            else this.errorProvider5.SetError(this.cboGioiTinh, null);
            if (this.dateTimeBirthday.Text.Trim().Length <= 0)
            {
                this.errorProvider6.SetError(this.dateTimeBirthday, "Phai chon ngay thang nam sinh cua sinh vien");
                dem++;
            }
            else this.errorProvider6.SetError(this.dateTimeBirthday, null);
            if (this.txtDiaChi.Text.Trim().Length <= 0)
            {
                this.errorProvider7.SetError(this.txtDiaChi, "Phai chon dia chi sinh vien");
                dem++;
            }
            else this.errorProvider7.SetError(this.txtDiaChi, null);
            if (this.txtEmail.Text.Trim().Length <= 0)
            {
                this.errorProvider8.SetError(this.txtEmail, "Phai chon Email sinh vien");
                dem++;
            }
            else this.errorProvider8.SetError(this.txtEmail, null);
            if (this.txtSDT.Text.Trim().Length <= 0)
            {
                this.errorProvider9.SetError(this.txtSDT, "Phai chon so dien thoai sinh vien");
                dem++;
            }
            else this.errorProvider9.SetError(this.txtSDT, null);



            DateTime ht = DateTime.Now;
            TimeSpan k = ht - dateTimeBirthday.Value; //ht.Subtract(dateFrom.Value);
            int ss = int.Parse(Math.Round(k.TotalDays).ToString());
            if (ss < 6570)
            {
                this.errorProvider4.SetError(this.dateTimeBirthday, "phai tren 18 tuoi");
                dem++;
            }
            else this.errorProvider4.SetError(this.dateTimeBirthday, null);
            if (dem != 0)
                return;
            if (flag == true)
            {
                try
                {
                    this.dgrDSSV.SelectedCells[0].Value = this.txtMaSV.Text.Trim();
                    this.dgrDSSV.SelectedCells[1].Value = this.txtHoTen.Text.Trim();
                    this.dgrDSSV.SelectedCells[2].Value = this.cboNhom.Text.Trim();
                    this.dgrDSSV.SelectedCells[7].Value = this.dateTimeBirthday.Value;
                    this.dgrDSSV.SelectedCells[3].Value = this.cboGioiTinh.Text.Trim();
                    this.dgrDSSV.SelectedCells[4].Value = this.txtDiaChi.Text.Trim();
                    this.dgrDSSV.SelectedCells[6].Value = this.txtSDT.Text.Trim();
                    this.dgrDSSV.SelectedCells[5].Value = this.txtEmail.Text.Trim();
                }
                catch
                {
                    MessageBox.Show("Hãy nhấn vào ô trống đầu tiên của mỗi dòng để chọn dòng cần cập nhật!");
                    return;
                }
            }
            flag = false;
            SinhVien sv = new SinhVien();
            sv.MaSV = this.txtMaSV.Text.Trim();
            sv.TenSV = this.txtHoTen.Text.Trim();
            sv.GioiTinh = this.cboGioiTinh.Text.Trim();
            sv.NgaySinh = Convert.ToDateTime(this.dateTimeBirthday.Value);
            sv.DiaChi = this.txtDiaChi.Text.Trim();
            sv.DienThoai = this.txtSDT.Text.Trim();
            sv.EmailSV = this.txtEmail.Text.Trim();
            sv.MaNhom = this.cboNhom.Text.Trim();
           
            SinhVienController.UpdateSV(sv);
            BindingSource source = new BindingSource();
            source.DataSource = SinhVienController.getListSV();
            this.dgrDSSV.DataSource = source;
        }

        private void dgrDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.txtMaSV.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.txtHoTen.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.cboNhom.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[2].Value.ToString();
             this.dateTimeBirthday.Value = DateTime.Parse(this.dgrDSSV.Rows[e.RowIndex].Cells[7].Value.ToString());
           // MessageBox.Show(this.dgrDSSV.Rows[e.RowIndex].Cells[7].Value.ToString());
            this.cboGioiTinh.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.txtDiaChi.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.txtSDT.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.txtEmail.Text = this.dgrDSSV.Rows[e.RowIndex].Cells[5].Value.ToString();

            flag = true;
        }

        private void dgrDSSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgrDSSV.Columns["Nhom"].Visible = false;          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(this.dgrDSSV.SelectedCells[7].ToString());
        }
    }
}
