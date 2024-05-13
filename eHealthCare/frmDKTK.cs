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
    public partial class frmDKTK : Form
    {
        public frmDKTK()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {

            // Kiểm tra tính hợp lệ của thông tin đăng ký
            if (IsValidRegistration())
            {
                // Lưu thông tin tài khoản vào cơ sở dữ liệu
                if (SaveAccountToDatabase())
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!");
                    // Sau khi đăng ký thành công, có thể chuyển đến form đăng nhập hoặc form chính của ứng dụng
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin tài khoản. Vui lòng thử lại sau.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng ký và kiểm tra lại tính hợp lệ của thông tin.");
            }
        }
        // Hàm kiểm tra tính hợp lệ của thông tin đăng ký
        private bool IsValidRegistration()
        {
            // Thực hiện các kiểm tra hợp lệ của thông tin đăng ký, chẳng hạn như kiểm tra rỗng, độ dài, v.v.
            if (string.IsNullOrEmpty(txtDKTenDN.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtDKMK.Text) || string.IsNullOrEmpty(txtNLMK.Text))
            {
                return false;
            }
            // Các kiểm tra khác...

            return true;
        }

        // Hàm lưu thông tin tài khoản vào cơ sở dữ liệu
        private bool SaveAccountToDatabase()
        {
            try
            {
                // Thực hiện kết nối đến cơ sở dữ liệu
                ConnectData c = new ConnectData();
                c.connnect();

                // Tạo câu lệnh SQL để chèn thông tin tài khoản vào bảng DANGNHAP
                string sql = "INSERT INTO DANGNHAP (username, password, email) VALUES (@username, @password, @email)";
                SqlCommand com = new SqlCommand(sql, c.conn);

                // Thay thế các tham số trong câu lệnh SQL với các giá trị từ các TextBox
                com.Parameters.AddWithValue("@username", txtDKTenDN.Text);
                com.Parameters.AddWithValue("@password", txtDKMK.Text);
                com.Parameters.AddWithValue("@email", txtEmail.Text);

                // Thực hiện câu lệnh SQL
                com.ExecuteNonQuery();

                // Đóng kết nối đến cơ sở dữ liệu
                c.disconnect();

                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi lưu thông tin tài khoản
                // Log lỗi, hiển thị thông báo, v.v.
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.ShowDialog();
        }
    }
}
