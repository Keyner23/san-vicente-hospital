namespace san_vicente_hospital.Models;

public class Appointments
{
    public static List<Patient> patients { get; set; }

    public static List<Doctor> doctors { get; set; }

    public static DateTime date { get; set; }

    public string stattus { get; set; }

    
    public Appointments()
    {
        patients = new List<Patient>();
        doctors = new List<Doctor>();
        date = DateTime.Now;
        stattus = "Asiganda";
    }

}
