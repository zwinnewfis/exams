using Exams.Utils;
using System.IO;

namespace Exams.Services
{
    public interface IUserService
    {
        void SaveUserResult(string userName, int result);
    }

    public class UserService : IUserService
    {
        public void SaveUserResult(string userName, int result)
        {
            var path = IOUtil.GetCurrentAppDataFolder();
            File.WriteAllText(Path.Combine(path, userName + ".txt"), string.Format("{0}: {1}", userName, result));
        }
    }
}