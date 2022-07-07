namespace IdentityServer.API.Application.DTO_s.Requests
{
    public record class IdentityUserRequest(
        string userName,
        string email,
        bool emailConfirmed = true
    );
}
