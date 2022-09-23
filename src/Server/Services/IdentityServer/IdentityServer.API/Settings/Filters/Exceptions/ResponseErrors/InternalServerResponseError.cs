namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public class InternalServerResponseError : BaseResponseError
    {
        public InternalServerResponseError(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
