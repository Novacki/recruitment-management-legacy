namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserEmailAlreadyExistException : InvalidOperationServiceException
    {
        public UserEmailAlreadyExistException(string message) : base(message)
        {
        }
    }
}
