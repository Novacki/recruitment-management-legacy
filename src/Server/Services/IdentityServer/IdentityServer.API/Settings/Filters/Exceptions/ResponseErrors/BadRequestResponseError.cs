using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public class BadRequestResponseError : BaseResponseError
    {
        public BadRequestResponseError(string message, int statusCode) : base(message, statusCode)
        {
        }

        //public override Task ExecuteResultAsync(ActionContext context)
        //{
        //}
    }
}
