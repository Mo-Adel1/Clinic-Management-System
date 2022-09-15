using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Clinic
{
    public partial class Admin_Form : Form
    {
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private static Admin_Form AdminForm;
        private static object lockObj = new object();
        private Admin_Form()
        {
            InitializeComponent();
        }
        public static Admin_Form CreateAdminForm()
        {
            if (AdminForm == null || AdminForm.IsDisposed)
            {
                lock (lockObj)
                {
                    if (AdminForm == null || AdminForm.IsDisposed)
                    {
                        AdminForm = new Admin_Form();
                    }
                }
            }
            return AdminForm;
        }
        ////////////////////////////////////////////////////////////////////////////////



        public static List<string> list = new List<string>();
        public static void AddToWaitingList(ArrayList wl)
        {
            List<string> Plist = new List<string>();
            foreach (string i in wl)
            {
                Plist.Add(i);
            }
            listBox1.Items.Add(Plist[0]);
            label16.Text = listBox1.Items.Count.ToString();
            list.Add(Plist[0]);
            list.Add(Plist[1]);
            list.Add(Plist[2]);
            list.Add(Plist[3]);
            list.Add(Plist[4]);
            list.Add(Plist[5]);
        }
        public static void RemoveFromWaitingList(string item)
        {
            //listBox1.Items.Remove(item);
            //label16.Text = listBox1.Items.Count.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.CreateLoginForm().Show();
        }
        public string emailmessage(string username, string password)
        {
            string message = string.Format("<h2>WELCOME IN OUR CLINIC " +
                                "WE ARE SO HAPPY BY YOUR JOIN.</h2>\n\n\n" +
                                "<h2>*Your User Name is:</h2> <h2> ----->  {0}</h2>\n\n" +
                                "<h2>*Your Password is:</h2> <h2> ----->  {1}</h2>\n\n\n" +
                                "<h2>-> USE THEM TO LOGIN TO THE CLINIC SYSTEM <-</h2>\n" +
                                "<h2>-> DO NOT SHARE THIS INFORMATION WITH ANYONE <-</h2>\n" +
                                "<h2> *** WITH THE BEST WISHES ***</h2>", username, password);
            return message;
        }
        public void refresh ()
        {
            DataTable dt = new DataTable();
            dt = DatabaseConection.connect_return("select count(*) from STAFF");
            label1.Text = dt.Rows[0][0].ToString();
            dt = DatabaseConection.connect_return("SELECT COUNT(*) FROM PATIENT " +
                                                  "WHERE YEAR(PATIENT_APPIONTMENT) = YEAR(GETDATE()) " +
                                                  "AND   MONTH(PATIENT_APPIONTMENT) = MONTH(GETDATE())");
            label2.Text = dt.Rows[0][0].ToString();
            dt = DatabaseConection.connect_return("SELECT SUM(PATIENT_COST) AS MPROFIT FROM PATIENT " +
                                                  "WHERE YEAR(PATIENT_APPIONTMENT) = YEAR(GETDATE()) " +
                                                  "AND MONTH(PATIENT_APPIONTMENT) = MONTH(GETDATE())");

            label17.Text = ((float)(decimal)(dt.Rows[0][0])).ToString();

            dt = DatabaseConection.connect_return("select sum(STAFF_SALARY) from STAFF");

            label18.Text = ((float)(decimal)(dt.Rows[0][0])).ToString();

            label19.Text = (float.Parse(label17.Text) - float.Parse(label18.Text)).ToString();
            try
            {
                dt = DatabaseConection.connect_return("SELECT SUM(PATIENT_COST) FROM PATIENT " +
                                                  "WHERE YEAR(PATIENT_APPIONTMENT) = YEAR(GETDATE()) " +
                                                  "AND   MONTH(PATIENT_APPIONTMENT) = MONTH(GETDATE()) " +
                                                  "AND   DAY(PATIENT_APPIONTMENT) = DAY(GETDATE())");
                label20.Text = ((float)(decimal)(dt.Rows[0][0])).ToString();
            }
            catch (Exception)
            {
                label20.Text = "0";
            }
            
            try
            {
                dt = DatabaseConection.connect_return("SELECT DISTINCT MAX(maxvalue) FROM( " +
                                 "SELECT PATIENT_APPIONTMENT, SUM(PATIENT_COST)maxvalue  FROM PATIENT " +
                                 "GROUP BY PATIENT_APPIONTMENT) AS result");
                label21.Text = ((float)(decimal)(dt.Rows[0][0])).ToString();
            }
            catch (Exception)
            {
                label21.Text = "0";
            }
            

            try
            {
                dt = DatabaseConection.connect_return("SELECT DISTINCT MAX(maxvalue) FROM( " +
                          "SELECT MONTH(PATIENT_APPIONTMENT) C1, SUM(PATIENT_COST) maxvalue FROM PATIENT " +
                          "GROUP BY MONTH(PATIENT_APPIONTMENT)) AS result");
                label22.Text = ((float)(decimal)(dt.Rows[0][0])).ToString();
            }
            catch (Exception)
            {
                label22.Text = "0";
            }
            

            label17.Text += " $";
            label18.Text += " $";
            label19.Text += " $";
            label20.Text += " $";
            label21.Text += " $";
            label22.Text += " $";
            label3.Text = label17.Text;
        }
        Font f1 = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
        Font f2 = new Font("Microsoft Sans Serif", 24, FontStyle.Regular);
        private void Admin_Form_Load(object sender, EventArgs e)
        {

            refresh();
            label29.Text = DateTime.Now.ToString("HH:mm");
            timer1.Start();
            Point p1 = new Point(22, 62);
            panel1.Size = new Size(992, 457);
            panel1.Location = p1;
            overview_btn.Select();
            overview_btn.BackColor = Color.White;
            overview_btn.Font = f2;
            doctors_btn.Font = f1;
            patients_btn.Font = f1;
            balance_btn.Font = f1;
            settings_btn.Font = f1;
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel11.Hide();
            
           
        }

        private void overview_btn_Click(object sender, EventArgs e)
        {
            refresh();
            overview_btn.Font = f2;
            doctors_btn.Font = f1;
            patients_btn.Font = f1;
            balance_btn.Font = f1;
            settings_btn.Font = f1;
            Point p1 = new Point(22, 62);
            panel1.Size = new Size(992, 457);
            panel1.Location = p1;
            doctors_btn.BackColor = Color.LightSkyBlue;
            patients_btn.BackColor = Color.LightSkyBlue;
            balance_btn.BackColor = Color.LightSkyBlue;
            settings_btn.BackColor = Color.LightSkyBlue;
            overview_btn.BackColor = Color.White;
            overview_btn.Select();
            groupBox2.Text = overview_btn.Text;
            
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel11.Hide();
        }

        private void doctors_btn_Click(object sender, EventArgs e)
        {
            refresh();
            Point p1 = new Point(22, 62);
            panel2.Size = new Size(982, 557);
            panel2.Location = p1;
            overview_btn.BackColor = Color.LightSkyBlue;
            patients_btn.BackColor = Color.LightSkyBlue;
            balance_btn.BackColor = Color.LightSkyBlue;
            settings_btn.BackColor = Color.LightSkyBlue;
            doctors_btn.BackColor = Color.White;
            doctors_btn.Select();
            groupBox2.Text = doctors_btn.Text;
            overview_btn.Font = f1;
            doctors_btn.Font = f2;
            patients_btn.Font = f1;
            balance_btn.Font = f1;
            settings_btn.Font = f1;
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();
            panel11.Hide();
        }

        private void patients_btn_Click(object sender, EventArgs e)
        {
            refresh();
            Point p1 = new Point(22, 62);
            panel3.Size = new Size(991, 549);
            panel3.Location = p1;
            overview_btn.BackColor = Color.LightSkyBlue;
            doctors_btn.BackColor = Color.LightSkyBlue;
            balance_btn.BackColor = Color.LightSkyBlue;
            settings_btn.BackColor = Color.LightSkyBlue;
            patients_btn.BackColor = Color.White;
            patients_btn.Select();
            groupBox2.Text = patients_btn.Text;
            overview_btn.Font = f1;
            doctors_btn.Font = f1;
            patients_btn.Font = f2;
            balance_btn.Font = f1;
            settings_btn.Font = f1;
            panel3.Show();
            panel1.Hide();
            panel2.Hide();
            panel4.Hide();
            panel11.Hide();
            label16.Text = listBox1.Items.Count.ToString();
        }

        private void balance_btn_Click(object sender, EventArgs e)
        {
            refresh();
            Point p1 = new Point(22, 62);
            panel4.Size = new Size(995, 545);
            panel4.Location = p1;
            overview_btn.BackColor = Color.LightSkyBlue;
            patients_btn.BackColor = Color.LightSkyBlue;
            doctors_btn.BackColor = Color.LightSkyBlue;
            settings_btn.BackColor = Color.LightSkyBlue;
            balance_btn.BackColor = Color.White;
            balance_btn.Select();
            groupBox2.Text = balance_btn.Text;
            overview_btn.Font = f1;
            doctors_btn.Font = f1;
            patients_btn.Font = f1;
            balance_btn.Font = f2;
            settings_btn.Font = f1;
            panel4.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel11.Hide();
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            Point p1 = new Point(22, 62);
            panel11.Size = new Size(999, 520);
            panel11.Location = p1;
            overview_btn.BackColor = Color.LightSkyBlue;
            patients_btn.BackColor = Color.LightSkyBlue;
            balance_btn.BackColor = Color.LightSkyBlue;
            doctors_btn.BackColor = Color.LightSkyBlue;
            settings_btn.BackColor = Color.White;
            settings_btn.Select();
            groupBox2.Text = settings_btn.Text;
            overview_btn.Font = f1;
            doctors_btn.Font = f1;
            patients_btn.Font = f1;
            balance_btn.Font = f1;
            settings_btn.Font = f2;
            panel11.Show();
            panel4.Hide();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void overview_btn_MouseHover(object sender, EventArgs e)
        {
            overview_btn.Font = f2;
            
        }

        private void overview_btn_MouseLeave(object sender, EventArgs e)
        {
            overview_btn.Font = f1;
           
        }
        private void doctors_btn_MouseHover(object sender, EventArgs e)
        {
            doctors_btn.Font = f2;
           
        }

        private void doctors_btn_MouseLeave(object sender, EventArgs e)
        {
            doctors_btn.Font = f1;
           
        }
        private void patients_btn_MouseHover(object sender, EventArgs e)
        {
            patients_btn.Font = f2;
            
        }

        private void patients_btn_MouseLeave(object sender, EventArgs e)
        {
            patients_btn.Font = f1;
            
        }
        private void balance_btn_MouseHover(object sender, EventArgs e)
        {
            balance_btn.Font = f2;
        
        }

        private void balance_btn_MouseLeave(object sender, EventArgs e)
        {
            balance_btn.Font = f1;
        }

        private void settings_btn_MouseHover(object sender, EventArgs e)
        {
            settings_btn.Font = f2;
           
        }

        private void settings_btn_MouseLeave(object sender, EventArgs e)
        {
            settings_btn.Font = f1;

        }

        private void overview_btn_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Admin_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.CreateLoginForm().Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            All_Staff_Form.AllStaffForm().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            All_Patients_form.AllPatientsForm().Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool send = false;
            string name = textBox1.Text;
            string ssn = textBox2.Text;
            string email = textBox3.Text;
            string phone = textBox4.Text;
            string position = comboBox1.Text;
            string gender = "Male";
            string salary = "300";
            string username = CreateUserNameAndPassword.username();
            string password = CreateUserNameAndPassword.password();
            if (radioButton2.Checked == true)
            {
                gender = "Female";
            }
            if (position == "A")
            {
                salary = "400";
            }
            else if (position == "B")
            {
                salary = "350";
            }
            else
            {
                salary = "300";
            }

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please Enter Your Data Completly");
            }
            else
            {
                goto condetion;
            }

            condetion:
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = DatabaseConection.connect_return(string.Format("SELECT * FROM STAFF WHERE " +
                "STAFF_SSN = '{0}'", ssn));
            dt2 = DatabaseConection.connect_return(string.Format("SELECT * FROM STAFF WHERE " +
                "STAFF_USERNAME = '{0}'",username));
            try
            {
                if (dt1.Rows[0][0].ToString() != null)
                {
                    MessageBox.Show("Your SSN is used");
                }
                else if (dt2.Rows[0][0].ToString() != null)
                {
                    username = CreateUserNameAndPassword.username();
                }
            }
            catch (Exception)
            {
                goto condetion1;
            }
            condetion1:
                string message = emailmessage(username,password);
                Email emailmassege = new Email(email, message);
                send = emailmassege.SendEmail();
                if (send == true)
                {
                    try
                    {
                        DatabaseConection.connect(string.Format(
                        "INSERT INTO STAFF " +
                        "(STAFF_SSN, STAFF_USERNAME, STAFF_PASS, STAFF_NAME, STAFF_ADDRESS, " +
                        "STAFF_PHONE, STAFF_EMAIL, STAFF_PICTURE, STAFF_GENDER, STAFF_SALARY, " +
                        "STAFF_POSITION, ADMIN_USERNAME) " +
                        "VALUES " +
                        "('{0}', '{1}', '{2}', '{3}', NULL, " +
                        "'{4}', '{5}', NULL, '{6}', '{7}', '{8}', NULL) ",
                        ssn, username, password, name, phone, email, gender, salary, position
                        ));
                       AdminDataProxy p = new AdminDataProxy(new AdminData());
                       Data.GetTables();
                       MessageBox.Show("Added");
                       textBox1.Text = "";
                       textBox2.Text = "";
                       textBox3.Text = "";
                       textBox4.Text = "";
                       comboBox1.Text ="A";
                       radioButton1.Checked = true;
                }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.ToString());
                    }
               }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            string username = textBox5.Text;
            if (username != "")
            {
                try
                {
                    DatabaseConection.connect(string.Format("DELETE FROM STAFF WHERE STAFF_USERNAME = '{0}'", username));
                    AdminDataProxy p = new AdminDataProxy(new AdminData());
                    Data.GetTables();
                    MessageBox.Show("Deleted");
                    textBox5.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Check this user name");
                }
            }
            else
            {
                MessageBox.Show("Enter the username");
            }
        }


        private void button14_Click(object sender, EventArgs e)
        {
            bool send = false;
            string email = textBox7.Text;
            DataTable dt = new DataTable();
            string username = CreateUserNameAndPassword.username();
            string password = CreateUserNameAndPassword.password();
            dt = DatabaseConection.connect_return(string.Format("SELECT * FROM ADMIN WHERE ADMIN_USERNAME = '{0}'", username));
            try
            {
                dt.Rows[0][0].ToString();
                username = CreateUserNameAndPassword.username();
            }
            catch(Exception)
            {
                string message = emailmessage(username,password);
                Email emailmassege = new Email(email, message);
                send = emailmassege.SendEmail();
            }
            if (send == true)
            {
                DatabaseConection.connect(string.Format("INSERT INTO ADMIN " +
                          "(ADMIN_USERNAME, ADMIN_PASS, USER_EMAIL) " +
                          "VALUES('{0}', '{1}', '{2}'); ", username, password, email));
                AdminDataProxy p = new AdminDataProxy(new AdminData());
                Data.GetTables();
                MessageBox.Show("Added");
                textBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Try With Another Email");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label29.Text = DateTime.Now.ToString("HH:mm");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string oldusername = textBox8.Text;
            string oldpassword = textBox9.Text;
            string newusername = textBox11.Text;
            string newpassword = textBox10.Text;
            string newemail = textBox12.Text;
            if (oldusername == "" || oldpassword == "")
            {
                MessageBox.Show("Enter your old data completly");
            }
            else
            {
                bool empty;
                DataTable dt = new DataTable();
                dt = DatabaseConection.connect_return(string.Format("SELECT * FROM ADMIN " +
                                                           "WHERE ADMIN_USERNAME = '{0}' " +
                                                           "AND ADMIN_PASS = '{1}'", oldusername, oldpassword));
                try
                {
                    dt.Rows[0][0].ToString();
                    empty = false;
                }
                catch (Exception) { empty = true; }
                if (empty == true)
                {
                    MessageBox.Show("The User Name Or Password Is Incorect");
                }
                else
                {
                    if (newpassword != "")
                    {
                        try
                        {
                            DatabaseConection.connect(string.Format("UPDATE ADMIN SET ADMIN_PASS = '{0}' " +
                                                      "WHERE ADMIN_USERNAME = '{1}'", newpassword, oldusername));
                            if (newusername == "" && newemail == "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("The Password Updated");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("this user name is not exist");
                            textBox8.Focus();
                        }
                    }
                    if (newemail != "")
                    {
                        try
                        {
                            DatabaseConection.connect(string.Format("UPDATE ADMIN SET USER_EMAIL = '{0}' " +
                                                      "WHERE ADMIN_USERNAME = '{1}'", newemail, oldusername));
                            if (newusername == "" && newpassword == "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("The Email Is Updated");
                            }
                            if (newusername == "" && newpassword != "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("The Password And Email Are Updated");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("this user name is not exist");
                            textBox8.Focus();
                        }
                    }
                    if (newusername != "")
                    {
                        try
                        {
                            DatabaseConection.connect(string.Format("UPDATE ADMIN SET ADMIN_USERNAME = '{0}' " +
                                                      "WHERE ADMIN_USERNAME = '{1}'", newusername, oldusername));
                            if (newpassword == "" && newemail == "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("The User Name Is Updated");
                            }
                            if (newpassword != "" && newemail == "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("The User Name And Password Are Updated");
                            }
                            if (newpassword == "" && newemail != "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("The User Name And Email Are Updated");
                            }
                            if (newpassword != "" && newemail != "")
                            {
                                AdminDataProxy p = new AdminDataProxy(new AdminData());
                                Data.GetTables();
                                MessageBox.Show("Your Data Are Updated");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("this user name is used, try another one");
                            textBox11.Focus();
                        }
                    }


                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void nextPatient()
        {
            if (listBox1.Items.Count > 0)
            {
                textBox6.Text = listBox1.Items[0].ToString();
                listBox1.Items.RemoveAt(0);
                label16.Text = listBox1.Items.Count.ToString();
                richTextBox1.Text = "";
            }
            else
            {
                textBox6.Text = "";
                richTextBox1.Text = "";
                MessageBox.Show("There is no patient");
            }
        }
        public void addPatient()
        {
            DatabaseConection.connect(string.Format("INSERT INTO PATIENT " +
                "(PATIENT_NAME,PATIENT_PHONE,PATIENT_ADDRESS,PATIENT_STATUE, " +
                "PATIENT_COST,PATIENT_GENDER,PATIENT_NOTE,PATIENT_APPIONTMENT) VALUES " +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',getdate())",
                list[0], list[1], list[2], list[3], list[4], list[5], richTextBox1.Text));
            textBox6.Text = "";
            richTextBox1.Text = "";
            nextPatient();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                nextPatient();
            }
            else
            {
                DialogResult dR = MessageBox.Show("", "Do You Want To Save Current Patient?", MessageBoxButtons.YesNo);
                if (dR == DialogResult.Yes && textBox6.Text != "")
                {
                    addPatient();   
                }
                else
                {
                    nextPatient();
                }
            }
            }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                addPatient();
            }
        }
    }
    }

