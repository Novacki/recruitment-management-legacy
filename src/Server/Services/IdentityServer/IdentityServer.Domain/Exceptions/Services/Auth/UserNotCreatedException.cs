namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserNotCreatedException : BaseBadRequestException
    {
        public UserNotCreatedException()
        {
        }

        public UserNotCreatedException(string message) : base(message)
        {
        }
    }
}
