using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace eHealthCare
{
    public partial class frmDkykhambenh : Form
    {
        public frmDkykhambenh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtXuat.ResetText();
            txtHoTen.ResetText();
            txtNgay.ResetText(); 
            txtThang. ResetText();
            txtNam.ResetText(); 
            lbDsdachon.Items.Clear();
        }

        private void frmDkykhambenh_Load(object sender, EventArgs e)
        {
            this.lbChonbs.Items.Add("Phạm Thịnh Vượng");
            this.lbChonbs.Items.Add("Nguyễn Văn A");
            


            this.lbChondv.Items.Add("Siêu Âm");
            this.lbChondv.Items.Add("Thử Máu");
            this.lbChondv.Items.Add("Nội Soi");
            this.lbChondv.Items.Add("X-Quang");
        }

        private void lbChondv_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbDsdachon.Items.Add(lbChonbs.SelectedItem.ToString());
            this.lbDsdachon.Items.Add(lbChondv.SelectedItem.ToString());
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i;
            int n = lbDsdachon.Items.Count;
            txtXuat.Text = " Họ tên : " +txtHoTen.Text + "\r\n Ngày sinh : " + txtNgay.Text + " / " + txtThang.Text + " / " + txtNam.Text + "\r\n Bác sĩ và dịch vụ đã chọn : ";
            for (i = 0; i < n; i++)
            {
                lbDsdachon.SelectedIndex = i;
                txtXuat.Text += lbDsdachon.Text + ", ";
            }
        }
        private int appointmentNumber = 1; 
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem khách hàng đã chọn bác sĩ và dịch vụ chưa
            if (lbChonbs.SelectedItem != null && lbChondv.SelectedItem != null)
            {
                // Hiển thị số khám tương ứng cho khách hàng và tăng số thứ tự
                MessageBox.Show($"Thanh toán thành công! Số khám của bạn là: A{appointmentNumber++}");
            }
            else
            {
                // Nếu chưa chọn bác sĩ hoặc dịch vụ, hiển thị thông báo yêu cầu chọn
                MessageBox.Show("Vui lòng chọn bác sĩ và dịch vụ trước khi thanh toán.");
            }
        }
    }
}
