using IdentityServer.Domain.Constants.ErrorMessages;
using IdentityServer.Domain.Exceptions.Domain.Users;

namespace IdentityServer.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public User(string userName)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            ConcurrencyStamp = Guid.NewGuid();
        }
    
        public string UserName { get; private set; }
        public string NormalizedUserName { get; private set; }
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string PasswordHash { get; private set; }
        public string SecurityStamp { get; private set; }
        public Guid ConcurrencyStamp { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool PhoneNumberConfirmed { get; private set; }
        public bool TwoFactorEnabled { get; private set; }
        public DateTimeOffset? LockoutEnd { get; private set; }
        public bool LockoutEnabled { get; private set; }
        public int AccessFailedCount { get; private set; }

        public void Update(string userName, string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(userName))
                throw new InvalidUserNameDomainException(UserErrorMessages.InvalidUserName);

            if(string.IsNullOrEmpty(email))
                throw new InvalidUserEmailDomainException(UserErrorMessages.InvalidUserEmail);

            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
