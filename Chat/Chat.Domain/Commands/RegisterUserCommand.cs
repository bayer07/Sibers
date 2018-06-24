using Chat.Domain.Exceptions;
using Chat.Domain.Models;
using Chat.Domain.Repositories;
using Chat.Domain.Requests;
using Chat.Domain.Validators;
using System;

namespace Chat.Domain.Commands
{
    public class RegisterUserCommand
    {
        RegisterUserValidator _validator;

        IUserRepository _userRepository;
        
        public RegisterUserCommand(RegisterUserValidator validator, IUserRepository userRepository)
        {
            _validator = validator;
            _userRepository = userRepository;
        }

        public void Execute(RegisterUserRequest request)
        {
            try
            {
                if (_validator.IsUserValid(request.UserName, request.Password))
                {
                    var user = new UserDTO(request.UserName, request.Password);

                    _userRepository.Add(user);
                }
                else
                {
                    throw new InvalidUserException();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
