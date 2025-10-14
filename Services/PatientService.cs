using san_vicente_hospital.Interfaces;
using san_vicente_hospital.Models;

namespace san_vicente_hospital.Services;

public class PatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;

    }

    public void AddPatient()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre del paciente:");
            string name = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }
            Console.WriteLine("Ingrese el número de documento del paciente:");
            if (!int.TryParse(Console.ReadLine(), out int docuemnt))
            {
                Console.WriteLine("El documento es invalido.");
                return;
            }
           
            var existing = _patientRepository.GetAllPatients()
                .FirstOrDefault(p => p.docuemnt == docuemnt);
            if (existing != null)
            {
                Console.WriteLine("Error: Ya existe un paciente con ese documento.");
                return;
            }

            
            Console.WriteLine("Ingrese la edad del paciente:");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("La edad es invalida.");
                return;
            }

            Console.WriteLine("Ingrese el numero de telefono del paciente:");
            if (!int.TryParse(Console.ReadLine(), out int phone))
            {
                Console.WriteLine("El telefono es invalido.");
                return;
            }
            Console.WriteLine("Ingrese el email del paciente:");
            string email = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("El email no puede estar vacío.");
                return;
            }

            if (!email.Contains('@'))
            {
                Console.WriteLine("El email debe contener '@' para ser válido.");
                return;
            }

            var patient = new Patient(name, docuemnt, phone, email, age);
            _patientRepository.AddPatient(patient);

            Console.WriteLine();
            Console.WriteLine("PACIENTE REGISTRADO CORRECTAMENTE....");
            Console.WriteLine("------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }

    }

    public void ShowPatients()
    {
        var patients = _patientRepository.GetAllPatients();

        if (patients.Count == 0)
        {
            Console.WriteLine("No hay pacientes registrados en el sistema.");
            return;
        }
        Console.WriteLine("");
        Console.WriteLine("\nLista de pacientes:");
        foreach (var patient in patients)
        {
            Console.WriteLine(patient.ShowInformation());
        }
    }

}
