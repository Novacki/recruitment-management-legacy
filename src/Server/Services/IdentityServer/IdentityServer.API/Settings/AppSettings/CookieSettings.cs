namespace IdentityServer.API.Settings
{
    public class CookieSettings
    {
        public string LoginPath { get; set; }
        public string LogoutPath { get; set; }
        public string AccessDeniedPath { get; set; }
        public string CookieName { get; set; }
        public string ReturnUrlParameter { get; set; }
        public double ExpireTimeSpanMinutes { get; set; }
        public bool HttpOnly { get; set; }
        public bool SlidingExpiration { get; set; }
    }
}
