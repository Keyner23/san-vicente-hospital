using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using san_vicente_hospital.Models;

namespace san_vicente_hospital.Services;

public class EmailService
{
    // Env vars: SMTP_HOST, SMTP_PORT, SMTP_USER, SMTP_PASS, SMTP_ENABLE_SSL
    public async Task SendAppointmentConfirmationAsync(string toEmail, Appointments appointment)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                Console.WriteLine("Email de destino vacío. No se envía confirmación.");
                return;
            }

            string host = Environment.GetEnvironmentVariable("SMTP_HOST") ?? string.Empty;
            string portStr = Environment.GetEnvironmentVariable("SMTP_PORT") ?? string.Empty;
            string user = Environment.GetEnvironmentVariable("SMTP_USER") ?? string.Empty;
            string pass = Environment.GetEnvironmentVariable("SMTP_PASS") ?? string.Empty;
            string enableSslStr = Environment.GetEnvironmentVariable("SMTP_ENABLE_SSL") ?? "true";
            int port = 0;
            int.TryParse(portStr, out port);
            bool enableSsl = bool.TryParse(enableSslStr, out bool tmp) ? tmp : true;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Clínica San Vicente", string.IsNullOrWhiteSpace(user) ? "no-reply@localhost" : user));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "Confirmación de cita - Clínica San Vicente";

            var bodyBuilder = new BodyBuilder
            {
                TextBody = $"Su cita ha sido registrada:{Environment.NewLine}{Environment.NewLine}{appointment.ShowAppointment()}"
            };
            message.Body = bodyBuilder.ToMessageBody();

            if (string.IsNullOrEmpty(host) || port == 0 || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                // Fallback: guardar en ./emails
                var dir = Path.Combine(Directory.GetCurrentDirectory(), "emails");
                Directory.CreateDirectory(dir);
                var filePath = Path.Combine(dir, $"appointment_{DateTime.Now:yyyyMMddHHmmss}.eml");
                await File.WriteAllTextAsync(filePath, message.ToString(), Encoding.UTF8);
                Console.WriteLine($"No hay configuración SMTP; el correo se guardó en: {filePath}");
                return;
            }

            using var client = new SmtpClient();
            try
            {
                var secure = enableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                await client.ConnectAsync(host, port, secure);
                await client.AuthenticateAsync(user, pass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                Console.WriteLine("Confirmación de cita enviada al correo del paciente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo vía SMTP: {ex.Message}");
                // Como fallback, guardar en ./emails
                var dir = Path.Combine(Directory.GetCurrentDirectory(), "emails");
                Directory.CreateDirectory(dir);
                var filePath = Path.Combine(dir, $"appointment_failed_{DateTime.Now:yyyyMMddHHmmss}.eml");
                await File.WriteAllTextAsync(filePath, message.ToString(), Encoding.UTF8);
                Console.WriteLine($"El mensaje se guardó en archivo por fallo: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al preparar el correo de confirmación: {ex.Message}");
        }
    }
}
