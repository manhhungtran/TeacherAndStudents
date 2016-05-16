using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Question
    {
        public long Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public QuestionCategory Category { get; set; }
        [Required]
        public int Points { get; set; }
    }
}
