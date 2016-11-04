using System.Collections.Generic;

namespace Exams.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Answers { get; set; }
        public int? Selected { get; set; }
    }
}
