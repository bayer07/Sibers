using Chat.Domain.Models;
using Microsoft.Web.WebSockets;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Controllers
{
    class ChatWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _webSocketClients = new WebSocketCollection();

        public IUserDTO User { get; set; }

        public static List<IUserDTO> Clients
        {
            get
            {
                return _webSocketClients.Select(x => ((ChatWebSocketHandler)x).User).ToList();
            }
        }

        public ChatWebSocketHandler(IUserDTO user)
        {
            User = user;
        }

        public override void OnClose()
        {
            _webSocketClients.Remove(this);
        }

        public override void OnOpen()
        {
            _webSocketClients.Add(this);
        }

        public override void OnMessage(string message)
        {
            _webSocketClients.Broadcast(User.Name + ": " + message);
        }
    }
}