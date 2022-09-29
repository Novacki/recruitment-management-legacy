namespace IdentityServer.API.Application.ViewModels.Users
{
    public class UserViewModel : IViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
