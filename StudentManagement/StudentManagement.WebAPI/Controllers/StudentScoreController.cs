using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;
using StudentManagement.WebAPI.Models;

namespace StudentManagement.WebAPI.Controllers
{
    public class StudentScoreController : ApiController
    {
        private readonly IStudentScoreLogic _studentScoreLogic;
        private readonly IStudentLogic _studentLogic;
        public StudentScoreController(IStudentScoreLogic studentScoreLogic, IStudentLogic studentLogic)
        {
            _studentScoreLogic = studentScoreLogic;
            _studentLogic = studentLogic;
        }

        [Route("api/studentscore")]
        [HttpPost]
        public void Create(CreateStudentScoreModel studentScoreModel)
        {
            var student = _studentLogic.Get(studentScoreModel.StudentId);
            if (student != null)
            {
                _studentScoreLogic.Create(new StudentScore {Course = studentScoreModel.Course,ExamTime = studentScoreModel.ExamTime,Score=studentScoreModel.Score,Student = student});
            }
            else
            {
                throw new Exception("Student Info error");
            }
        }

        [Route("api/studentscore")]
        [HttpPut]
        public void Update(CreateStudentScoreModel studentScoreModel)
        {
            var student = _studentLogic.Get(studentScoreModel.StudentId);
            if (student != null)
            {
                _studentScoreLogic.Create(new StudentScore { Course = studentScoreModel.Course, ExamTime = studentScoreModel.ExamTime, Score = studentScoreModel.Score, Student = student,Id = studentScoreModel.Id});
            }
            else
            {
                throw new Exception("Student Info error");
            }
        }

        [Route("api/studentscore/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _studentScoreLogic.Delete(id);
        }

        [Route("api/studentscore")]
        [HttpGet]
        public IEnumerable<StudentScore> GetAll()
        {
            return _studentScoreLogic.GetAll();
        }

        [Route("api/studentscore/{id}")]
        [HttpGet]
        public StudentScore Get(int id)
        {
            return _studentScoreLogic.Get(id);
        }

        [Route("api/studentscore/search/")]
        [HttpGet]
        public IEnumerable<SearchStudentScoreModel> Search(SearchStudentScoreModel searchStudentScoreModel)
        {
            var studentScorelist = _studentScoreLogic.QueryByName(searchStudentScoreModel.FirstName,
                searchStudentScoreModel.LastName);
            IEnumerable<SearchStudentScoreModel> searchStudentScoreModels=new List<SearchStudentScoreModel>();
            return studentScorelist.Select(studentScore => new SearchStudentScoreModel
            {
                Id = studentScore.Id,
                Course = studentScore.Course,
                Score = studentScore.Score,
                ExamTime = studentScore.ExamTime,
                StudentId = studentScore.Student.Id,
                FirstName = studentScore.Student.FirstName,
                LastName = studentScore.Student.LastName
            }).Aggregate(searchStudentScoreModels, (current, model) => current.Concat(new[] {model}));
        }
        
    }
}
