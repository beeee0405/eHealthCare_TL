using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHealthCare
{
    public partial class frmMHchinh : Form
    {
        public frmMHchinh()
        {
            InitializeComponent();
        }

        private void quảnLýChuyênKhoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("frmQLCK"))
            {
                frmQLCK frm = new frmQLCK();
                frm.MdiParent = this;
                frm.Name = "frmQLCK";
                frm.Show();
            }
            else
            {
                ActiveChildForm("frmQLCK");
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("frmQLNV"))
            {
                frmQLNV frm = new frmQLNV();
                frm.MdiParent = this;
                frm.Name = "frmQLNV";
                frm.Show();
            }
            else
            {
                ActiveChildForm("frmQLNV");
            }
        }

        private void frmMHchinh_Load(object sender, EventArgs e)
        {
            
        }
        private bool CheckExitsForm(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }    
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach(Form frm in this.MdiChildren)
            { if (frm.Name == name)
                {
                    frm.Activate();
                    break;  
                } }
        }

        private void quảnLýBệnhÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("frmQLBA"))
            {
                frmQLBA frm = new frmQLBA();
                frm.MdiParent = this;
                frm.Name = "frmQLBA";
                frm.Show();
            }
            else
            {
                ActiveChildForm("frmQLBA");
            }
        }

        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("frmQLThuoc"))
            {
                frmQLThuoc frm = new frmQLThuoc();
                frm.MdiParent = this;
                frm.Name = "frmQLThuoc";
                frm.Show();
            }
            else
            {
                ActiveChildForm("frmQLThuoc");
            }
        }

       

        private void nhậnSốKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("frmChonCK"))
            {
                frmChonCK frm = new frmChonCK();
                frm.MdiParent = this;
                frm.Name = "frmChonCK";
                frm.Show();
            }
            else
            {
                ActiveChildForm("frmChonCK");
            }
        }
    }
}
