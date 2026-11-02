using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Doctor
{
    internal class DoctorService
    {
        private DoctorRepo doctorRepo;
        private List<DoctorModel> doctorsList;

        public DoctorService()
        {
            doctorRepo = new DoctorRepo();

            doctorsList = doctorRepo.GetDoctorsFromFile();
        }

        public void AddDoctor(DoctorModel doctor)
        {
            doctorsList.Add(doctor);

            doctorRepo.SaveInFile(doctor);
        }

        public List<DoctorModel> GetAllDoctors()
        {
            return doctorsList;
        }

        public DoctorModel SearchDoctor(string name)
        {
            for (int i = 0; i < doctorsList.Count; i++)
            {
                if (doctorsList[i].Name == name)
                {
                    return doctorsList[i];
                }
            }

            return null;
        }
    }
}
