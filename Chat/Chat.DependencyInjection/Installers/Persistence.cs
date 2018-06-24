using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chat.Persistance.Repositories;

namespace Chat.DependencyInjection.Installers
{
    public class Persistence : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<UserRepository>()
                                      .Where(type => type.Name.EndsWith("Repository"))
                                      .WithServiceFirstInterface()
                                      .LifestylePerWebRequest());
        }
    }
}
