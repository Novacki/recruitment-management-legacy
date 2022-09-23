using IdentityServer.API.Settings.Filters.Exceptions.ResponseErrors;
using IdentityServer.Domain.Exceptions;
using IdentityServer.Domain.Exceptions.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityServer.API.Settings.Filters.Exceptions
{
    public class ApplicationExceptionProcess
    {
        private readonly ExceptionContext _context;

        public ApplicationExceptionProcess(ExceptionContext context)
        {
            _context = context;
        }

        private Dictionary<Type, BaseResponseError> ExceptionResults => new()
        {
            { typeof(NotFoundServiceException),  new NotFoundResponseError(GetErrorMessage(), StatusCodes.Status404NotFound) },
            { typeof(InvalidOperationServiceException),  new NotFoundResponseError(GetErrorMessage(), StatusCodes.Status400BadRequest) },
        };

        private BaseResponseError DefaultExceptionResult => new InternalServerResponseError(GetErrorMessage(), StatusCodes.Status500InternalServerError);

        public string GetErrorMessage() => $"Error: {_context.Exception.Message} {_context.Exception.StackTrace}";
        public string GetExceptionName() => nameof(_context.Exception);

        public ApplicationExceptionProcess EnableExceptionHandled()
        {
            _context.ExceptionHandled = true;
            return this;

        }

        public ApplicationExceptionProcess SetExceptionResult()
        {
            _context.Result = GetExceptionResult();
            return this;
        }

        private BaseResponseError GetExceptionResult()
        {
            if (ExceptionResults.ContainsKey(_context.Exception.GetType().BaseType))
                return ExceptionResults.GetValueOrDefault(_context.Exception.GetType().BaseType);

            return DefaultExceptionResult;
        }
    }
}
