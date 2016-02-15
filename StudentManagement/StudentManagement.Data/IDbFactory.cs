using System.Data.Entity;

namespace StudentManagement.Data
{
    public interface IDbFactory
    {
        DbContext GetContext();
    }
}