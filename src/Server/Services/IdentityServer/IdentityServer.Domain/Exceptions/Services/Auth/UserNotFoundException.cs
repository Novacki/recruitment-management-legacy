namespace IdentityServer.Domain.Exceptions.Services.Auth
{
    public class UserNotFoundException : BaseNotFoundException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
