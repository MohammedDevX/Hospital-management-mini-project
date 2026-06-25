using Mini_projet.Enums;

namespace Mini_projet.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DoctorSpeciality Speciality { get; set; }
        public Department Department { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
