using HMS.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Patient
{
    internal class PatientUI
    {
        private PatientService patientService;
        private DoctorUI doctorUI;

        public PatientUI(PatientService patientService, DoctorUI doctorUI)
        {
            this.patientService = patientService;
            this.doctorUI = doctorUI;
        }

        public void MainMenu()
        {
            int choice = 0;

            while (choice != 3)
            {
                Console.Clear();
                Console.WriteLine("\n===== HOSPITAL MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Admin Menu");
                Console.WriteLine("2. Patient Menu");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    AdminLogin();
                }
                else if (choice == 2)
                {
                    PatientMenu();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Thank you for using our system.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();

                }
            }
        }

        private void AdminLogin()
        {
            int attempts = 0;
            bool login = false;

            while (attempts < 3 && login == false)
            {

                Console.Clear();

                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == "admin" && password == "1234")
                {
                    login = true;
                    Console.WriteLine("Login successful.");
                    AdminMenu();
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Wrong username or password.");
                    Console.ReadKey();

                }
            }

            if (login == false)
            {
                Console.WriteLine("Maximum login attempts reached.");
                Console.ReadKey();

            }
        }

        private void AdminMenu()
        {
            int choice = 0;

            while (choice != 11)
            {
                Console.Clear();
                Console.WriteLine("\n===== ADMIN MENU =====");
                Console.WriteLine("1. Show all patients");
                Console.WriteLine("2. Search patient");
                Console.WriteLine("3. Update patient");
                Console.WriteLine("4. Delete patient");
                Console.WriteLine("5. Count patients");
                Console.WriteLine("6. Generate bill");
                Console.WriteLine("7. Add doctor");
                Console.WriteLine("8. Show doctors");
                Console.WriteLine("9. Search doctor");
                Console.WriteLine("10. Sort patients by name");
                Console.WriteLine("11. Logout");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    ShowPatients();
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    SearchPatient();
                    Console.ReadKey();

                }
                else if (choice == 3)
                {
                    UpdatePatient();
                    Console.ReadKey();

                }
                else if (choice == 4)
                {
                    DeletePatient();
                    Console.ReadKey();

                }
                else if (choice == 5)
                {
                    Console.WriteLine("Total patients: " +
                        patientService.CountPatients());
                    Console.ReadKey();

                }
                else if (choice == 6)
                {
                    GenerateBill();
                    Console.ReadKey();

                }
                else if (choice == 7)
                {
                    doctorUI.AddDoctor();
                    Console.ReadKey();

                }
                else if (choice == 8)
                {
                    doctorUI.ShowDoctors();
                    Console.ReadKey();

                }
                else if (choice == 9)
                {
                    doctorUI.SearchDoctor();
                    Console.ReadKey();

                }
                else if (choice == 10)
                {
                    patientService.SortPatients();
                    Console.WriteLine("Patients sorted successfully.");
                    Console.ReadKey();

                }
                else if (choice == 11)
                {
                    Console.WriteLine("Admin logged out.");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();

                }
            }
        }

        private void PatientMenu()
        {

            Console.WriteLine("\n===== PATIENT REGISTRATION =====");


            string name = ReadName();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter disease: ");
            string disease = Console.ReadLine();

            PatientModel patient = new PatientModel(
                name, age, address, phoneNumber, disease);

            patientService.AddPatient(patient);

            Console.WriteLine("Patient registered successfully.");
            Console.ReadKey();

        }

        private string ReadName()
        {
            Console.Write("Enter patient name: ");
            return Console.ReadLine();
            Console.ReadKey();

        }

        private void ShowPatients()
        {
            List<PatientModel> patientsList =
                patientService.GetAllPatients();

            if (patientsList.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
                Console.ReadKey();

            }

            for (int i = 0; i < patientsList.Count; i++)
            {
                Console.WriteLine("\nPatient " + (i + 1));
                Console.WriteLine("Name: " + patientsList[i].Name);
                Console.WriteLine("Age: " + patientsList[i].Age);
                Console.WriteLine("Address: " + patientsList[i].Address);
                Console.WriteLine("Phone: " + patientsList[i].PhoneNumber);
                Console.WriteLine("Disease: " + patientsList[i].Disease);
            }
        }

        private void SearchPatient()
        {
            string name = ReadName();

            PatientModel patient = patientService.SearchPatient(name);

            if (patient != null)
            {
                Console.WriteLine("\nPatient found.");
                Console.WriteLine("Name: " + patient.Name);
                Console.WriteLine("Age: " + patient.Age);
                Console.WriteLine("Address: " + patient.Address);
                Console.WriteLine("Phone: " + patient.PhoneNumber);
                Console.WriteLine("Disease: " + patient.Disease);
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Patient not found.");
                Console.ReadKey();

            }
        }

        private void UpdatePatient()
        {
            Console.Write("Enter the name of patient to update: ");
            string oldName = Console.ReadLine();

            Console.WriteLine("Enter new patient details:");

            string name = ReadName();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter disease: ");
            string disease = Console.ReadLine();

            PatientModel newPatient = new PatientModel(
                name, age, address, phoneNumber, disease);

            bool result = patientService.UpdatePatient(oldName, newPatient);

            if (result == true)
            {
                Console.WriteLine("Patient updated successfully.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Patient not found.");
                Console.ReadKey();

            }
        }

        private void DeletePatient()
        {
            string name = ReadName();

            bool result = patientService.DeletePatient(name);

            if (result == true)
            {
                Console.WriteLine("Patient deleted successfully.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Patient not found.");
                Console.ReadKey();

            }
        }

        private void GenerateBill()
        {
            string name = ReadName();

            PatientModel patient = patientService.SearchPatient(name);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
                  Console.ReadKey();

            }

            Console.Write("Enter number of days: ");
            int days = int.Parse(Console.ReadLine());

            Console.Write("Enter doctor fee: ");
            double doctorFee = double.Parse(Console.ReadLine());

            Console.Write("Enter medicine cost: ");
            double medicineCost = double.Parse(Console.ReadLine());

            double totalBill = (days * 2000) + doctorFee + medicineCost;

            Console.WriteLine("\n===== PATIENT BILL =====");
            Console.WriteLine("Patient Name: " + patient.Name);
            Console.WriteLine("Room Charges: " + (days * 2000));
            Console.WriteLine("Doctor Fee: " + doctorFee);
            Console.WriteLine("Medicine Cost: " + medicineCost);
            Console.WriteLine("Total Bill: " + totalBill);
            Console.ReadKey();

        }
    }
}
