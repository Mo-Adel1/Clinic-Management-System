using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Clinic
{
    class Data
    {
        static string sqlquery1;
        static string sqlquery2;
        static string sqlquery3;

        static IRetrieveData obj1;
        static IRetrieveData obj2;
        static IRetrieveData obj3;

        public static DataTable dt_admin;
        public static DataTable dt_staff;
        public static DataTable dt_patient;

        public static void GetTables()
        {
            sqlquery1 = string.Format("SELECT * FROM ADMIN");
            sqlquery2 = string.Format("SELECT * FROM STAFF");
            sqlquery3 = string.Format("SELECT * FROM PATIENT");

            obj1 = new AdminDataProxy(sqlquery1);
            obj2 = new StaffDataProxy(sqlquery2);
            obj3 = new PatientDataProxy(sqlquery3);

            dt_admin = new DataTable();
            dt_staff = new DataTable();
            dt_patient = new DataTable();

            Data.FillTables();
        }
        private static void FillTables()
        {
            dt_admin = obj1.SelectData();
            dt_staff = obj2.SelectData();
            dt_patient = obj3.SelectData();
        }
    }
}
