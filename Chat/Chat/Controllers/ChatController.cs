using Chat.Domain.Commands;
using Chat.Domain.Requests;
using System.Collections.Generic;
using System.Web.Http;

namespace Chat.Controllers
{
    [RoutePrefix("api/chat")]
    public class ChatController : ApiController
    {
        RegisterUserCommand _registerUserCommand;

        AuthenticationCommand _authenticationCommand;

        public ChatController(
            RegisterUserCommand registerUserCommand,
            AuthenticationCommand authenticationCommand)
        {
            _registerUserCommand = registerUserCommand;
            _authenticationCommand = authenticationCommand;
        }

        [HttpPost]
        [Route("register")]
        public bool Register(RegisterUserRequest request)
        {
            var userId = _registerUserCommand.Execute(request);
            return userId != 0;
        }

        [HttpPost]
        [Route("signin")]
        public bool SignIn(AuthenticationRequest request)
        {
            return _authenticationCommand.Execute(request);
        }

        [HttpGet]
        [Route("clients")]
        public List<string> Clients()
        {
            return ChatWebSocketHandler.Clients;
        }
    }
}
