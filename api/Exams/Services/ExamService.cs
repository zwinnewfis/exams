using Exams.Models;
using System;
using System.Collections.Generic;

namespace Exams.Services
{
    public interface IExamService
    {
        IEnumerable<Exam> GetExams();
        Exam GetExam(int id);
        int CheckExam(Exam exam);
    }

    public class ExamService : IExamService
    {
        public IEnumerable<Exam> GetExams()
        {
            throw new NotImplementedException();
        }

        public Exam GetExam(int id)
        {
            throw new NotImplementedException();
        }

        public int CheckExam(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}