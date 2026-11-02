using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Doctor
{
    internal class DoctorUI
    {
        private DoctorService doctorService;

        public DoctorUI(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public void AddDoctor()
        {
            Console.WriteLine("\n===== ADD DOCTOR =====");
            Console.Clear();


            Console.Write("Enter doctor name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter specialization: ");
            string specialization = Console.ReadLine();

            DoctorModel doctor = new DoctorModel( name ,age, address, phoneNumber, specialization);

            doctorService.AddDoctor(doctor);

            Console.WriteLine("Doctor added successfully.");
            Console.ReadKey();

        }

        public void ShowDoctors()
        {
            List<DoctorModel> doctorsList =  doctorService.GetAllDoctors();

            if (doctorsList.Count == 0)
            {
                Console.WriteLine("No doctors found.");
                return;
                Console.ReadKey();

            }

            for (int i = 0; i < doctorsList.Count; i++)
            {
                Console.WriteLine("\nDoctor " + (i + 1));
                Console.WriteLine("Name: " + doctorsList[i].Name);
                Console.WriteLine("Age: " + doctorsList[i].Age);
                Console.WriteLine("Address: " + doctorsList[i].Address);
                Console.WriteLine("Phone: " + doctorsList[i].PhoneNumber);
                Console.WriteLine("Specialization: " + doctorsList[i].Specialization);
                Console.ReadKey();

            }
        }

        public void SearchDoctor()
        {
            Console.Write("\nEnter doctor name: ");
            string name = Console.ReadLine();

            DoctorModel doctor = doctorService.SearchDoctor(name);

            if (doctor != null)
            {
                Console.WriteLine("\nDoctor found.");
                Console.WriteLine("Name: " + doctor.Name);
                Console.WriteLine("Age: " + doctor.Age);
                Console.WriteLine("Address: " + doctor.Address);
                Console.WriteLine("Phone: " + doctor.PhoneNumber);
                Console.WriteLine("Specialization: " +
                    doctor.Specialization);
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Doctor not found.");
                Console.ReadKey();

            }
        }
    }
}
