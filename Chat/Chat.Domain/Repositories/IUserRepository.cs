﻿using Chat.Domain.Models;

namespace Chat.Domain.Repositories
{
    public interface IUserRepository
    {
        int Add(IUserDTO user);

        IUserDTO GetById(int userId);

        void Remove(int userId);

        bool IsValiad(string name, string password);

        IUserDTO GetByCredentials(string name, string password);
    }
}
