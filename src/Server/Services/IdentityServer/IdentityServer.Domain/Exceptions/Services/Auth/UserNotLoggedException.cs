namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserNotLoggedException : BaseBadRequestException
    {
        public UserNotLoggedException()
        {
        }

        public UserNotLoggedException(string message) : base(message)
        {
        }
    }
}
