using Mini_projet.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mini_projet.Models
{
    public class Patient : IIdentifiable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required int Age { get; set; }
        public required string Email { get; set; }
        public ICollection<Appointment>? Appointments { get; } = new List<Appointment>();
        public ICollection<MedicalRecord>? MedicalRecords { get; } = new List<MedicalRecord>();
    }
}
