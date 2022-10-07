namespace IdentityServer.Domain.Exceptions.Domain.Users
{
    public class InvalidUserEmailDomainException : InvalidOperationDomainException
    {
        public InvalidUserEmailDomainException(string message) : base(message)
        {
        }
    }
}
