using san_vicente_hospital.Db;
using san_vicente_hospital.Interfaces;
using san_vicente_hospital.Models;

namespace san_vicente_hospital.Repositories;

public class PatientRepository : IPatientRepository
{
    public void AddPatient(Patient patient)
    {
        Database.patients.Add(patient);
    }

    public List<Patient> GetAllPatients()
        {
            return Database.patients;
        }

    
}
