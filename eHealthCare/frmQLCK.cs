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
    public partial class frmQLCK : Form
    {
        public frmQLCK()
        {
            InitializeComponent();
        }

        ConnectData c = new ConnectData();
        private void frmQLCK_Load(object sender, EventArgs e)
        {
            c.connnect();
            ShowData();
        }
        private void ShowData()
        {
            DataSet data = new DataSet();
            String query = "Select  [Mã khoa], [Tên khoa] from CHUYENKHOA";
            SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
            adapter.Fill(data);
            dgv.DataSource = data.Tables[0];
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaKhoa.Text = dgv.Rows[numrow].Cells[0].Value.ToString();
            txtTenKhoa.Text = dgv.Rows[numrow].Cells[1].Value.ToString();
            
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO CHUYENKHOA ([Mã khoa], [Tên khoa]) VALUES (@MaKhoa, @TenKhoa)";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);
            cmd.Parameters.AddWithValue("@TenKhoa", txtTenKhoa.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm chuyên khoa thành công!");
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE CHUYENKHOA SET [Tên khoa] = @TenKhoa WHERE [Mã khoa] = @MaKhoa";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@TenKhoa", txtTenKhoa.Text);
            cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật chuyên khoa thành công!");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM CHUYENKHOA WHERE [Mã khoa] = @MaKhoa";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa chuyên khoa thành công!");
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

        private void btnTK_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            String query = "SELECT  [Mã khoa], [Tên khoa]" +
                           "FROM CHUYENKHOA " +
                           "WHERE  [Mã khoa] LIKE '%" + txtTKMakhoa.Text + "%' AND [Tên khoa] LIKE N'%" + txtTKTK.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
            adapter.Fill(data);
            dgv.DataSource = data.Tables[0];
        }
    }
}
