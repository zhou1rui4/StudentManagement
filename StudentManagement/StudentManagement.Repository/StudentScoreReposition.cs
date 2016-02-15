using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.IRepository;

namespace StudentManagement.Repository
{
    public class StudentScoreReposition:RepositoryBase<StudentScore>,IStudentScoreRepository
    {
        public StudentScoreReposition(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
