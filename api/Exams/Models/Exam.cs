using System.Collections.Generic;

namespace Exams.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class UserExam
    {
        public Exam Exam { get; set; }
        public string UserName { get; set; }
    }
}