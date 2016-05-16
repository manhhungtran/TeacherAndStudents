using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class QuestionCategory
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
