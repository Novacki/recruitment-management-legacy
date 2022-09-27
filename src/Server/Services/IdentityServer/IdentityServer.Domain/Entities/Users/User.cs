﻿namespace IdentityServer.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public User(string userName)
        {
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
    }
}
