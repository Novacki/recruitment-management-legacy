namespace IdentityServer.Domain.DTO_s.User
{
    public class UserResultDTO
    {
        public bool Succeeded { get; set; }
        public IEnumerable<UserResultErrorDTO> Errors { get; set; }
    }
}
