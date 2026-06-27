using Mini_projet.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mini_projet.Models
{
    public class Department : IIdentifiable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        public int Floor { get; set; }
        public required string PhoneNumber { get; set; }
        public ICollection<Doctor>? Doctors { get; } = new List<Doctor>();
    }
}
