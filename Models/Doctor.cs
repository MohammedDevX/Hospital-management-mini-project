using Mini_projet.Enums;
using Mini_projet.Interfaces;

namespace Mini_projet.Models
{
    public class Doctor : IIdentifiable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public DoctorSpeciality Speciality { get; init; }
        public required Department Department { get; set; }
        public ICollection<Appointment>? Appointments { get; } = new List<Appointment>();
        public ICollection<MedicalRecord>? MedicalRecords { get; } = new List<MedicalRecord>();
    }
}
