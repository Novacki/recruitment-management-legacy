using System.Runtime.Serialization;

namespace IdentityServer.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string message) : base(message) { }
        protected BaseException(string message, Exception innerException) : base(message, innerException) { }
        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
