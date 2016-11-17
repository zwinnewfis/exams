using Exams.Models;
using Exams.Utils;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Exams.Services
{
    public interface IUserService
    {
        void SaveUserResult(UserExam userExam, int result);
        byte[] GetResults();
    }

    public class UserService : IUserService
    {
        string path = IOUtil.GetCurrentAppDataFolder();

        public void SaveUserResult(UserExam userExam, int result)
        {
            if (userExam == null)
            {
                throw new ArgumentException();
            }
            var userAnswers = userExam.Exam.Questions.Select(q => q.Selected.ToString()).ToArray();
            File.WriteAllText(Path.Combine(path, userExam.UserName + ".txt"), string.Format("{0}: {1}\n{2}", userExam.UserName, result, string.Join("\n", userAnswers)));
        }

        public byte[] GetResults()
        {
            var path = IOUtil.GetCurrentAppDataFolder();
            var files = Directory.GetFiles(path, "*.txt").OrderBy(s => s);
            using (var ms = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        zipArchive.CreateEntryFromFile(file, new FileInfo(file).Name);
                    }
                }
                return ms.ToArray();
            }
        }
    }
}