using System.Reflection;
using Duende.IdentityServer.EntityFramework.Options;
using IdentityServer.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IdentityServer.Infrastructure.Persistence
{
    public class IdentityServerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IIdentityServerDbContext
    {
        public IdentityServerDbContext() : base(CreateOptions(""))
        {
        }

        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options ?? CreateOptions(""))
        {
        }

        private static DbContextOptions<IdentityServerDbContext> CreateOptions(string connName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerDbContext>();
            if (string.IsNullOrWhiteSpace(connName))
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().Build();
                connName = "Server=(local);Database=IdentityDB;User Id=sa;Password=123456A@;Trusted_Connection=True;";
            }

            optionsBuilder.UseSqlServer(connName);

            return optionsBuilder.Options;
        }

        public IdentityServerDbContext(string connName) : base(CreateOptions(connName))
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (this.Database.IsSqlServer())
                {
                    await this.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
