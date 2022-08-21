namespace IdentityServer.Domain.Helpers.Extensions.Commons
{
    public static class ObjectsValidatorExtension
    {
        public static bool Exist<T>(this T value) where T : class => value != null;
        public static bool NotExist<T>(this T value) where T : class => value == null;
    }
}
