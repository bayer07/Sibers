using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chat.Domain.Commands;
using Chat.Domain.Models;
using Chat.Domain.Services;
using Chat.Domain.Validators;
using Chat.Persistance.Models;

namespace Chat.DependencyInjection.Installers
{
    public class Domain : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<RegisterUserValidator>()
                                      .Where(type => type.Name.EndsWith("Validator"))
                                      .WithServiceSelf()
                                      .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<RegisterUserCommand>()
                                      .Where(type => type.Name.EndsWith("Command"))
                                      .WithServiceSelf()
                                      .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<UserDTO>()
                                      .Where(type => type.Name.EndsWith("DTO"))
                                      .WithServiceSelf()
                                      .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<UserService>()
                                      .Where(type => type.Name.EndsWith("Service"))
                                      .WithServiceSelf()
                                      .LifestylePerWebRequest());

        }
    }
}
