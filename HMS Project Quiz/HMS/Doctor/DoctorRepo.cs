using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Doctor
{
    internal class DoctorRepo
    {
        private readonly string file = "Doctors Data.txt";

        public DoctorRepo()
        {
        }

        public void SaveInFile(DoctorModel doctor)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(doctor.ToString());
            }
        }

        public List<DoctorModel> GetDoctorsFromFile()
        {
            List<DoctorModel> doctorsList = new List<DoctorModel>();

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
                            string specialization = parts[4];

                            DoctorModel doctor = new DoctorModel( name, age, address, phoneNumber, specialization);

                            doctorsList.Add(doctor);
                        }
                    }
                }
            }

            return doctorsList;
        }

        public void SaveAllInFile(List<DoctorModel> doctorsList)
        {
            using (StreamWriter stream = new StreamWriter(file, false))
            {
                for (int i = 0; i < doctorsList.Count; i++)
                {
                    stream.WriteLine(doctorsList[i].ToString());
                }
            }
        }
    }
}
