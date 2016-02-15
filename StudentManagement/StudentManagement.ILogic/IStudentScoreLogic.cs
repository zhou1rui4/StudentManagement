using System.Collections.Generic;
using StudentManagement.Data.Models;

namespace StudentManagement.ILogic
{
    public interface IStudentScoreLogic
    {
        void Create(StudentScore studentScore);
        void Update(StudentScore studentScore);
        void Delete(int id);
        IEnumerable<StudentScore> GetAll();
        StudentScore Get(int id);
        IEnumerable<StudentScore> QueryByName(string firstName, string lastName);
    }
}
