using Mini_projet.Enums;
using Mini_projet.Interfaces;

namespace Mini_projet.Models
{
    public class Appointment : IIdentifiable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required Patient Patient { get; init; }
        public required Doctor Doctor { get; set; }
        public DateTime ScheduledAt { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Confirmed;
    }
}
