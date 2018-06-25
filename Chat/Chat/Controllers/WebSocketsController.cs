using Chat.Domain.Commands;
using Chat.Domain.Models;
using Chat.Domain.Repositories;
using Chat.Domain.Requests;
using Microsoft.Web.WebSockets;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Chat.Controllers
{
    public class WebSocketsController : ApiController
    {
        AuthenticationCommand _authenticationCommand;
        IUserRepository _userRepository;

        public WebSocketsController(AuthenticationCommand authenticationCommand, IUserRepository userRepository)
        {
            _authenticationCommand = authenticationCommand;
            _userRepository = userRepository;
        }

        [HttpGet]
        public HttpResponseMessage Get(string name, string password)
        {
            var request = new AuthenticationRequest() { name = name, password = password };
            var isAuthenticated = _authenticationCommand.Execute(request);
            if (isAuthenticated)
            {
                var user = _userRepository.GetByCredentials(name, password);
                var chatWebSocketHandler = new ChatWebSocketHandler(user);
                HttpContext.Current.AcceptWebSocketRequest(chatWebSocketHandler);
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }

            return null;
        }
    }
}
