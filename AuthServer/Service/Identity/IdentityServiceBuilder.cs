using AuthServer.Service.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Service.Identity
{
    public class IdentityServiceBuilder : IIdentityServiceBuilder
    {
        private readonly ISigningCertificateBuilder signingCertificateBuilder;
        public IdentityServiceBuilder(ISigningCertificateBuilder signingCertificateBuilder)
        {
            this.signingCertificateBuilder = signingCertificateBuilder;
        }

        public void AddIdentityServer(IServiceCollection services)
        {
            services.AddIdentityServer(op =>
                {
                    op.Authentication.CookieSlidingExpiration = true;
                })
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddInMemoryApiScopes(Resources.GetApiScopes())
                .AddTestUsers(Users.Get())
                .AddSigningCredential(this.signingCertificateBuilder.Get());
        }
    }
}
