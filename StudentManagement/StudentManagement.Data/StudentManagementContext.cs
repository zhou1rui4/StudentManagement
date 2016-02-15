using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StudentManagement.Data.Migrations;
using StudentManagement.Data.Models;

namespace StudentManagement.Data
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext() : base("name=StudentManageContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentManagementContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
