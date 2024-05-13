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
    public partial class frmQLThuoc : Form
    {
        public frmQLThuoc()
        {
            InitializeComponent();
        }
        ConnectData c = new ConnectData();
        private void frmQLThuoc_Load(object sender, EventArgs e)
        {
            c.connnect();
            ShowData();
        }
        private void ShowData()
        {
            DataSet data = new DataSet();
            String query = "Select  [Mã thuốc], [Tên thuốc], [Số lượng], [Giá thuốc] from THUOC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
            adapter.Fill(data);
            dgv.DataSource = data.Tables[0];
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaThuoc.Text = dgv.Rows[numrow].Cells[0].Value.ToString();
            txtTenThuoc.Text = dgv.Rows[numrow].Cells[1].Value.ToString();
            txtSL.Text = dgv.Rows[numrow].Cells[2].Value.ToString();
            txtGT.Text = dgv.Rows[numrow].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO THUOC ([Mã thuốc], [Tên thuốc], [Số lượng], [Giá thuốc]) VALUES (@Mathuoc, @Tenthuoc, @soluong, @giathuoc)";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@Mathuoc", txtMaThuoc.Text);
            cmd.Parameters.AddWithValue("@Tenthuoc", txtTenThuoc.Text);
            cmd.Parameters.AddWithValue("@soluong", txtSL.Text);
            cmd.Parameters.AddWithValue("@giathuoc", txtGT.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thuốc thành công!");
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

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE THUOC SET [Tên thuốc] = @Tenthuoc,[Số lượng]= @soluong,[Giá thuốc]=@giathuoc WHERE [Mã thuốc] = @Mathuoc";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@Tenthuoc", txtTenThuoc.Text);
            cmd.Parameters.AddWithValue("@Mathuoc", txtMaThuoc.Text);
            cmd.Parameters.AddWithValue("@soluong", txtSL.Text);
            cmd.Parameters.AddWithValue("@giathuoc", txtGT.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thuốc thành công!");
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
            string query = "DELETE FROM THUOC WHERE [Mã thuốc] = @Mathuoc";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@Mathuoc", txtMaThuoc.Text);

            try
            {
                c.conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thuốc thành công!");
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
            String query = "SELECT  [Mã thuốc], [Tên thuốc]" +
                           "FROM THUOC " +
                           "WHERE  [Mã thuốc] LIKE '%" + txtTKMaThuoc.Text + "%' AND [Tên thuốc LIKE N'%" + txtTKTT.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
            adapter.Fill(data);
            dgv.DataSource = data.Tables[0];
        }
    }
}
