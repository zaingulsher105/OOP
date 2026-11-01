using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Doctor
{
    internal class DoctorModel
    {
         private string name;
        private int age;
        private string address;
        private string phoneNumber;
        private string specialization;

        // Properties
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

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        // Constructor
        public DoctorModel(string name, int age,
                           string address, string phoneNumber,
                           string specialization)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.specialization = specialization;
        }

        // Convert object into string for file handling
        public override string ToString()
        {
            return name + "," + age + "," + address + "," +
                   phoneNumber + "," + specialization;
        }
    }
}
