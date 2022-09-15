using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Clinic
{
    //class CreateSingleForm
    //    {
    //        private static Form LoginForm;
    //        private static Form AdminForm;
    //        private static Form UserForm;
    //        private static Form RecoverAccountForm;
    //        private static Form RandumNumberForm;
    //        private static Form ResetDataForm;
    //        private static Form StaffForm;
    //        private static Form PatientsForm;

    //        private static object lockObj = new object();
    //        private CreateSingleForm() { }
    //        public static Form CreateLoginForm()
    //        {
    //            if (LoginForm == null || LoginForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (LoginForm == null || LoginForm.IsDisposed)
    //                    {
    //                       // LoginForm = new Login();
    //                    }
    //                }
    //            }
    //            return LoginForm;
    //        }
    //        public static Form CreateAdminForm()
    //        {
    //            if (AdminForm == null || AdminForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (AdminForm == null || AdminForm.IsDisposed)
    //                    {
    //                        // AdminForm = new Admin_Form();
    //                    }
    //                }
    //            }
    //            return AdminForm;
    //        }
    //        public static Form CreateUserForm()
    //        {
    //            if (UserForm == null || UserForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (UserForm == null || UserForm.IsDisposed)
    //                    {
    //                      //  UserForm = new User();
    //                    }
    //                }
    //            }
    //            return UserForm;
    //        }
    //        public static Form RecoverYourAccountForm()
    //        {
    //            if (RecoverAccountForm == null || RecoverAccountForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (RecoverAccountForm == null || RecoverAccountForm.IsDisposed)
    //                    {
    //                       // RecoverAccountForm = new Recover_Your_Account();
    //                    }
    //                }
    //            }
    //            return RecoverAccountForm;
    //        }
    //        public static Form RecoveryNumberForm()
    //        {
    //            if (RandumNumberForm == null || RandumNumberForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (RandumNumberForm == null || RandumNumberForm.IsDisposed)
    //                    {
    //                       // RandumNumberForm = new Recovery_Number();
    //                    }
    //                }
    //            }
    //            return RandumNumberForm;
    //        }
    //        public static Form ResetYourDataForm()
    //        {
    //            if (ResetDataForm == null || ResetDataForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (ResetDataForm == null || ResetDataForm.IsDisposed)
    //                    {
    //                        //ResetDataForm = new ResetYourData();
    //                    }
    //                }
    //            }
    //            return ResetDataForm;
    //        }
    //        public static Form AllStaffForm()
    //        {
    //            if (StaffForm == null || StaffForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (StaffForm == null || StaffForm.IsDisposed)
    //                    {
    //                       // StaffForm = new All_Staff_Form();
    //                    }
    //                }
    //            }
    //            return StaffForm;
    //        }
    //        public static Form AllPatientsForm()
    //        {
    //            if (PatientsForm == null || PatientsForm.IsDisposed)
    //            {
    //                lock (lockObj)
    //                {
    //                    if (PatientsForm == null || PatientsForm.IsDisposed)
    //                    {
    //                       // PatientsForm = new All_Patients_form();
    //                    }
    //                }
    //            }
    //            return PatientsForm;
    //        }
    //    }
}
