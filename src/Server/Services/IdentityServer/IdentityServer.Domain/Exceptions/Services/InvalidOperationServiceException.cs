namespace IdentityServer.Domain.Exceptions.Services
{
    public abstract class InvalidOperationServiceException : BaseException
    {
        protected InvalidOperationServiceException(string message) : base(message)
        {
        }
    }
}
