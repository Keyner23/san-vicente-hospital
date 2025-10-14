using san_vicente_hospital.Models;

namespace san_vicente_hospital.Interfaces;

public interface IAppointmentRepository
{
    void AddAppoiment(Appointments appointments);
    List<Appointments> ShowAppointments();
    List<Patient> GetAllAppointments();

    void EditStatusAppointment(int document, string status);

    void AppointmentPatient(int document);
    void AppointmentDoctor(string name);
}
