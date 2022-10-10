namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public class ConflictResponseError : BaseResponseError
    {
        public ConflictResponseError(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
