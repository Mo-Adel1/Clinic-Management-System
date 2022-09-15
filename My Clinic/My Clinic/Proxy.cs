using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace My_Clinic
{
    public interface IRetrieveData
    {
        DataTable SelectData();
    }
    class AdminData : IRetrieveData
    {
        private string Sqlquery;
        public AdminData(string sqlquery)
        {
            this.Sqlquery = sqlquery;
        }
        public AdminData() { }
        public DataTable SelectData()
        {
            DataTable dt;
            dt = DatabaseConection.connect_return(Sqlquery);
            return dt;
        }
    }
    class AdminDataProxy : IRetrieveData
    {
        private AdminData Admins;
        private string Sqlquery;
        public AdminDataProxy(string sqlquery)
        {
            this.Sqlquery = sqlquery;
        }
        public AdminDataProxy(AdminData admins) // to clean the cache ---> Admins
        {
            this.Admins = admins;
        }
        public DataTable SelectData()
        {
            if (Admins == null)
            {
                Admins = new AdminData(Sqlquery);
            }
            return Admins.SelectData();
        }
    }
    class StaffData : IRetrieveData
    {
        private string Sqlquery;
        public StaffData(string sqlquery)
        {
            this.Sqlquery = sqlquery;
        }
        public StaffData() { }
        public DataTable SelectData()
        {
            DataTable dt;
            dt = DatabaseConection.connect_return(Sqlquery);
            return dt;
        }
    }
    class StaffDataProxy : IRetrieveData
    {
        private StaffData Staff;
        private string Sqlquery;
        public StaffDataProxy(string sqlquery)
        {
            this.Sqlquery = sqlquery;
        }

        public StaffDataProxy(StaffData staff)
        {
            this.Staff = staff;
        }

        public DataTable SelectData()
        {
            if (Staff == null)
            {
                Staff = new StaffData(Sqlquery);
            }
            return Staff.SelectData();
        }
    }
    class PatientData : IRetrieveData
    {
        private string Sqlquery;
        public PatientData(string sqlquery)
        {
            this.Sqlquery = sqlquery;
        }
        public PatientData() { }
        public DataTable SelectData()
        {
            DataTable dt;
            dt = DatabaseConection.connect_return(Sqlquery);
            return dt;
        }
    }
    class PatientDataProxy : IRetrieveData
    {
        private PatientData Patients;
        private string Sqlquery;
        public PatientDataProxy(string sqlquery)
        {
            this.Sqlquery = sqlquery;
        }

        public PatientDataProxy(PatientData patients)
        {
            this.Patients = patients;
        }

        public DataTable SelectData()
        {
            if (Patients == null)
            {
                Patients = new PatientData(Sqlquery);
            }
            return Patients.SelectData();
        }
    }
}
