using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace eHealthCare
{
    public partial class frmQLNV : Form
    {
        public frmQLNV()
        {
            InitializeComponent();
            
        }



        ConnectData c = new ConnectData();
        private void frmQLNV_Load(object sender, EventArgs e)
        {
            c.connnect();
            ShowData();
           
            // TODO: This line of code loads data into the 'qL_BENHVIENDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qL_BENHVIENDataSet.NHANVIEN);

           
        }

        
        

        private void frmQLNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            c.disconnect();
           
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE NHANVIEN SET [Họ và tên] = @HoTen, SĐT=@SDT, CCCD=@cccd, [Địa chỉ]=@Diachi, [Chức vụ]=@Chucvu WHERE [Mã nhân viên] = @Manhanvien";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@HoTen", txtTenNV.Text);
            cmd.Parameters.AddWithValue("@Manhanvien", txtMaNV.Text);
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("@cccd", txtCccd.Text);
            cmd.Parameters.AddWithValue("@Diachi", txtDC.Text);
            cmd.Parameters.AddWithValue("@Chucvu", txtCV.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật nhân viên thành công!");
                ShowData();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                c.conn.Close();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaNV.Text = dgv.Rows[numrow].Cells[0].Value.ToString();
            txtTenNV.Text = dgv.Rows[numrow].Cells[1].Value.ToString();
            txtCccd.Text = dgv.Rows[numrow].Cells[2].Value.ToString();
            txtSDT.Text = dgv.Rows[numrow].Cells[3].Value.ToString();
            txtDC.Text = dgv.Rows[numrow].Cells[4].Value.ToString();
            txtCV.Text = dgv.Rows[numrow].Cells[5].Value.ToString();

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            String query = "SELECT [Mã nhân viên], [Họ và tên], SĐT, CCCD, [Địa chỉ], [Chức vụ] " +
                           "FROM NHANVIEN " +
                           "WHERE [Mã nhân viên] LIKE '%" + txtTKMaNV.Text + "%' AND [Họ và tên] LIKE N'%" + txtTKHT.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
            adapter.Fill(data);
            dgv.DataSource = data.Tables[0];
        }

        private void ShowData()
        {
            DataSet data = new DataSet();
            String query = "Select [Mã nhân viên], [Họ và tên], SĐT, CCCD,[Địa chỉ],[Chức vụ] from NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
            adapter.Fill(data);
            dgv.DataSource = data.Tables[0];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (IsValidData())
            {
                string query = "INSERT INTO NHANVIEN ([Mã nhân viên], [Họ và tên], SĐT, CCCD,[Địa chỉ],[Chức vụ]) VALUES (@Manhanvien, @Tennhanvien,@SDT,@CCCD,@Diachi,@Chucvu)";
                SqlCommand cmd = new SqlCommand(query, c.conn);
                cmd.Parameters.AddWithValue("@Manhanvien", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@Tennhanvien", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@CCCD", txtCccd.Text);
                cmd.Parameters.AddWithValue("@Diachi", txtDC.Text);
                cmd.Parameters.AddWithValue("@Chucvu", txtCV.Text);
                try
                {
                    c.conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    ShowData();
                }
                catch (Exception ex)
                {
                  
                }
                finally
                {
                    c.conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm dữ liệu.");
            }
        }
        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text) ||
         string.IsNullOrWhiteSpace(txtCccd.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
         string.IsNullOrWhiteSpace(txtDC.Text) || string.IsNullOrWhiteSpace(txtCV.Text))
            {
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM NHANVIEN WHERE [Mã nhân viên] = @Manhanvien";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@Manhanvien", txtMaNV.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa nhân viên thành công!");
                ShowData();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                c.conn.Close();
            }
        }
    } 
}
