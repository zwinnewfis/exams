using System;

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
            throw new NotImplementedException();
        }
    }
}