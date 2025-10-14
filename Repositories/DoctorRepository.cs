using san_vicente_hospital.Db;
using san_vicente_hospital.Interfaces;
using san_vicente_hospital.Models;

namespace san_vicente_hospital.Repositories;

public class DoctorRepository: IDoctorRepository
{

    public void AddDoctor(Doctor doctor)
    {
        Database.doctors.Add(doctor);
    }

    public List<Doctor> GetAllPatients()
        {
            return Database.doctors;
        }

    public List<Doctor> GetAllDoctors()
        {
            return Database.doctors;
        }
}
