using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Patient
{
    internal class PatientService
    {
        private PatientRepo patientRepo;
        private List<PatientModel> patientsList;

        public PatientService()
        {
            patientRepo = new PatientRepo();

            patientsList = patientRepo.GetPatientsFromFile();
        }

        public void AddPatient(PatientModel patient)
        {
            patientsList.Add(patient);

            patientRepo.SaveInFile(patient);
        }

        public List<PatientModel> GetAllPatients()
        {
            return patientsList;
        }

        public PatientModel SearchPatient(string name)
        {
            for (int i = 0; i < patientsList.Count; i++)
            {
                if (patientsList[i].Name == name)
                {
                    return patientsList[i];
                }
            }

            return null;
        }


       
        public bool UpdatePatient(string oldName, PatientModel newPatient)
        {
            for (int i = 0; i < patientsList.Count; i++)
            {
                if (patientsList[i].Name == oldName)
                {
                    patientsList[i] = newPatient;

                    patientRepo.SaveAllInFile(patientsList);

                    return true;
                }
            }

            return false;
        }

        public bool DeletePatient(string name)
        {
            for (int i = 0; i < patientsList.Count; i++)
            {
                if (patientsList[i].Name == name)
                {
                    patientsList.RemoveAt(i);

                    patientRepo.SaveAllInFile(patientsList);

                    return true;
                }
            }

            return false;
        }

        public int CountPatients()
        {
            return patientsList.Count;
        }

        public void SortPatients()
        {
            for (int i = 0; i < patientsList.Count - 1; i++)
            {
                for (int j = i + 1; j < patientsList.Count; j++)
                {
                    if (string.Compare(
                        patientsList[i].Name,
                        patientsList[j].Name) > 0)
                    {
                        PatientModel temp = patientsList[i];

                        patientsList[i] = patientsList[j];

                        patientsList[j] = temp;
                    }
                }
            }

            patientRepo.SaveAllInFile(patientsList);
        }



        public PatientModel Filter(string name, int age, string address)
        {
            for (int i = 0; i < patientsList.Count; i++)
            {
                if (patientsList[i].Name == name || patientsList[i].Age == age || patientsList[i].Address == address)
                {
                    return patientsList[i];
                }
            }

            return null;
        }
    }
}
