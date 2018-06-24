using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Chat.Domain.Models;
using Chat.Domain.Repositories;
using Chat.Domain.Services;
using Chat.Persistance.Repositories;
using NUnit.Framework;

namespace Chat.UnitTests
{
    [TestFixture]
    public class UserServiceFixture : WindsorTestBase<UserService>
    {
        int _userId;
        IUserRepository userRepository;

        [SetUp]
        public void Init()
        {
            userRepository = Resolve<IUserRepository>();
        }

        protected override void DoRegistrations(IWindsorContainer container)
        {
            container.Register(Classes.FromAssemblyContaining<UserService>()
                                      .Where(type => type.Name.EndsWith("Service"))
                                      .WithServiceFirstInterface()
                                      .LifestyleSingleton());

            container.Register(Classes.FromAssemblyContaining<UserRepository>()
                                      .Where(type => type.Name.EndsWith("Repository"))
                                      .WithServiceFirstInterface()
                                      .LifestyleSingleton());
        }

        [Test, Order(1)]
        public void AddUsert()
        {
            Assert.DoesNotThrow(() =>
            {
                var user = new UserDTO("User1", "password");
                _userId = userRepository.Add(user);
            });
        }

        [Test, Order(2)]
        public void GetUserById()
        {
            Assert.DoesNotThrow(() =>
            {
                var user = userRepository.GetById(_userId);
                Assert.IsNotNull(user);
            });
        }

        [Test, Order(3)]
        public void GetUserByName()
        {
            Assert.DoesNotThrow(() =>
            {
                var user = userRepository.GetById(_userId);
                Assert.IsNotNull(user);
            });
        }

        [Test, Order(4)]
        public void DeleteUserById()
        {
            Assert.DoesNotThrow(() =>
            {
                userRepository.Remove(_userId);
            });
        }
    }

}
