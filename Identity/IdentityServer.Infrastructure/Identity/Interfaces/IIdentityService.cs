
using IdentityServer.Infrastructure.Common.Model;

namespace IdentityServer.Infrastructure.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(Guid userId);
        Task<bool> IsInRoleAsync(Guid userId, string role);
        Task<bool> AuthorizeAsync(Guid userId, string policyName);
        Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);
        Task<(Result Result, Guid UserId)> CreateUserAsync(ApplicationUser user, string password);
        Task<Result> DeleteUserAsync(Guid userId);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<bool> RoleExistsAsync(string roleName);
        Task<Result> CreateRoleAsync(string roleName);
        Task<Result> AddToRoleAsync(ApplicationUser user, string roleName);
    }
}
