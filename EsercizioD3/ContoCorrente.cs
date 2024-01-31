using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioD3
{
    internal class ContoCorrente
    {
        private bool isOpen;
        private float credit;
        private string name, surname;
        private static ContoCorrente instance;

        public static ContoCorrente GetInstance ()
        {
            if(instance == null)
            {
                instance = new ContoCorrente();
                instance.SetOpen();
                instance.SetInitialCredit();
                return instance;
            }
            return instance;
        }
        private ContoCorrente() { }

        protected void SetOpen()
        {
            isOpen = true;
        }

        protected void SetInitialCredit()
        {
            credit = 0.00f;
        }

        public void Deposit(float credit)
        {
            this.credit += credit;
        }

        public void Withdrawal(float credit)
        {
            if(this.credit >= credit)
                this.credit -= credit;
        }

        public float GetCredit()
        {
            return credit;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        public string GetSurname()
        {
            return surname;
        }
    }
}
