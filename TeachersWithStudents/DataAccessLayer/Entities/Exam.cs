using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Exam
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public QuestionCategory Category { get; set; }
        [Required]
        public Subject Subject { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
