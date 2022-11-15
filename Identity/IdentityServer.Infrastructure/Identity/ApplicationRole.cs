using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Identity;
public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole(string roleName) : base(roleName)
    {
    }

    public ApplicationRole()
    {

    }
}
