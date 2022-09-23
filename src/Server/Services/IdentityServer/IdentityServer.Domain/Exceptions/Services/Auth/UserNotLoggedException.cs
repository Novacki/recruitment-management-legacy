namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserNotLoggedException : InvalidOperationServiceException
    {
        public UserNotLoggedException(string message) : base(message)
        {
        }
    }
}
