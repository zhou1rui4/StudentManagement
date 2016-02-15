using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.Data;
using StudentManagement.IRepository;
using StudentManagement.Repository.UnitOfWork;

namespace StudentManagement.Repository.Installer
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestylePerWebRequest(),
                Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestylePerWebRequest(),
                Component.For<IDbFactory>().ImplementedBy<DataBaseFactory>().LifestyleSingleton(),
                Component.For<StudentManagementContext>().LifestylePerWebRequest(),
                Component.For<IStudentRepository>().ImplementedBy<StudentRepository>().LifestyleSingleton(),
                Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestyleSingleton(),
                Component.For<IStudentScoreRepository>().ImplementedBy<StudentScoreReposition>().LifestyleSingleton()
                );
        }
    }
}
