using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Clinic
{
    public partial class All_Patients_form : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static All_Patients_form PatientsForm;
        private static object lockObj = new object();
        private All_Patients_form()
        {
            InitializeComponent();
        }
        public static All_Patients_form AllPatientsForm()
        {
            if (PatientsForm == null || PatientsForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (PatientsForm == null || PatientsForm.IsDisposed)
                    {
                         PatientsForm = new All_Patients_form();
                    }
                }
            }
            return PatientsForm;
        }


        private void All_Patients_form_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseConection.connect_return("SELECT * FROM PATIENT");
            dataGridView1.DataSource = dt;
            dataGridView1.ForeColor = Color.Black;
        }
    }
}
