using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AuthServer.Service.Security
{
    public interface IX509Certificate2Builder
    {
        X509Certificate2 GetCertificate(string fileName, string password);
    }
}
