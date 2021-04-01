using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace AuthServer.Service.Security
{
    public class X509Certificate2Builder : IX509Certificate2Builder
    {
        public X509Certificate2 GetCertificate(string fileName, string password)
        {
            return new X509Certificate2(Path.Combine("./Certificates/", fileName), password);
        }
    }
}
