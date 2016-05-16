using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class StudentCategory
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
