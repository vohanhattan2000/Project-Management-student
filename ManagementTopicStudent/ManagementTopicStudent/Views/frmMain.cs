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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            frmSinhVien frmsv = new frmSinhVien();
            frmsv.Show();
        }

        private void btnQLGV_Click(object sender, EventArgs e)
        {
            frmGiaoVien frmgv = new frmGiaoVien();
            frmgv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNhom frmnhom = new frmNhom();
            frmnhom.Show();
        }

        private void btnQLDT_Click(object sender, EventArgs e)
        {
            frmDeTai frmDT = new frmDeTai();
            frmDT.Show();
        }

        private void btnTienDo_Click(object sender, EventArgs e)
        {
            frmTienDo frmTD = new frmTienDo();
            frmTD.Show();
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem formsearch = new frmTimKiem();
            formsearch.Show();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiem formsearch = new frmTimKiem();
            formsearch.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout formAbout = new frmAbout();
            formAbout.Show();
        }
    }
}
