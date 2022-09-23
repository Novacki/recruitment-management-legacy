namespace IdentityServer.Domain.Exceptions
{
    public abstract class NotFoundServiceException : BaseException
    {
        protected NotFoundServiceException(string message) : base(message) { }
    }

}
