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
    public partial class All_Staff_Form : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static All_Staff_Form StaffForm;
        private static object lockObj = new object();
        private All_Staff_Form()
        {
            InitializeComponent();
        }
        public static All_Staff_Form AllStaffForm()
        {
            if (StaffForm == null || StaffForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (StaffForm == null || StaffForm.IsDisposed)
                    {
                        StaffForm = new All_Staff_Form();
                    }
                }
            }
            return StaffForm;
        }
        ///////////////////////////////////////////////////////////////////////


        private void All_Staff_Form_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseConection.connect_return("SELECT * FROM STAFF");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns.RemoveAt(7);
            dataGridView1.Columns.RemoveAt(10);
            dataGridView1.ForeColor = Color.Blue;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void All_Staff_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
