namespace IdentityServer.Domain.Exceptions.Domain
{
    public abstract class InvalidOperationDomainException : BaseException
    {
        public InvalidOperationDomainException(string message) : base(message)
        {
        }
    }
}
