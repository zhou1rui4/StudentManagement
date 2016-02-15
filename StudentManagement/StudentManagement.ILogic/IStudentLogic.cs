using System.Collections.Generic;
using StudentManagement.Data.Models;

namespace StudentManagement.ILogic
{
    public interface IStudentLogic
    {
        void Create(Student model);
        void Update(Student model);
        void Delete(int id);
        IEnumerable<Student> GetAll();
        Student Get(int id);
        IEnumerable<Student> QueryByName(string firstName, string lastName);
    }
}
