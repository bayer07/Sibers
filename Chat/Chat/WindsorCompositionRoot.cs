using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Chat.DependencyInjection.Installers
{
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorCompositionRoot(IWindsorContainer container)
        {
            _container = container;

            _container.Register(Classes.FromThisAssembly()
                                      .Where(type => type.Name.EndsWith("Controller"))
                                      .WithServiceSelf()
                                      .LifestylePerWebRequest());

            _container.Register(Classes.FromThisAssembly()
                                      .Where(type => type.Name.EndsWith("Handler"))
                                      .WithServiceSelf()
                                      .LifestylePerWebRequest());
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = (IHttpController)_container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(() => _container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                release();
            }
        }
    }
}
