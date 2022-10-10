namespace IdentityServer.API.Application.ViewModels.Errors
{
    public class ErrorViewModel : IViewModel
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }

        public ErrorViewModel SetError(string error)
        {
            Error = error;
            return this;
        }
    }
}