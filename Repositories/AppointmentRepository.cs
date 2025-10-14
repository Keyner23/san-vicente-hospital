using san_vicente_hospital.Db;
using san_vicente_hospital.Interfaces;
using san_vicente_hospital.Models;

namespace san_vicente_hospital.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    public void AddAppoiment(Appointments appointments)
    {
        Database.appointments.Add(appointments);
    }

    public List<Appointments> ShowAppointments()
    {
        return Database.appointments;
    }
    public List<Patient> GetAllAppointments()
    {
        return Database.patients;
    }
    public void EditStatusAppointment(int document, string status)
    {
        var appointment = Database.appointments
            .FirstOrDefault(a => a.patients != null && a.patients.Any(p => p.docuemnt == document));

        if (appointment != null)
        {
            appointment.stattus = status;
        }
    }
    public void AppointmentPatient(int document)
    {
        var appointment = Database.appointments
            .FirstOrDefault(a => a.patients != null && a.patients.Any(p => p.docuemnt == document));

        if (appointment != null)
        {
            Console.WriteLine(appointment.ShowAppointment());
        }
        else
        {
            Console.WriteLine("No se encontró una cita para el paciente con el documento proporcionado.");
        }
    }

    public void AppointmentDoctor(string name)
    {
        var appointment = Database.appointments
            .FirstOrDefault(a => a.doctors != null && a.doctors.Any(d => d.name == name));

        if (appointment != null)
        {
            Console.WriteLine(appointment.ShowAppointment());
        }
        else
        {
            Console.WriteLine("No se encontró una cita para el doctor con el nombre proporcionado.");
        }
    }
}
