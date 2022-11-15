namespace IdentityServer.Infrastructure.Persistence;

public interface IIdentityServerDbContext
{
    Task InitialiseAsync();
}