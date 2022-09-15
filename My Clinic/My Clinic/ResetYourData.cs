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
    public partial class ResetYourData : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static ResetYourData ResetDataForm;
        private static object lockObj = new object();
        private ResetYourData()
        {
            InitializeComponent();
        }
        public static ResetYourData ResetYourDataForm()
        {
            if (ResetDataForm == null || ResetDataForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (ResetDataForm == null || ResetDataForm.IsDisposed)
                    {
                        ResetDataForm = new ResetYourData();
                    }
                }
            }
            return ResetDataForm;
        }
        /////////////////////////////////////////////////////////////////////



        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirm_password = textBox3.Text;
            Facade obj;
            if (username == "" && password == "" && confirm_password=="")
            {
                MessageBox.Show("Please Enter Your Data");
            }
            else if(username == "" && password == "")
            {
                MessageBox.Show("Please Enter Your Data");
            }
            else if (username == "")
            {
                MessageBox.Show("Please Enter The User Name");
            }
            else if (password == "")
            {
                MessageBox.Show("Please Enter The Password");
            }
            else if (confirm_password == "")
            {
                MessageBox.Show("Please Confirm Your Password");
            }
            else if (password != confirm_password)
            {
                MessageBox.Show("Wrong Confirmation");
                textBox3.Focus();
            }
            else 
            {
                obj = new Facade(username, password);
                obj.Recover_Account_Step3();
                this.Close();
                AdminDataProxy p = new AdminDataProxy(new AdminData());
                Data.GetTables();
                MessageBox.Show("Please Login again using the new user name and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetYourData_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.CreateLoginForm().Show();
        }
    }
}
