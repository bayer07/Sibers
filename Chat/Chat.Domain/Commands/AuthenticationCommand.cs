using Chat.Domain.Exceptions;
using Chat.Domain.Models;
using Chat.Domain.Repositories;
using Chat.Domain.Requests;
using Chat.Domain.Validators;
using System;

namespace Chat.Domain.Commands
{
    public class AuthenticationCommand
    {
        AuthenticationValidator _validator;

        IUserRepository _userRepository;
        
        public AuthenticationCommand(AuthenticationValidator validator, IUserRepository userRepository)
        {
            _validator = validator;
            _userRepository = userRepository;
        }

        public bool Execute(AuthenticationRequest request)
        {
            try
            {
                if (_validator.IsUserValid(request.name, request.password))
                {
                    return _userRepository.IsValiad(request.name, request.password);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}
