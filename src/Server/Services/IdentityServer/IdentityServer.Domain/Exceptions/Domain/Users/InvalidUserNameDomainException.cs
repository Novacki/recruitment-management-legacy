namespace IdentityServer.Domain.Exceptions.Domain.Users
{
    public class InvalidUserNameDomainException : InvalidOperationDomainException
    {
        public InvalidUserNameDomainException(string message) : base(message)
        {
        }
    }
}
