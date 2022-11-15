using Microsoft.EntityFrameworkCore.Design;

namespace IdentityServer.Infrastructure.Persistence
{
    public class IdentityServerDbContextFactory : IDesignTimeDbContextFactory<IdentityServerDbContext>

    {
        public IdentityServerDbContext CreateDbContext(string[] args)
        {
            return new IdentityServerDbContext();
        }
    }
}
