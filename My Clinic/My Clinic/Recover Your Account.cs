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
    public partial class Recover_Your_Account : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static Recover_Your_Account RecoverAccountForm;
        private static object lockObj = new object();
        private Recover_Your_Account()
        {
            InitializeComponent();
        }
        public static Recover_Your_Account RecoverYourAccountForm()
        {
            if (RecoverAccountForm == null || RecoverAccountForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (RecoverAccountForm == null || RecoverAccountForm.IsDisposed)
                    {
                        RecoverAccountForm = new Recover_Your_Account();
                    }
                }
            }
            return RecoverAccountForm;
        }

        /////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            Facade obj;
            if (email=="")
            {
                MessageBox.Show("Please Enter Your Email");
                textBox1.Focus();
            }
            else
            {
                obj = new Facade(email);
                obj.Recover_Account_Step1();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Recover_Your_Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.CreateLoginForm().Show();
        }
    }
}
