using Chat.Domain.Enums;
using Chat.Domain.Models;
using Chat.Domain.Responses;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
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

            var response = new ClientResponse()
            {
                Command = ResponseCommand.Disconnected,
            };

            var json = JsonConvert.SerializeObject(response);
            _webSocketClients.Broadcast(json);
        }

        public override void OnOpen()
        {
            _webSocketClients.Add(this);

            var response = new ClientResponse()
            {
                Command = ResponseCommand.Connected,
            };

            var json = JsonConvert.SerializeObject(response);
            _webSocketClients.Broadcast(json);
        }

        public override void OnMessage(string message)
        {
            var response = new ClientResponse()
            {
                Command = ResponseCommand.Message,
                Message = User.Name + " say:" + message
            };

            var json = JsonConvert.SerializeObject(response);
            _webSocketClients.Broadcast(json);
        }
    }
}