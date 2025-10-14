namespace san_vicente_hospital.Models;

public class Appointments
{
    public List<Patient> patients { get; set; }

    public List<Doctor> doctors { get; set; }

    public DateTime date { get; set; }

    public string stattus { get; set; }

    public Appointments(List<Patient> patients, List<Doctor> doctors, DateTime date, string stattus)
    {
        this.patients = patients;
        this.doctors = doctors;
        this.date = date;
        this.stattus = stattus;
    }

    public string ShowAppointment()
    {
        return $"Paciente: {string.Join(", ", patients.Select(p => p.name))}, Doctor: {string.Join(", ", doctors.Select(d => d.name))}, Fecha: {date.ToShortDateString()}, Estado: {stattus}";
    }
}
