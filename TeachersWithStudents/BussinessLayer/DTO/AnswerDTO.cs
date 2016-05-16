using DataAccessLayer.Entities;

namespace BussinessLayer.DTO
{
    public class AnswerDTO
    {
        public long Id { get; set; }
        public long Question { get; set; }
        public bool Correct { get; set; }
    }
}
