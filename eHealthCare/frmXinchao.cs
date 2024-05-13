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
    public partial class frmXinchao : Form
    {
        public frmXinchao()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMHchinh f = new frmMHchinh();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age;
            if (!int.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Tuổi phải là một số nguyên.");
                return;
            }
            string gender = cbxGt.SelectedItem.ToString();

            string greeting = "";
            if (gender == "Nam")
            {
                if (age <= 10)
                {
                    greeting = "Xin chào em trai!";
                }
                else if (age <= 18)
                {
                    greeting = "Xin chào anh chàng!";
                }
                else
                {
                    greeting = "Xin chào bác trai!";
                }
            }
            else // Nếu giới tính là Nữ
            {
                if (age <= 10)
                {
                    greeting = "Xin chào em gái!";
                }
                else if (age <= 18)
                {
                    greeting = "Xin chào cô gái!";
                }
                else
                {
                    greeting = "Xin chào bác gái!";
                }
            }

            lblDisplay.Text = greeting;
        }
    }
}
