using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskHub.Core.Domain.Entities.Identity;
using TaskHub.Core.ServiceContracts;
using TaskHub.Core.Services;
using TaskHub.Infrastructure.Context;

namespace TaskHub.Web.StartupExtensions
{
    public static class ServicesConfigurationExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddScoped<IAssignmentAdderService, AssignmentAdderService>();
            services.AddScoped<IAssignmentGetterService, AssignmentGetterService>();
            services.AddScoped<IAssignmentUpdaterService, AssignmentUpdaterService>();
            services.AddScoped<IAssignmentDeleterService, AssignmentDeleterService>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<AppUser, AppRole, AppDbContext, Guid>>()
                .AddRoleStore<RoleStore<AppRole, AppDbContext, Guid>>();

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                options.AddPolicy("NotSignedIn", policy =>
                {
                    policy.RequireAssertion(context => !context.User.Identity.IsAuthenticated);
                });

                options.AddPolicy("SignedIn", policy =>
                {
                    policy.RequireAssertion(context => context.User.Identity.IsAuthenticated);
                });
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";
            });

            return services;
        }
    }
}
