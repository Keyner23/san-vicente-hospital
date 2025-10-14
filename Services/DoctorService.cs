using san_vicente_hospital.Interfaces;
using san_vicente_hospital.Models;

namespace san_vicente_hospital.Services;

public class DoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;

    }

    public void AddDoctor()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre del doctor:");
            string name = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");
                return;
            }


            Console.WriteLine("Ingrese el número de documento del doctor:");
            if (!int.TryParse(Console.ReadLine(), out int docuemnt))
            {
                Console.WriteLine("Error: El documento es invalido.");
                return;
            }

            var existing = _doctorRepository.GetAllDoctors()
                .FirstOrDefault(p => p.docuemnt == docuemnt);
            if (existing != null)
            {
                Console.WriteLine("Error: Ya existe un doctor con ese documento.");
                return;
            }


            Console.WriteLine("Ingrese la especialidad del doctor: ");
            string specialty = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(specialty))
            {
                Console.WriteLine("Error: La especialidad no puede estar vacía.");
                return;
            }


            Console.WriteLine("Ingrese el numero de telefono del doctor:");
            if (!int.TryParse(Console.ReadLine(), out int phone))
            {
                Console.WriteLine("Error: El telefono es invalido.");
                return;
            }


            Console.WriteLine("Ingrese el email del doctor:");
            string email = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Error: El email no puede estar vacío.");
                return;
            }

            var doctor = new Doctor(name, docuemnt, phone, email, specialty);
            _doctorRepository.AddDoctor(doctor);

            Console.WriteLine();
            Console.WriteLine("DOCTOR REGISTRADO CORRECTAMENTE....");
            Console.WriteLine("------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }
    }

    public void ShowDoctors()
    {
        var doctors = _doctorRepository.GetAllDoctors();

        if (doctors.Count == 0)
        {
            Console.WriteLine("No hay doctores registrados en el sistema.");
            return;
        }
        Console.WriteLine("");
        Console.WriteLine("\nLista de doctores:");
        foreach (var doctor in doctors)
        {
            Console.WriteLine(doctor.ShowInformation());
        }
    }

    public void ShowDoctorsBySpecialty()
    {
        Console.WriteLine("Ingrese la especialidad a buscar:");
        string specialty = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(specialty))
        {
            Console.WriteLine("La especialidad no puede estar vacía.");
            return;
        }

        var doctors = _doctorRepository.GetAllDoctors()
            .Where(d => string.Equals(d.specialty?.Trim(), specialty.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (doctors.Count == 0)
        {
            Console.WriteLine($"No se encontraron doctores con la especialidad '{specialty}'.");
            return;
        }

        Console.WriteLine($"Doctores con la especialidad '{specialty}':");
        foreach (var doc in doctors)
        {
            Console.WriteLine(doc.ShowInformation());
        }
    }
}
