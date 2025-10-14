using san_vicente_hospital.Models;

namespace san_vicente_hospital.Interfaces;

public interface IPatientRepository
{
    void AddPatient(Patient patient);
    List<Patient> GetAllPatients();
    
}
