namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserNotCreatedException : InvalidOperationServiceException
    {
        public UserNotCreatedException(string message) : base(message) {}
    }
}
