using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public class InternalServerResponseError : BaseResponseError
    {
        public InternalServerResponseError(string message, int statusCode) : base(message, statusCode)
        {
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Redirect(GetErrorRoute());
            await context.HttpContext.Response.CompleteAsync();
        }
    }
}
