using san_vicente_hospital.Db;
using san_vicente_hospital.Interfaces;
using san_vicente_hospital.Models;
using System.Net.Mail;
using System.Net;

namespace san_vicente_hospital.Services;

public class AppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public void AddAppointment()
    {
        try
        {
            Console.WriteLine("Escriba el nombre del doctor:");
            string? doctor = Console.ReadLine();
            doctor = doctor ?? string.Empty;

            var doctorEncontrado = Database.doctors
                .FirstOrDefault(d => d.name.Equals(doctor, StringComparison.OrdinalIgnoreCase));

            if (doctorEncontrado == null)
            {
                Console.WriteLine("El doctor no se encuentra registrado en el sistema.");
                return;
            }



            // Pedimos el documento del paciente para identificarlo con certeza
            Console.WriteLine("Escriba el documento del paciente:");
            if (!int.TryParse(Console.ReadLine(), out int patientDocument))
            {
                Console.WriteLine("Documento inválido.");
                return;
            }

            var patientEncontrado = Database.patients
                .FirstOrDefault(p => p.docuemnt == patientDocument);

            if (patientEncontrado == null)
            {
                Console.WriteLine("El paciente no se encuentra registrado en el sistema.");
                return;
            }
            string emailPaciente = patientEncontrado.email;


            var pacienteConCita = Database.appointments
                .Any(a => a.patients != null && a.patients.Any(p => p.docuemnt == patientEncontrado.docuemnt));

            if (pacienteConCita)
            {
                Console.WriteLine("El paciente ya tiene una cita asignada.");
                return;
            }


            var doctorConCita = Database.appointments
                .Any(a => a.doctors != null && a.doctors.Any(d => d.docuemnt == doctorEncontrado.docuemnt));

            if (doctorConCita)
            {
                Console.WriteLine("El doctor ya tiene una cita asignada.");
                return;
            }

            string? dateInput = DateTime.Now.ToString("yyyy-MM-dd"); //Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("Formato de fecha inválido.");
                return;
            }



            var newAppointment = new Appointments(
                new List<Patient> { patientEncontrado },
                new List<Doctor> { doctorEncontrado },
                date,
                "Asignada"

            );

            _appointmentRepository.AddAppoiment(newAppointment);
            Console.WriteLine("----- CITA CREADA CORRECTAMENTE -----");

            SendEmail(
                emailPaciente,
                "Confirmación de cita médica",
                $"Hola {patientEncontrado.name},<br>Tu cita con el doctor {doctorEncontrado.name} ha sido registrada para el día {date:dd/MM/yyyy}."
            );




        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear cita: {ex.Message}");
        }
    }

    public void ShowAppointments()
    {
        var appointments = _appointmentRepository.ShowAppointments();

        if (appointments.Count == 0)
        {
            Console.WriteLine("No hay citas registradas en el sistema.");
            return;
        }

        Console.WriteLine("\nLista de citas:");
        foreach (var appointment in appointments)
        {
            Console.WriteLine(appointment.ShowAppointment());
        }
    }

    public void EditStatusAppointment()
    {
        try
        {
            Console.WriteLine("Ingrese el documento del paciente para cambiar el estado de la cita:");
            if (!int.TryParse(Console.ReadLine(), out int document))
            {
                Console.WriteLine("Documento inválido.");
                return;
            }
            if (!Database.patients.Any(p => p.docuemnt == document))
            {
                Console.WriteLine("No existe un paciente con ese documento.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo estado de la cita (Asignada, Atendita, Cancelada):");
            string? status = Console.ReadLine();
            status = status ?? string.Empty;

            var validStatuses = new List<string> { "asignada", "atendida", "cancelada" };
            if (!validStatuses.Contains(status, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Estado inválido. Los estados válidos son: Asignada, Completada, Cancelada.");
                return;
            }

            _appointmentRepository.EditStatusAppointment(document, status);
            Console.WriteLine("----- ESTADO DE CITA ACTUALIZADO CORRECTAMENTE -----");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar estado de cita: {ex.Message}");
        }
    }

    public void ShowAppointmentsByDoc()
    {
        try
        {
            Console.WriteLine("Ingrese el documento del paciente para ver sus citas:");
            if (!int.TryParse(Console.ReadLine(), out int document))
            {
                Console.WriteLine("Error: Documento inválido.");
                return;
            }
            if (!Database.patients.Any(p => p.docuemnt == document))
            {
                Console.WriteLine("No existe un paciente con ese documento.");
                return;
            }

            _appointmentRepository.AppointmentPatient(document);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mostrar citas del paciente: {ex.Message}");
        }
    }

    public void ShowAppointmentsByDoctor()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre del doctor para ver sus citas:");
            string? name = Console.ReadLine();
            name = name ?? string.Empty;

            if (!Database.doctors.Any(d => d.name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Error: No existe un doctor con ese nombre.");
                return;
            }

            _appointmentRepository.AppointmentDoctor(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mostrar citas del doctor: {ex.Message}");
        }

    }

    private void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("keinerba.ochoa@gmail.com", "erqwqhkxsduvhebe"), // tu correo y app password (sin espacios)
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("keinerba.ochoa@gmail.com", "Hospital San Vicente"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);

                Console.WriteLine("📧 Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error enviando correo: {ex.Message}");
            }
        }

}


