using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Configuration;
using AuthServer.DI;

namespace AuthServer.Service.Security
{
    public class SecurityKeyTransformer : ISecurityKeyTransformer
    {
        public async Task Transform(params object[] configs)
        {
            foreach (var config in configs)
            {
                switch (config)
                {
                    //case LdapConfig ldapConfig:
                    //    var ldapBuilder = DependencyResolver.GetService<ISecurityKeyBuilder<LdapConfig>>();
                    //    await ldapBuilder.BuildAsync(ldapConfig);
                    //    break;
                    //case SecurityKeyConfig securityConfig:
                    //    var securityBuilder = DependancyResolver.GetService<ISecurityKeyBuilder<SecurityKeyConfig>>();
                    //    await securityBuilder.BuildAsync(securityConfig);
                    //    await securityBuilder.BuildAsync(securityConfig, true);
                    //    break;
                }
            }
        }
    }
}
