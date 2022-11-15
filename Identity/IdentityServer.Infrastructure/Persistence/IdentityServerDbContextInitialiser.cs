using IdentityServer.Infrastructure.Common.Static;
using IdentityServer.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Persistence
{
    public class IdentityServerDbContextInitialiser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public IdentityServerDbContextInitialiser(
            UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default roles
            var administratorRole = new ApplicationRole
            {
                Name = UserRolesConst.Admin
            };

            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
            }

            // Default users
            var administrator = new ApplicationUser
            {
                UserName = "administrator@localhost",
                Email = "administrator@localhost",
                FirstName = "admin",
                LastName = "admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "Admin@123");
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }
    }
}
