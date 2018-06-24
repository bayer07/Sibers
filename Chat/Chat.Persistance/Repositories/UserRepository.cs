using Chat.Domain.Models;
using Chat.Domain.Repositories;
using Chat.Persistance.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
                    Password = CreateMD5(userModel.Password)
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

        public bool IsValiad(string userName, string password)
        {
            var hash = CreateMD5(password);
            var user = chatContext.Users.Single(x => x.Name == userName && x.Password == hash);
            return user != null;
        }

        public void Remove(int userId)
        {
            var user = (User)GetById(userId);
            chatContext.Users.Remove(user);
            chatContext.SaveChanges();
        }

        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
