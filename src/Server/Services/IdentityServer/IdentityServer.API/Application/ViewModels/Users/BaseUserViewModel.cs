namespace IdentityServer.API.Application.ViewModels.Users
{
    public class BaseUserViewModel : IViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
