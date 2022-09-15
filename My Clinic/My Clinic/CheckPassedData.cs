using System;
using System.Data;
using System.Windows.Forms;
namespace My_Clinic
{
    
    class CheckPassedData
    {
        public static string checklogeddata(string username,string password)
        {
            
            string direction = "";
            goto condetion1;
            condetion1:
            try
            {
                DataRow[] rows = Data.dt_admin.Select(string.Format("ADMIN_USERNAME = '{0}'",username));
                string user_name = rows[0][0].ToString();
                string Password = rows[0][1].ToString();
                if (username == user_name && password == Password)
                {
                    direction = "admin";
                }
            }
            catch(Exception)
            {
                goto condetion2;
            }

            condetion2:
            try
            {
                DataRow[] rows = Data.dt_staff.Select(string.Format("STAFF_USERNAME = '{0}'", username));
                string user_name = rows[0][1].ToString();
                string Password = rows[0][2].ToString();
                if (username == user_name && password == Password)
                {
                    direction = "user";
                }
            }
            catch (Exception)
            {
                goto condetion3;
            }
            condetion3:
            if (direction =="")
            {
                direction = "no";
            }
            return direction;
        }
        public static bool checkemail(string Email)
        {
            bool exist = false;
            try
            {
                DataRow[] rows = Data.dt_admin.Select(string.Format("USER_EMAIL = '{0}'", Email));
                string em = rows[0][2].ToString();
                if (em == Email)
                {
                    exist = true;
                    goto condetion2;
                }
            }
            catch (Exception)
            {
                goto condetion1;
            }
            condetion1:
            try
            {
                DataRow[] rows = Data.dt_staff.Select(string.Format("STAFF_EMAIL = '{0}'", Email));
                string em = rows[0][6].ToString();
                if (em == Email)
                {
                    exist = true;
                    goto condetion2;
                }
            }
            catch (Exception)
            {
                exist = false;
                goto condetion2;
            }
            condetion2:
            return exist;
        }
    }
}
