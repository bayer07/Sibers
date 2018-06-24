using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using NSubstitute;
using NUnit.Framework;

namespace Chat.UnitTests
{
    [TestFixture]
    public abstract class WindsorTestBase<TService> where TService : class
    {
        private IWindsorContainer container;

        protected TService Service;

        [SetUp]
        public void SetUp()
        {
            container = new WindsorContainer().
                Register(Component.For<ILazyComponentLoader>().
                ImplementedBy<LazyNSubstituteMocker>(), Component.For<TService>());

            DoRegistrations(container);
            Service = container.Resolve<TService>();
            DoSetUp();
        }

        protected virtual void DoRegistrations(IWindsorContainer container) { }

        protected virtual void DoSetUp() { }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
            container.Dispose();
        }

        protected virtual void DoTearDown() { }

        protected TDependency Resolve<TDependency>()
        {
            return container.Resolve<TDependency>();
        }

        protected TMock Mock<TMock>() where TMock : class
        {
            return Substitute.For<TMock>();
        }

        protected void Register<TMock>(TMock instance) where TMock : class
        {
            container.Register(Component.For<TMock>().Instance(instance));
        }
    }
}
