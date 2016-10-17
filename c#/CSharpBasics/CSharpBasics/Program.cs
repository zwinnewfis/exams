using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wfis!");

            Exam e1 = new Exam();
            Exam e2 = new Exam(122);

            Console.WriteLine(e1);
            Console.WriteLine(e2);

            List<Exam> listOfExams = new List<Exam>();
            for (int i = 0; i < 10; i++)
            {
                listOfExams.Add(new Exam(i));
            }

            int x = 0;
            foreach (var exam in listOfExams)
            {
                Console.WriteLine("Exam #{0}: {1}", x++, exam);
            }

            string fileName = "exams.xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Exam>));
            using (FileStream fileStream = File.OpenWrite(fileName))
            {
                xmlSerializer.Serialize(fileStream, listOfExams);
            }

            string xmlContent = File.ReadAllText(fileName);
            Console.WriteLine(xmlContent);

            Console.ReadLine();
        }
    }

    public class Exam
    {
        static int counter = 0;

        public int Id { get; set; }

        private int id;
        public int Id_full
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Date { get; set; }

        public Exam()
        {
            Console.WriteLine("Exam: Constructor 1");
            Id = 10;
            id = 15;
            Date = DateTime.Now;
        }

        public Exam(int i)
        {
            Console.WriteLine("Exam: Constructor with parameter: {0}", i);
            Id = i;
            id = i + 5;
            Date = DateTime.Now;
        }

        public static Exam CreateNewExam()
        {
            return new Exam(counter++);
        }

        public override string ToString()
        {
            return string.Format("Exam (ToString()): Id={0}; Id_full={1}; id={2}", Id, Id_full, id);
        }
    }
}
