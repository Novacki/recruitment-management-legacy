using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityServer.API.Settings.Filters.Exceptions
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;
        public ApplicationExceptionFilter(ILogger<ApplicationExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
          var exceptionProcess =  new ApplicationExceptionProcess(context)
                                        .EnableExceptionHandled()
                                        .SetExceptionResult();

            _logger.LogError($"{exceptionProcess.GetExceptionName()}: { exceptionProcess.GetErrorMessage()}");
        }
    }
}