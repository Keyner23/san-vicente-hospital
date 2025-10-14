using san_vicente_hospital.Utils;
using san_vicente_hospital.Repositories;
using san_vicente_hospital.Services;



var menu = new Menu();
var patientRepository = new PatientRepository();
var patientServiceservice = new PatientService(patientRepository);
var doctorRepository = new DoctorRepository();
var doctorService = new DoctorService(doctorRepository);
int opcion;
do
{
    opcion = menu.showMenu();
    switch (opcion)
    {
        case 0:
            Console.WriteLine("Saliendo...");
            break;
        case 1:
            Console.WriteLine("");
            Console.WriteLine("---- REGISTRAR PACIENTE ----");
            Console.WriteLine("---------------------------");
            patientServiceservice.AddPatient();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("");
            Console.WriteLine("---- VER PACIENTES ----");
            Console.WriteLine("---------------------------");
            patientServiceservice.ShowPatients();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 3:
            Console.WriteLine("---- REGISTAR DOCTORES ----");
            Console.WriteLine("---------------------------");
            doctorService.AddDoctor();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 4:
            Console.WriteLine("---- VER DOCTORES ----");
            Console.WriteLine("---------------------------");
            doctorService.ShowDoctors();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 5:
            Console.WriteLine("---- VER DOCTORES POR ESPECIALIDAD ----");
            Console.WriteLine("---------------------------");
            doctorService.ShowDoctorsBySpecialty();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Opción no reconocida. Presione ENTER para continuar...");
            Console.ReadLine();
            break;
    }

} while (opcion != 0);

