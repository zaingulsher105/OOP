using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Patient
{
    internal class PatientModel
    {
        private string name;
        private int age;
        private string address;
        private string phoneNumber;
        private string disease;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Disease
        {
            get { return disease; }
            set { disease = value; }
        }

        public int bill
        {
            get { return bill; }
            set { bill = value; }
        }



        public PatientModel(string name, int age,
                            string address, string phoneNumber,
                            string disease)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.disease = disease;
        }


        public PatientModel(string name, int age,
                         string address)
        {
            this.name = name;
            this.age = age;
            this.address = address;

        }



        public PatientModel(string name, int age)
        {
            this.name = name;
            this.age = age;
            

        }


        public PatientModel(string name)
        {
            this.name = name;


        }

        public override string ToString()
        {
            return name + "," + age + "," + address + "," +
                   phoneNumber + "," + disease;
        }
    }
}
