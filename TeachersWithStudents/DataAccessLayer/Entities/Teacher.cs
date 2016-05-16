using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Teacher
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
