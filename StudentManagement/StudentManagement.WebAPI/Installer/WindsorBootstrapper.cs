using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using StudentManagement.Logic.Installer;
using StudentManagement.Repository.Installer;

namespace StudentManagement.WebAPI.Installer
{
    public static class WindsorBootstrapper
    {
        private static IWindsorContainer _container;

        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This(),
                FromAssembly.Containing<RepositoryInstaller>(),
                FromAssembly.Containing<LogicInstaller>()
                );

            _container.Register(Component.For<IWindsorContainer>().Instance(_container).LifestyleSingleton());
        }

        public static IWindsorContainer Container
        {
            get
            {
                return _container;
            }
        }
    }
}