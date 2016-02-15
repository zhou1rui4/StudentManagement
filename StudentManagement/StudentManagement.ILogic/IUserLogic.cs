using System.Collections.Generic;
using StudentManagement.Data.Models;

namespace StudentManagement.ILogic
{
    public interface IUserLogic
    {
        void Create(User model);
        void Edit(User model);
        void Delete(int id);
        User Get(int id);
        bool Login(string userName, string password,out string message);
        IEnumerable<User> GetAll();
        IEnumerable<User> QueryByName(string userName);
    }
}
