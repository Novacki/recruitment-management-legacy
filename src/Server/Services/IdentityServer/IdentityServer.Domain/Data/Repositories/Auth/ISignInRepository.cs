namespace IdentityServer.Domain.Data.Repositories.Auth
{
    public interface ISignInRepository
    {
        public Task<bool> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
