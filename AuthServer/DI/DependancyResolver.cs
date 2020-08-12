using System;
using System.Threading.Tasks;
using AuthServer.Configuration;
using AuthServer.Service.Identity;
using AuthServer.Service.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.DI
{
    public static class DependancyResolver
    {
        private static readonly object LockObject = new object();

        private static IServiceProvider serviceProvider;

        private static bool initialised;

        public static void Init(IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            if (initialised)
            {
                return;
            }

            lock (LockObject)
            {
                if (initialised)
                {
                    return;
                }

                ConfigureDependency(services, configuration, environment);
                ConfigureTransformationAsync(services, configuration);
                initialised = true;
            }
        }

        public static T GetService<T>() where T : class
        {
            return serviceProvider.GetService<T>();
        }

        private static void ConfigureDependency(IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            services.AddScoped(p => configuration);
            services.AddScoped<ISigningCertificateBuilder, SigningCertificateBuilder>();
            services.AddScoped<IX509Certificate2Builder, X509Certificate2Builder>();
            services.AddScoped<IIdentityServiceBuilder, IdentityServiceBuilder>();
   
            serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureTransformationAsync(IServiceCollection services, IConfiguration configuration = null)
        {
            if (configuration != null)
            {
                //var ldapConfig = new LdapConfig();
                //var identityConfig = new IdentityConfig();
                var securityKeyConfig = new SecurityKeyConfig();

                //configuration.Bind("Ldap", ldapConfig);
                //configuration.Bind("IdentityConfig", identityConfig);
                configuration.Bind("SecurityKey", securityKeyConfig);

                //var transformer = new SecurityKeyTransformer();
                //await transformer.Transform(ldapConfig, securityKeyConfig);

                //services.AddScoped(i => ldapConfig);
                //services.AddScoped(i => identityConfig);
                services.AddScoped(i => securityKeyConfig);

                //services.AddScoped(i => new LdapConnectionManager(ldapConfig));
                serviceProvider = services.BuildServiceProvider();
            }
        }
    }
}
