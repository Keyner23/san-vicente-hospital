using san_vicente_hospital.Utils;
using san_vicente_hospital.Repositories;
using san_vicente_hospital.Services;



var menu = new Menu();
var patientRepository = new PatientRepository();
var patientServiceservice = new PatientService(patientRepository);
var doctorRepository = new DoctorRepository();
var doctorService = new DoctorService(doctorRepository);
var appointmentRepository = new AppointmentRepository();
var appointmentService = new AppointmentService(appointmentRepository);


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
            Console.WriteLine("");
            Console.WriteLine("---- REGISTAR DOCTORES ----");
            Console.WriteLine("---------------------------");
            doctorService.AddDoctor();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 4:
            Console.WriteLine("");
            Console.WriteLine("---- VER DOCTORES ----");
            Console.WriteLine("---------------------------");
            doctorService.ShowDoctors();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 5:
            Console.WriteLine("");
            Console.WriteLine("---- VER DOCTORES POR ESPECIALIDAD ----");
            Console.WriteLine("---------------------------");
            doctorService.ShowDoctorsBySpecialty();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 6:
            Console.WriteLine("");
            Console.WriteLine("---- REGISTRAR CITA ----");
            Console.WriteLine("---------------------------");
            appointmentService.AddAppointment();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 7:
            Console.WriteLine("");
            Console.WriteLine("---- VER CITAS ----");
            Console.WriteLine("---------------------------");
            appointmentService.ShowAppointments();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 8:
            Console.WriteLine("---- CAMBIAR ESTADO DE CITA ----");
            Console.WriteLine("---------------------------");
            appointmentService.EditStatusAppointment();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 9:
            Console.WriteLine("");
            Console.WriteLine("---- VER CITAS DE PACIENTE ----");
            Console.WriteLine("---------------------------");
            appointmentService.ShowAppointmentsByDoc();
            Console.WriteLine("");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 10:
            Console.WriteLine("");
            Console.WriteLine("---- VER CITAS DE DOCTOR ----");
            Console.WriteLine("---------------------------");
            appointmentService.ShowAppointmentsByDoctor();
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

