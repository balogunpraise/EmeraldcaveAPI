using Emeraldcave.Domain.Entities;
using Emeraldcave.Infrastructure.Identity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Emeraldcave.Api.Extensions
{
    public static class IdentityServices
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service)
        {
            var builder = service.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppUserDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            service.AddAuthentication();
            return service;
        }
    }
}
