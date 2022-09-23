namespace IdentityServer.API.Application.DTO_s.Requests
{
    public record class IdentityUserRequest(
        string? UserName,
        string Email,
        string Password,
        bool EmailConfirmed = true
    );
}
