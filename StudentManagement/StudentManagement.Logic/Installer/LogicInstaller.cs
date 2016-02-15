using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.ILogic;

namespace StudentManagement.Logic.Installer
{
    public class LogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IStudentLogic>().ImplementedBy<StudentLogic>().LifestylePerWebRequest(),
                 Component.For<IUserLogic>().ImplementedBy<UserLogic>().LifestylePerWebRequest(),
                 Component.For<IStudentScoreLogic>().ImplementedBy<StudentScoreLogic>().LifestylePerWebRequest()
                );
        }
    }
}
