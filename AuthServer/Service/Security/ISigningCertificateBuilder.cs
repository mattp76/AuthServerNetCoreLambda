using System.Security.Cryptography.X509Certificates;

namespace AuthServer.Service.Security
{
    public interface ISigningCertificateBuilder
    {
        X509Certificate2 Get();
    }
}