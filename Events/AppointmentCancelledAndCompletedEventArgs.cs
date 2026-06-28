using Mini_projet.Models;

namespace Mini_projet.Events
{
    public class AppointmentCancelledAndCompletedEventArgs : EventArgs
    {
        public Guid Id { get; init; }
        public Doctor Doctor { get; init; }
        public Patient Patient { get; init; }
        public DateTime ShedualedAt { get; init; }
    }
}
