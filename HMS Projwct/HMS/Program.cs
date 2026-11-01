using HMS.Doctor;
using HMS.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientService patientService = new PatientService();

            DoctorService doctorService = new DoctorService();

            DoctorUI doctorUI = new DoctorUI(doctorService);

            PatientUI patientUI = new PatientUI(patientService, doctorUI);

            patientUI.MainMenu();
        }
    }
}
