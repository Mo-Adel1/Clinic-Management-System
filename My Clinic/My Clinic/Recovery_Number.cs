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
    public partial class Recovery_Number : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static Recovery_Number RandumNumberForm;
        private static object lockObj = new object();
        private Recovery_Number()
        {
            InitializeComponent();
        }
        public static Recovery_Number RecoveryNumberForm()
        {
            if (RandumNumberForm == null || RandumNumberForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (RandumNumberForm == null || RandumNumberForm.IsDisposed)
                    {
                        RandumNumberForm = new Recovery_Number();
                    }
                }
            }
            return RandumNumberForm;
        }
        //////////////////////////////////////////////////////////////////////////////////




        private void button1_Click(object sender, EventArgs e)
        {
            string Rnumber = textBox1.Text;
            Facade obj = new Facade();
            if (Rnumber == "")
            {
                textBox1.Focus();
                MessageBox.Show("Please Enter The Code That You Have Recived");
            }
            else
            {
                obj.Recover_Account_Step2(Rnumber);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Recovery_Number_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.CreateLoginForm().Show();
        }
    }
}
