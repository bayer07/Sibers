using Chat.Domain.Commands;
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

        public WebSocketsController(AuthenticationCommand authenticationCommand)
        {
            _authenticationCommand = authenticationCommand;
        }

        [HttpGet]
        public HttpResponseMessage Get(string name, string password)
        {
            var request = new AuthenticationRequest() { name = name, password = password };
            var isAuthenticated = _authenticationCommand.Execute(request);
            if (isAuthenticated)
            {
                var chatWebSocketHandler = new ChatWebSocketHandler(name);
                if (!chatWebSocketHandler.IsConnected(name))
                {
                    HttpContext.Current.AcceptWebSocketRequest(chatWebSocketHandler);
                    return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
                }
            }

            return null;
        }

        
   }
}
