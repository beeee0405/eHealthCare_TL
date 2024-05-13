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
    public partial class frmDoiMK : Form
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        ConnectData c = new ConnectData();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDMK.Text;
            string matKhauCu = txtMKCu.Text;
            string matKhauMoi = txtMKMoi.Text;
            string xacNhanMatKhau = txtNL.Text;

            // Kiểm tra tính hợp lệ của dữ liệu nhập vào
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhanMatKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra xác thực mật khẩu cũ
            if (!IsMatKhauCuDung(tenDangNhap, matKhauCu))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.");
                return;
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp.");
                return;
            }

            // Cập nhật mật khẩu mới vào cơ sở dữ liệu
            if (UpdateMatKhau(tenDangNhap, matKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công.");
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng thử lại sau.");
            }
        }
        private bool IsMatKhauCuDung(string tenDangNhap, string matKhauCu)
        {
            // Kiểm tra xem mật khẩu cũ có trùng khớp với mật khẩu trong cơ sở dữ liệu hay không
            string matKhauTrongCSDL = GetMatKhauByTenDangNhap(tenDangNhap);
            return matKhauTrongCSDL == matKhauCu;
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
        private bool UpdateMatKhau(string tenDangNhap, string matKhauMoi)
        {
            SqlTransaction transaction = null;

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                c.connnect();

                // Bắt đầu transaction
                transaction = c.conn.BeginTransaction();

                // Tạo câu lệnh SQL để cập nhật mật khẩu mới
                string query = "UPDATE DANGNHAP SET password = @matKhauMoi WHERE username = @tenDangNhap";
                SqlCommand command = new SqlCommand(query, c.conn, transaction);
                command.Parameters.AddWithValue("@matKhauMoi", matKhauMoi);
                command.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                // Thực hiện câu lệnh SQL
                int rowsAffected = command.ExecuteNonQuery();

                // Commit transaction
                transaction.Commit();

                if (rowsAffected > 0)
                {
                    return true; // Cập nhật mật khẩu thành công
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật mật khẩu mới: " + ex.Message);

                // Rollback transaction nếu có lỗi
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                // Đóng kết nối đến cơ sở dữ liệu
                c.disconnect();
            }

            return false; // Cập nhật mật khẩu không thành công
        }
    }
}
