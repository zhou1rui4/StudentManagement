using System.Collections.Generic;
using System.Linq;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;
using StudentManagement.IRepository;
using StudentManagement.Repository.UnitOfWork;

namespace StudentManagement.Logic
{
    public class StudentScoreLogic:IStudentScoreLogic
    {
        private readonly IStudentScoreRepository _studentScoreRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public StudentScoreLogic(IStudentScoreRepository studentRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _studentScoreRepository = studentRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(StudentScore studentScore)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _studentScoreRepository.Create(studentScore);
                unitOfWork.Commit();
            }
        }

        public void Update(StudentScore studentScore)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _studentScoreRepository.Edit(studentScore);
                unitOfWork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _studentScoreRepository.Delete(id);
                unitOfWork.Commit();
            }
        }

        public IEnumerable<StudentScore> GetAll()
        {
            return _studentScoreRepository.Query().ToList();
        }

        public StudentScore Get(int id)
        {
            return _studentScoreRepository.Get(id);
        }

        public IEnumerable<StudentScore> QueryByName(string firstName, string lastName)
        {
            return _studentScoreRepository.Query()
                .Where( p =>p.Student.FirstName.Contains(firstName) && p.Student.LastName.ToLower().Contains(lastName.ToLower()))
                .ToList();
        }
    }
}
