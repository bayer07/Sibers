using Chat.Domain.Enums;

namespace Chat.Domain.Responses
{
    public class ClientResponse
    {
        public ResponseCommand Command { get; set; }

        public string Message { get; set; }
    }
}
