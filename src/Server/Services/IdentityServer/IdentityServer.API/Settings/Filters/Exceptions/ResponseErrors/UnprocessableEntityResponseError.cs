namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public class UnprocessableEntityResponseError : BaseResponseError
    {
        public UnprocessableEntityResponseError(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
