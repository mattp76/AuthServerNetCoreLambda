using System;
using System.Security.Cryptography.X509Certificates;
using AuthServer.DI;
using AuthServer.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer
{

    //https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4
    //https://damienbod.com/2020/02/10/create-certificates-for-identityserver4-signing-using-net-core/
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            DependancyResolver.Init(services, Configuration, this.Environment);

            services.AddScooterIdentityServer();
            services.AddMvc();

            // Add S3 to the ASP.NET Core dependency injection framework.
            //services.AddAWSService<Amazon.S3.IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseHealthCheck("/hc");
            app.UseRouting();
           
            if (!env.IsDevelopment())
            {
                //ImportLdapCertificates();
            }

            app.UseIdentityServer();
        }

        private static void ImportLdapCertificates()
        {
            //Opens the Root certificates store.
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            var certificates = store.Certificates.Find(
                X509FindType.FindBySubjectName,
                "RootCA",
                false);

            if (certificates.Count > 0)
            {
                Console.WriteLine("Certificate RootCA already exists");
            }
            else
            {
                //Create certificates from certificate files.
                var rootCaCert = new X509Certificate2("./Certificates/RootCA.pfx");

                //Add certificates to the store.
                store.Add(rootCaCert);
            }

            //Close the store.
            store.Close();

            //Opens the CA certificates store.
            store = new X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            certificates = store.Certificates.Find(
                X509FindType.FindBySubjectName,
                "IssuingCA0",
                false);

            if (certificates.Count > 1)
            {
                Console.WriteLine("Certificates IssuingCA0* already exists");
            }
            else
            {
                //Create certificates from certificate files.
                var issuingCa01Cert = new X509Certificate2("./Certificates/IssuingCA01.pfx");
                var issuingCa02Cert = new X509Certificate2("./Certificates/IssuingCA02.pfx");

                //Create a collection and add two of the certificates.
                var collection = new X509Certificate2Collection
                {
                    issuingCa01Cert, issuingCa02Cert
                };

                //Add certificates to the store.
                store.AddRange(collection);
            }


            //Close the store.
            store.Close();
        }
    }
}
