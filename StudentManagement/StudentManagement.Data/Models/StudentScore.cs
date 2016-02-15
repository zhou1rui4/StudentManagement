using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Data.Models
{
    public class StudentScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Course { get; set; }
        public  int Score { get; set; }
        public DateTime ExamTime { get; set; }
        public virtual Student Student { get; set; }
    }
}
