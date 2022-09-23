using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public abstract class BaseResponseError : ViewResult
    {
        public string Message { get; private set; }

        protected BaseResponseError(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {

            context.ModelState.AddModelError("ErrorMessage", Message);
            context.HttpContext.Items.Add("ErrorMessage", Message);
            context.HttpContext.Response.Redirect($"{context.HttpContext.Request.Path}?message='a'");
            //context.HttpContext.Response.Redirect($"{context.HttpContext.Request.Path}?message={Message}");
            //await context.HttpContext.Response.WriteAsJsonAsync(Message);
        }
    }
}