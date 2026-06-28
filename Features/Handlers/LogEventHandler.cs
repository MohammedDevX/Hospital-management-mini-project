using Mini_projet.Events;

namespace Mini_projet.Features.Handlers
{
    public class LogEventHandler
    {
        private string path = "C:\\Users\\hp\\Desktop\\C# projects\\TPS\\Mini_projet\\Mini_projet\\Logs\\logs.txt";

        private void Log(string ligne)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            List<string> lignes = File.ReadAllLines(path).ToList();

            lignes.Insert(0, ligne);

            File.WriteAllLines(path, lignes);
        }

        public void AppointmentCreatedLog(object source, AppointmentCreatedEventArgs e)
        {
            string ligne = $"{DateTime.UtcNow} [New appointment created | Id : {e.Id} | Doctor : {e.Doctor.FullName} " +
                $"| Patient : {e.Patient.FullName} | SheduledAt : {e.ShedualedAt}]";

            Log(ligne);
        }

        public void AppointmentCancelledLog(object source, AppointmentCancelledAndCompletedEventArgs e)
        {
            string ligne = $"{DateTime.UtcNow} [Appointment cancelled | Id : {e.Id} | Doctor : {e.Doctor.FullName} " +
                $"| Patient : {e.Patient.FullName} | SheduledAt : {e.ShedualedAt}]";

            Log(ligne);
        }

        public void AppointmentCompletedLog(object source, AppointmentCancelledAndCompletedEventArgs e)
        {
            string ligne = $"{DateTime.UtcNow} [Appointment completed | Id : {e.Id} | Doctor : {e.Doctor.FullName} " +
                $"| Patient : {e.Patient.FullName} | SheduledAt : {e.ShedualedAt}]";

            Log(ligne);
        }
    }
}
