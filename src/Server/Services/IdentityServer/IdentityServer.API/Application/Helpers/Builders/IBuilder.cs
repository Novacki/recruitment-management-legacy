namespace IdentityServer.API.Application.Helpers.Builders
{
    public interface IBuilder<T> where T : class
    {
        T Build();
    }
}
