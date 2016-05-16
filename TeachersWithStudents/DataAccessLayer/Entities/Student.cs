using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public StudentCategory Category { get; set; }
    }
}
