using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AuthServer.Configuration;

namespace AuthServer.Service.Security
{
    public class SigningCertificateBuilder : ISigningCertificateBuilder
    {
        private readonly SecurityKeyConfig config;

        private readonly IX509Certificate2Builder x509Certificate2Builder;

        public SigningCertificateBuilder(SecurityKeyConfig config, IX509Certificate2Builder x509Certificate2Builder)
        {
            this.config = config;
            this.x509Certificate2Builder = x509Certificate2Builder;
        }


        public X509Certificate2 Get()
        {
            if (string.IsNullOrWhiteSpace(this.config.CertificateFile))
            {
                throw new ArgumentException("Certificate doesn't exist");
            }

            //var certBytes = Convert.FromBase64String(this.config.CertificateBase64);
            var certificate = this.x509Certificate2Builder.GetCertificate(this.config.CertificateFile, this.config.CertificatePassword);

            return certificate;
        }
    }
}
