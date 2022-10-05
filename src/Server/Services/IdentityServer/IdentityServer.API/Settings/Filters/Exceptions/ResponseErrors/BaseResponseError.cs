using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors
{
    public abstract class BaseResponseError : ViewResult
    {
        public string Message { get; protected set; }

        protected BaseResponseError(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            SetViewData(context)
                .SetErrorMessage();

            await base.ExecuteResultAsync(context);
        }

        protected BaseResponseError SetViewName(ActionContext context)
        {
            const string ACTION = "action";
            ViewName = context.RouteData.Values.GetValueOrDefault(ACTION)?.ToString();

            return this;
        }

        protected BaseResponseError SetViewEngine(ActionContext context)
        {
            var compositeViewEngine = context.HttpContext.RequestServices.GetRequiredService<ICompositeViewEngine>();
            ViewEngine = compositeViewEngine;

            return this;
        }

        protected BaseResponseError SetViewData(ActionContext context)
        {
            var metadataProvider = context.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();
            ViewData = new ViewDataDictionary(metadataProvider, new ModelStateDictionary());
            
            return this;
        }

        protected BaseResponseError SetTempData(ActionContext context)
        {
            var tempDataProvider = context.HttpContext.RequestServices.GetRequiredService<ITempDataProvider>();
            TempData = new TempDataDictionary(context.HttpContext, tempDataProvider);

            return this;
        }

        protected BaseResponseError SetErrorMessage()
        {
            const string ERROR_MESSAGE = "ErrorMessage";
            ViewData[ERROR_MESSAGE] = Message;
            
            return this;
        }

        protected BaseResponseError SetStatusCode(int statusCode)
        {
            StatusCode = statusCode;
            return this;
        }
    }
}