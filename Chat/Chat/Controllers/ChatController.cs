using Chat.Domain.Commands;
using Chat.Domain.Requests;
using Chat.Domain.Validators;
using Microsoft.Web.WebSockets;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Chat.Controllers
{
    [RoutePrefix("api/chat")]
    public class ChatController : ApiController
    {
        ChatWebSocketHandler _chatWebSocketHandler;

        public ChatController(ChatWebSocketHandler chatWebSocketHandler)
        {
            _chatWebSocketHandler = chatWebSocketHandler;
        }

        [Route("register")]
        public HttpResponseMessage Get(string username, string password)
        {
            var request = new RegisterUserRequest() { UserName = username, Password = password };
            _chatWebSocketHandler.Register(request);
            HttpContext.Current.AcceptWebSocketRequest(_chatWebSocketHandler);
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
    }
}
