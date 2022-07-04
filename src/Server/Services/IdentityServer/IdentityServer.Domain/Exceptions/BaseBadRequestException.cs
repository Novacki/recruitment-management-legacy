namespace IdentityServer.Domain.Exceptions
{
    public abstract class BaseBadRequestException : Exception
    {
        public BaseBadRequestException() {}
        protected BaseBadRequestException(string message) : base(message) { }
    }
}
