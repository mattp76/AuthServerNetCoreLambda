using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Service.Identity
{
    public interface IIdentityServiceBuilder
    {
        void AddIdentityServer(IServiceCollection services);
    }
}