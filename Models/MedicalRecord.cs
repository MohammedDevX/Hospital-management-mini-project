using Mini_projet.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mini_projet.Models
{
    public class MedicalRecord : IIdentifiable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required Patient Patient { get; init; }
        public required Doctor Doctor { get; set; }
        public required string Diagnosis { get; set; }
        public DateTime ScheduledAt { get; set; }

        
    }
}
