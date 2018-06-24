using Chat.Domain.Models;
using Chat.Domain.Repositories;
using Chat.Persistance.Models;
using System;
using System.Linq;

namespace Chat.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        ChatContext chatContext;

        public UserRepository()
        {
            chatContext = new ChatContext();
        }

        public int Add(IUserDTO userModel)
        {
            try
            {
                var user = new User()
                {
                    Name = userModel.Name,
                    Password = userModel.Password
                };

                var entity = chatContext.Users.Add(user);
                chatContext.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex)
            {
                // There may be log4net;
                return 0;
            }
        }

        public void Dispose()
        {
            //chatContext.Dispose();
        }

        public IUserDTO GetById(int userId)
        {
            return chatContext.Users.Single(x => x.Id == userId);
        }

        public void Remove(int userId)
        {
            var user = (User)GetById(userId);
            chatContext.Users.Remove(user);
            chatContext.SaveChanges();
        }
    }
}
