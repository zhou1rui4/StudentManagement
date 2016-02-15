using StudentManagement.Data.Models;

namespace StudentManagement.IRepository
{
    public interface IUserRepository:  IRepository<User>
    {
        User Get(string userName);
    }
}
