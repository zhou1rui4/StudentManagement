using System.Data.Entity.Migrations;

namespace StudentManagement.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StudentManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentManagementContext context)
        {
        }
    }
}
