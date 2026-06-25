using Mini_projet.Enums;

namespace Mini_projet.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public required Patient Patient { get; set; }
        public required Doctor Doctor { get; set; }
        public DateTime ShedualedAt { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
