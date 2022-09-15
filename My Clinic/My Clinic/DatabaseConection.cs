using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace My_Clinic
{
    class DatabaseConection
    {
        public static void connect(string statement)
        {
            string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dr\Desktop\My Clinic(v5)\My Clinic\CLINIC_DATABASE.mdf";
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand(statement,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static DataTable connect_return(string statement)
        {
            string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dr\Desktop\My Clinic(v5)\My Clinic\CLINIC_DATABASE.mdf";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(statement, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;  
        }
    }
}
