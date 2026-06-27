using Mini_projet.Events;

namespace Mini_projet.Features.Handlers
{
    public class LogEventHandler
    {
        private string path = "C:\\Users\\hp\\Desktop\\C# projects\\TPS\\Mini_projet\\Mini_projet\\Logs\\logs.txt";

        public void AppointmentCretatedLog(object o, AppointmentCreatedEventArgs e)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            List<string> lignes = File.ReadAllLines(path).ToList();

            string ligne = $"{DateTime.UtcNow} [New appointment created | Doctor : {e.Doctor.FullName} | Patient : {e.Patient.FullName}" +
                $" | SheduledAt : {e.ShedualedAt}]";
            lignes.Insert(0, ligne);

            File.WriteAllLines(path, lignes);
        }
    }
}
