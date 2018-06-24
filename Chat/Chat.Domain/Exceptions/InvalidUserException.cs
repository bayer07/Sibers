using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Exceptions
{
    [Serializable]
    public class InvalidUserException: Exception
    {
        public InvalidUserException() { }
        public InvalidUserException(string message) : base(message) { }
        public InvalidUserException(string message, Exception inner) : base(message, inner) { }
        protected InvalidUserException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
