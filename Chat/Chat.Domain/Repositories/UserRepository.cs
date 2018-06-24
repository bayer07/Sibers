using Chat.Persistance;
using Chat.Persistance.Models;
using Chat.Persistance.Repositories;
using System;

namespace Chat.Domain.Repositories
{
    public class UserRepository : UoW, IDisposable
    {
        EfUserRepository efUserRepository;

        public UserRepository()
        {
            efUserRepository = new EfUserRepository();
        }

        public void Add(User user)
        {
            efUserRepository.Add(user);
        }

        public void Commit()
        {
            efUserRepository.Commit();
        }

        public void Dispose()
        {
            efUserRepository.Dispose();
        }
    }
}
