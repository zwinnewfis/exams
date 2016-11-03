using Exams.Models;
using Exams.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        static string path = IOUtil.GetCurrentAssemblyFolder();

        public IEnumerable<Exam> GetExams()
        {
            var filePath = Path.Combine(path, "exams.xml");
            var exams = XmlSerializationUtil.DeserializeFile<List<Exam>>(filePath);
            return exams;
        }

        public Exam GetExam(int id)
        {
            var filePath = Path.Combine(path, id + ".xml");
            var selectedExam = XmlSerializationUtil.DeserializeFile<Exam>(filePath);
            return selectedExam;
        }

        public int CheckExam(Exam exam)
        {
            var fileWithAnswersPath = Path.Combine(path, exam.Id + "-answers.xml");
            var answers = File.ReadAllLines(fileWithAnswersPath);
            var userAnswers = exam.Questions.Select(q => q.Selected.ToString()).ToArray();

            if (answers.Length != userAnswers.Length)
            {
                throw new ArgumentException();
            }

            int okCounter = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == userAnswers[i])
                {
                    okCounter++;
                }
                else
                {
                    break;
                }
            }

            double percentage = okCounter * 100 / answers.Length;
            int mark = 2;

            if (percentage >= 80)
            {
                mark = 5;
            }
            else if (percentage >= 60)
            {
                mark = 4;
            }
            else if (percentage >= 40)
            {
                mark = 3;
            }

            return mark;
        }
    }
}