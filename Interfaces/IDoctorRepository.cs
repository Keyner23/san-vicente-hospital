using san_vicente_hospital.Models;

namespace san_vicente_hospital.Interfaces;

public interface IDoctorRepository
{
    void AddDoctor(Doctor doctor);
    List<Doctor> GetAllDoctors();
}
