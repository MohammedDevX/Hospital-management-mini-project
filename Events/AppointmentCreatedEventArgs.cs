using Mini_projet.Models;

namespace Mini_projet.Events
{
    public class AppointmentCreatedEventArgs
    {
        public Doctor Doctor { get; init; }
        public Patient Patient { get; init; }
        public DateTime ShedualedAt { get; init; }
    }
}
