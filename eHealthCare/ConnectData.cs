using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eHealthCare
{
    public class ConnectData
    {

        public SqlConnection conn;
        
        public void connnect()
        {

            String strCon = @"Data Source=LAPTOP-J4RD80QQ\MSSQLSERVER01;Initial Catalog=QL_BENHVIEN;Integrated Security=True;Encrypt=False";
            
            try
            {
                conn = new SqlConnection(strCon);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void disconnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }
        public Boolean exeSQL(String cmd)
        {
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                sc.ExecuteNonQuery();
                return true;    
            }
            catch(Exception) 
            {
                return false;
            }
        }
        
    }
}
