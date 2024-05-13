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
    public partial class frmChonCK : Form
    {
        public frmChonCK()
        {
            InitializeComponent();
        }
        private bool CheckExitsForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
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
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("frmDkykhambenh"))
            {
                frmDkykhambenh frm = new frmDkykhambenh();
                
                frm.Name = "frmDkykhambenh";
                frm.Show();
            }
            else
            {
                ActiveChildForm("frmDkykhambenh");
            }
        }
    }
}
