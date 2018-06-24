using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using NSubstitute;
using System;
using System.Collections;

namespace Chat.UnitTests
{
    public class LazyNSubstituteMocker : ILazyComponentLoader
    {
        public IRegistration Load(string key, Type service, IDictionary arguments)
        {
            return Component.For(service).Instance(Substitute.For(new[] {service }, null));
        }
    }
}
