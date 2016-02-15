using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace StudentManagement.Data.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IdentityId { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public virtual IEnumerable<StudentScore> StudentScores { get; set; }
    }
}
