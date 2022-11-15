using System.Security.Claims;
using System.Text;
using Duende.IdentityServer.Configuration;
using IdentityServer.Infrastructure.Identity;
using IdentityServer.Infrastructure.Identity.Interfaces;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddIdentityInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("IdentityConnection");

        services.AddDbContext<IdentityServerDbContext>(options =>
            options.UseSqlServer(connectionString,
                builder => builder.MigrationsAssembly(typeof(IdentityServerDbContext).Assembly.FullName)));

        services.AddScoped<IIdentityServerDbContext>(provider => provider.GetRequiredService<IdentityServerDbContext>());

        services
           .AddDefaultIdentity<ApplicationUser>()
           .AddRoles<ApplicationRole>()
           .AddEntityFrameworkStores<IdentityServerDbContext>()
           .AddDefaultTokenProviders();

        var builder = services.AddCustomIdentity(options  =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;

            // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
            options.EmitStaticAudienceClaim = true;
        });

        // not recommended for production - you need to store your key material somewhere secure
        //builder.AddDeveloperSigningCredential()
        //       .AddApiAuthorization<ApplicationUser, IdentityServerDbContext>();
        services.AddAuthentication();

        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        // Adding Jwt Bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            };
        });

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        services.Configure<IdentityOptions>(options =>
        {
            options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
        });

        return services;
    }

    public static IApplicationBuilder UseCustomIdentity(this IApplicationBuilder app, IdentityServerMiddlewareOptions options = null)
    {
        return app.UseIdentityServer(options);
    }

    public static IIdentityServerBuilder AddCustomIdentity(this IServiceCollection services, Action<IdentityServerOptions> options)
    {
        services.Configure(options);

        return services.AddIdentityServer();
    }
}
