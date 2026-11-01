using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Patient
{
    internal class PatientRepo
    {
        private readonly string file = "Patients Data.txt";

        public PatientRepo()
        {
        }

        public void SaveInFile(PatientModel patient)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(patient.ToString());
            }
        }

        public List<PatientModel> GetPatientsFromFile()
        {
            List<PatientModel> patientsList = new List<PatientModel>();

            if (File.Exists(file))
            {
                using (StreamReader stream = new StreamReader(file))
                {
                    string line = "";

                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 5)
                        {
                            string name = parts[0];
                            int age = int.Parse(parts[1]);
                            string address = parts[2];
                            string phoneNumber = parts[3];
                            string disease = parts[4];

                            PatientModel patient = new PatientModel(
                                name, age, address, phoneNumber, disease);

                            patientsList.Add(patient);
                        }
                    }
                }
            }

            return patientsList;
        }

        public void SaveAllInFile(List<PatientModel> patientsList)
        {
            using (StreamWriter stream = new StreamWriter(file, false))
            {
                for (int i = 0; i < patientsList.Count; i++)
                {
                    stream.WriteLine(patientsList[i].ToString());
                }
            }
        }
    }
}
