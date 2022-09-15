using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Clinic
{
    public interface ISubject
    {
        void Add(IObserver observer);
        void Notify();
    }
    public interface IObserver
    {
        void Update();
    }
    class Sender : ISubject
    {
        ArrayList Patients;
        public Sender(ArrayList patients)
        {
            this.Patients = patients;
        }
        public void Add(IObserver observer)
        {
            Patients.Add(observer);
        }

        public void Notify()
        {
           foreach (IObserver o in Patients)
            {
                o.Update();
            }
        }
    }
    class Reciver : IObserver
    {
        private ArrayList Patients;
        public Reciver(ArrayList patient)
        {
            this.Patients = patient;
        }

        public void Update()
        {
            Admin_Form.CreateAdminForm();
            Admin_Form.AddToWaitingList(Patients);
        }
    }
}
