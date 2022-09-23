namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserNotFoundException : NotFoundServiceException
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
