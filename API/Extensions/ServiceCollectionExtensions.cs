using API.Services.Users;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using FluentValidation.AspNetCore;
using Infrastructure.Common.Interfaces;

namespace API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<EFContext>();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddScoped<UserService>();

        return services;
    }
}