using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Clinic
{
    public partial class Login : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static Login LoginForm;
        private static object lockObj = new object();
        private Login()
        {
            InitializeComponent();
        }
        public static Login CreateLoginForm()
        {
            if (LoginForm == null || LoginForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (LoginForm == null || LoginForm.IsDisposed)
                    {
                        LoginForm = new Login();
                    }
                }
            }
            return LoginForm;
        }
        ////////////////////////////////////////////////////////////////////////////
        


        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            toolTip6.Active = false;
            Data.GetTables();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Image hide = new Bitmap(@"C:\Users\dr\Desktop\My Clinic(v5)\My Clinic\Clinic images and icons\icons\show.png");
        
            Image show = new Bitmap(@"C:\Users\dr\Desktop\My Clinic(v5)\My Clinic\Clinic images and icons\icons\hide.png");
           
            if (textBox2.PasswordChar == '*')
            {
                
                button2.BackgroundImage = hide;
                textBox2.PasswordChar='\0';
                toolTip5.Active = false;
                toolTip6.Active = true;
            }
            else
            {
               
                button2.BackgroundImage = show;
                textBox2.PasswordChar = '*';
                toolTip5.Active = true;
                toolTip6.Active = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if ((textBox1.Text == "" && textBox2.Text == ""))
            {
                MessageBox.Show("Enter your data!");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The User Name!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter The Password!");
            }
            else
            {
                string dirction = CheckPassedData.checklogeddata(username, password);
           
                if (dirction == "no")
                {
                    MessageBox.Show("The user name or password is incorect");
                }
                else if (dirction == "admin")
                {
                    Admin_Form.CreateAdminForm().Show();
                    textBox1.Clear();
                    textBox2.Clear();
                   // this.Hide();
                }
                else
                {
                    User.CreateUserForm().Show();
                    textBox1.Clear();
                    textBox2.Clear();
                  //  this.Hide();
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Recover_Your_Account.RecoverYourAccountForm().Show();
        }
    }
}