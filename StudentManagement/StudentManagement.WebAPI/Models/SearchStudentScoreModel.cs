using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.WebAPI.Models
{
    public class CreateStudentScoreModel
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public int Score { get; set; }
        public DateTime ExamTime { get; set; }
        public int StudentId { get; set; }
    }

    public class SearchStudentScoreModel
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public int Score { get; set; }
        public DateTime ExamTime { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}