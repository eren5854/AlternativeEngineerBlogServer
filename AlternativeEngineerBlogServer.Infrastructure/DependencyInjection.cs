using AlternativeEngineerBlogServer.Domain.Users;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace AlternativeEngineerBlogServer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.SignIn.RequireConfirmedEmail = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.Scan(action =>
        {
            action
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

        return services;
    }
}
