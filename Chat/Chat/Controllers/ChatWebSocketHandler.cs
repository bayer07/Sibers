using Microsoft.Web.WebSockets;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Controllers
{
    class ChatWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _webSocketClients = new WebSocketCollection();
        private string _username;

        private static List<string> _clients = new List<string>();


        public static List<string> Clients
        {
            get
            {
                return _clients;
            }
        }

        public ChatWebSocketHandler(string username)
        {
            _username = username;
        }

        public bool IsConnected(string name)
        {
            var socket = _webSocketClients.SingleOrDefault(r => ((ChatWebSocketHandler)r)._username == _username);
            return socket != null;
        }

        public override void OnOpen()
        {
            _webSocketClients.Add(this);
            _clients.Add(_username);
        }

        public override void OnMessage(string message)
        {
            _webSocketClients.Broadcast(_username + ": " + message);
        }
    }
}