using System;
using System.Collections;
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
    public partial class User : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static User UserForm;
        private static object lockObj = new object();
        private User()
        {
            InitializeComponent();
        }
        public static User CreateUserForm()
        {
            if (UserForm == null || UserForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (UserForm == null || UserForm.IsDisposed)
                    {
                        UserForm = new User();
                    }
                }
            }
            return UserForm;
        }
        ///////////////////////////////////////////////////////////////
        private void User_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.CreateLoginForm().Show();
        }

        private void User_Load(object sender, EventArgs e)
        {
            textBox4.Text = "50";
            listBox1.Text = "Waiting List";
            label5.Text = listBox1.Items.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1")
            {
                textBox4.Text = "50";
            }
            else if (comboBox1.Text == "2")
            {
                textBox4.Text = "55";
            }
            else if (comboBox1.Text == "3")
            {
                textBox4.Text = "60";
            }
            else if (comboBox1.Text == "4")
            {
                textBox4.Text = "65";
            }
            else
            {
                textBox4.Text = "70";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (textBox1.Text == ""|| textBox2.Text==""|| textBox3.Text=="")
            {
                MessageBox.Show("Enter All Patient Data");
            }
            else
            {
                ArrayList patient = new ArrayList();
                patient.Add(textBox1.Text);
                patient.Add(textBox2.Text);
                patient.Add(textBox3.Text);
                patient.Add(comboBox1.Text);
                patient.Add(textBox4.Text);
                if (radioButton1.Checked==true)
                {
                    patient.Add(radioButton1.Text);
                }
                else
                {
                    patient.Add(radioButton2.Text);
                }
                Reciver obj1 = new Reciver(patient);
                Sender obj2 = new Sender(new ArrayList());
                obj2.Add(obj1);
                obj2.Notify();

                listBox1.Items.Add(textBox1.Text);
                label5.Text = listBox1.Items.Count.ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "50";
                comboBox1.Text = "1";
                radioButton1.Checked = true;
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Admin_Form.RemoveFromWaitingList(listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                label5.Text = listBox1.Items.Count.ToString();
            }
        }
    }
}
