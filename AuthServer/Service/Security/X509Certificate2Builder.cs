using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

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
