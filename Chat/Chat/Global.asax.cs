using System;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Chat.Controllers;
using System.Web.Http.Dispatcher;
using Chat.DependencyInjection.Installers;

namespace Chat
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        WindsorContainer _container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            _container = new WindsorContainer();
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));

            var domain = new DependencyInjection.Installers.Domain();
            _container.Install(domain);

            var persistance = new Persistence();
            _container.Install(persistance);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}
