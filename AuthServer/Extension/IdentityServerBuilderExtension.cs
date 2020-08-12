using AuthServer.Service.Identity;
using AuthServer.DI;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Extension
{
    public static class IdentityServerBuilderExtension
    {
        public static void AddScooterIdentityServer(this IServiceCollection services)
        {
            var IdentityServiceBuilder = DependancyResolver.GetService<IIdentityServiceBuilder>();
            IdentityServiceBuilder.AddIdentityServer(services);
        }
    }
}
