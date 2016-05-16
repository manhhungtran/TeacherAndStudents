using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Answer
    {
        public long Id { get; set; }
        [Required]
        public Question Question { get; set; }
        [Required]
        public bool Correct { get; set; }
    }
}
