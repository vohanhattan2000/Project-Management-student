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
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
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

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "")
            //{
            //    BindingSource source = new BindingSource();
            //    source.DataSource = DeTaiController.getListDT();
            //    this.dataGridView1.DataSource = source;
            //}
            //else
            //{


                if (this.cboTimKiem.SelectedIndex == 0)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = TimKiemController.getListMaDT(textBox1.Text);
                    this.dataGridView1.DataSource = source;
                }
                if (this.cboTimKiem.SelectedIndex == 1)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = TimKiemController.getListTenDT(textBox1.Text);
                    this.dataGridView1.DataSource = source;
                }
                if (this.cboTimKiem.SelectedIndex == 2)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = TimKiemController.getListLoaiDT(textBox1.Text);
                    this.dataGridView1.DataSource = source;
                }
                if (this.cboTimKiem.SelectedIndex == 3)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = TimKiemController.getListNhomDT(textBox1.Text);
                    this.dataGridView1.DataSource = source;
                }
                if (this.cboTimKiem.SelectedIndex == 4)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = TimKiemController.getListGiaoVienDT(textBox1.Text);
                    this.dataGridView1.DataSource = source;
                }
                if (this.cboTimKiem.SelectedIndex == 5)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = TimKiemController.getListNoiDungDT(textBox1.Text);
                    this.dataGridView1.DataSource = source;
                }

           // }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.cboTimKiem.SelectedIndex == 0)
            {
                BindingSource source = new BindingSource();
                source.DataSource = TimKiemController.getListMaDT(textBox1.Text);
                this.dataGridView1.DataSource = source;
            }
            if (this.cboTimKiem.SelectedIndex == 1)
            {
                BindingSource source = new BindingSource();
                source.DataSource = TimKiemController.getListTenDT(textBox1.Text);
                this.dataGridView1.DataSource = source;
            }
            if (this.cboTimKiem.SelectedIndex == 2)
            {
                BindingSource source = new BindingSource();
                source.DataSource = TimKiemController.getListLoaiDT(textBox1.Text);
                this.dataGridView1.DataSource = source;
            }
            if (this.cboTimKiem.SelectedIndex == 3)
            {
                BindingSource source = new BindingSource();
                source.DataSource = TimKiemController.getListNhomDT(textBox1.Text);
                this.dataGridView1.DataSource = source;
            }
            if (this.cboTimKiem.SelectedIndex == 4)
            {
                BindingSource source = new BindingSource();
                source.DataSource = TimKiemController.getListGiaoVienDT(textBox1.Text);
                this.dataGridView1.DataSource = source;
            }
            if (this.cboTimKiem.SelectedIndex == 5)
            {
                BindingSource source = new BindingSource();
                source.DataSource = TimKiemController.getListNoiDungDT(textBox1.Text);
                this.dataGridView1.DataSource = source;
            }


        }
    }
}
