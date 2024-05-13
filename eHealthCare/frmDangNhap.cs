using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHealthCare
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connnect();
            string sql = "Select * from DANGNHAP where username = '" +txtTenDN.Text+"' and password = '" +txtMK.Text+ " ' ";
            SqlCommand com = new SqlCommand(sql, c.conn);
            SqlDataReader reader = com.ExecuteReader();
            if(reader.Read()==false)
            {
                MessageBox.Show("Dang nhap khong thanh cong !");
                txtTenDN.Text = "";
                txtMK.Text = "";
                txtTenDN.Focus();
            }
            else
            {
                this.Hide();
                frmXinchao f = new frmXinchao();
                f.Show();
            }
            c.disconnect();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDKTK f = new frmDKTK();
            f.Show();
        }
    }
}
