using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.IRepository;

namespace StudentManagement.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbfactory) : base(dbfactory)
        {
        }
    }
}