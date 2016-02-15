using System.Data.Entity;
using System.Linq;
using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.IRepository;

namespace StudentManagement.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbfactory) : base(dbfactory)
        {
            _dbFactory = dbfactory;
        }
        private readonly IDbFactory _dbFactory;
        public User Get(string userName)
        {
           
            return  DbSet.FirstOrDefault(p => p.UserName.Equals(userName));
            
        }
        private DbContext DataContext => _dbFactory.GetContext();
        private IDbSet<User> DbSet => DataContext.Set<User>();
    }
}
