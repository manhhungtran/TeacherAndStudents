using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public Teacher AssignedTeacher { get; set; }
        [Required]
        public StudentCategory Category { get; set; }
    }
}
