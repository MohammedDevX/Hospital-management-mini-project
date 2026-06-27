using System.Net;
using System.Net.Mail;

namespace Mini_projet.Events
{
    public class EmailSenderEventHandler
    {
        public void Notify(object o, AppointmentCreatedEventArgs e)
        {
            //var smtpClient = new SmtpClient("smtp.votre-serveur.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential("utilisateur", "mot-de-passe"),
            //    EnableSsl = true,
            //};

            string body =
                $"""
                Hello {e.Patient.FullName}

                Your appointment with Dr. {e.Doctor.FullName}

                has been scheduled on

                {e.ShedualedAt}
                """;

            Console.WriteLine("Email sender : " + body);

            //string subject = "Appointment reservation";

            //smtpClient.Send("itsbakhtaouimohammed548@gmail.com", e.Patient.Email, subject, body);
        }
    }
}
