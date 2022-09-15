using My_Clinic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Clinic
{
    class Facade
    {
        
        private static string Email;
        private static string NewUserName;
        private static string NewPassword;
        private static string Randomnumber;

        Email email;
        Recovery recovery;
        RandomNumber randomnumber;
        CheckRandomNumber checkrandomnumber = new CheckRandomNumber(Randomnumber);
        

        public Facade() { }
        public Facade(string email)
        {
            Email = email;
        }
        public Facade(string newuserName,string newpassword)
        {
            NewUserName = newuserName;
            NewPassword = newpassword;
        }
        
        public void Recover_Account_Step1()
        {
            bool send = false;
            bool exist = CheckPassedData.checkemail(Email);
            if (exist == false)
            {
                MessageBox.Show("This Email Is Incorect","",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
            }
            else
            {
                randomnumber = new RandomNumber();
                Randomnumber = randomnumber.random_number();
                string message = string.Format("<h1> Your Verfication Code is <h1> {0} </h1> </h1>", Randomnumber);
                email = new Email(Email, message);
                send = email.SendEmail();
            }
            if (send == true)
            {
                Recovery_Number.RecoveryNumberForm().Show();
                Recover_Your_Account.RecoverYourAccountForm().Dispose();
            }
        }
        public void Recover_Account_Step2(string randomnumber)
        { 
            bool ok = checkrandomnumber.Check(randomnumber);
            if (ok == false)
            {
                MessageBox.Show("Incorect Code");
            }
            else
            {
                Recovery_Number.RecoveryNumberForm().Dispose();
                ResetYourData.ResetYourDataForm().Show();
            }
        }
        public void Recover_Account_Step3()
        {
            recovery = new Recovery(NewUserName, NewPassword, Email);
            recovery.Reset();
        }
    }
    class RandomNumber
    {
        public string random_number()
        {
            Random randomnumber = new Random();
            int num = randomnumber.Next(12345, 99999);
            return num.ToString();
        }
    }
    class Email
    {
        private static string Send_To;
        private static string Message;
        public Email(string send_to, string message)
        {
            Send_To = send_to;
            Message = message;
        }
        public bool SendEmail()
        {
            bool ok = false;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("mohammedadelsalah8@gmail.com");
            mail.To.Add(Send_To);
            mail.IsBodyHtml = true;
            mail.Subject = "SMART CLINIC";
            mail.Body =  Message;
            //mail.Attachments.Add(new Attachment(@"C:\Users\dr\Desktop\My Clinic\My Clinic\Clinic images and icons\icons\nurse.png"));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("mohammedadelsalah8", "qwer4444");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            smtp.Timeout = 30000;
            try
            {
                smtp.Send(mail);
                ok = true;
            }
            catch (SmtpException)
            {
                MessageBox.Show("Check Your Internet Connection\n" + 
                                "Or Check Your E-mail Validation");
            }
            return ok;
        }       
     }
    class CheckRandomNumber
    {
        private static string Random_Number;
        public CheckRandomNumber(string random_number)
        {
            Random_Number = random_number;
        }
        public bool Check(string Rand_num)
        {
            bool ok = false;
            if (Random_Number == Rand_num)
            {
                ok = true;
            }
            return ok;
        }
    }
    class Recovery
    {
        private static string NewUserName;
        private static string NewPasswprd;
        private static string Email;
        public Recovery(string newusername, string newpasswprd, string email)
        {
            NewUserName = newusername;
            NewPasswprd = newpasswprd;
            Email = email;
        }
        public void Reset()
        {
            try
            {
                DatabaseConection.connect(string.Format("update ADMIN SET ADMIN_USERNAME = '{0}', ADMIN_PASS = '{1}' WHERE USER_EMAIL = '{2}'", NewUserName, NewPasswprd, Email));
            }
            catch (Exception)
            {  
                DatabaseConection.connect(string.Format("update STAFF SET STAFF_USERNAME = '{0}', STAFF_PASS = '{1}' WHERE STAFF_EMAIL = '{2}'", NewUserName, NewPasswprd, Email));
            }

        }
    }
}
