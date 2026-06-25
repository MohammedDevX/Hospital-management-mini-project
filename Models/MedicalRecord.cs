using System.ComponentModel.DataAnnotations;

namespace Mini_projet.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
