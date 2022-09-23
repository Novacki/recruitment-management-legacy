namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public class NotFoundResponseError : BaseResponseError
    {
        public NotFoundResponseError(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
