using System;

namespace BussinessLayer.DTO
{
    public class ExamDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public long Category { get; set; }
        public long Subject { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
