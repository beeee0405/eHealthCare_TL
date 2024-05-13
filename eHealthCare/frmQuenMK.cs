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
    public partial class frmQuenMK : Form
    {
        public frmQuenMK()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLLMK_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenQMK.Text.Trim();
            // Kiểm tra xem tên đăng nhập có tồn tại trong cơ sở dữ liệu không
            if (IsTenDangNhapExist(tenDangNhap))
            {
                // Lấy lại mật khẩu cho tên đăng nhập từ cơ sở dữ liệu
                string matKhau = GetMatKhauByTenDangNhap(tenDangNhap);
                MessageBox.Show($"Mật khẩu của bạn là: {matKhau}");
            }
            else
            {
                MessageBox.Show("Tên đăng nhập không tồn tại trong hệ thống. Vui lòng kiểm tra lại.");
            }
        }
        ConnectData c = new ConnectData();
        private bool IsTenDangNhapExist(string tenDangNhap)
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
               
                    c.connnect();

                    // Tạo câu lệnh SQL để kiểm tra tên đăng nhập
                    string query = "SELECT COUNT(*) FROM DANGNHAP WHERE username = @tenDangNhap";
                    SqlCommand command = new SqlCommand(query, c.conn);
                    command.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                    // Thực hiện truy vấn và kiểm tra kết quả
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        return true; // Tên đăng nhập tồn tại trong cơ sở dữ liệu
                    }
                
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi khi kiểm tra tên đăng nhập: " + ex.Message);
            }

            return false; // Tên đăng nhập không tồn tại trong cơ sở dữ liệu
        }

        private string GetMatKhauByTenDangNhap(string tenDangNhap)
        {
            string matKhau = "";

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
               
                    c.connnect();

                    // Tạo câu lệnh SQL để lấy mật khẩu tương ứng với tên đăng nhập
                    string query = "SELECT password FROM DANGNHAP WHERE username = @tenDangNhap";
                    SqlCommand command = new SqlCommand(query, c.conn);
                    command.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                    // Thực hiện truy vấn và lấy mật khẩu
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        matKhau = result.ToString();
                    }
                
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi khi lấy mật khẩu: " + ex.Message);
            }

            return matKhau;
        }
    }
}
