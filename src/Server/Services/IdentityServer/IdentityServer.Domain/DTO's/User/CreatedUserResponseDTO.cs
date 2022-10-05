namespace IdentityServer.Domain.DTO_s.User
{
    public class CreatedUserResponseDTO
    {
        public bool Succeeded { get; set; }
        public IEnumerable<UserErrorResponseDTO> Errors { get; set; }
    }
}
