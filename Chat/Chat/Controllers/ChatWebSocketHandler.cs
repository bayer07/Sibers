using Chat.Domain.Commands;
using Chat.Domain.Requests;
using Microsoft.Web.WebSockets;

namespace Chat.Controllers
{
    public class ChatWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _chatClients = new WebSocketCollection();
        private string _username;
        RegisterUserCommand _registerUserCommand;

        public ChatWebSocketHandler(RegisterUserCommand registerUserCommand)
        {
            _registerUserCommand = registerUserCommand;
        }

        public void Register(RegisterUserRequest request)
        {
            _registerUserCommand.Execute(request);
            _username = request.UserName;
        }

        public override void OnOpen()
        {
            _chatClients.Add(this);
        }

        public override void OnMessage(string message)
        {
            _chatClients.Broadcast(_username + ": " + message);
        }
    }
}