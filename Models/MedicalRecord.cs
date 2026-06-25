using System.ComponentModel.DataAnnotations;

namespace Mini_projet.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public string Diagnosis { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
