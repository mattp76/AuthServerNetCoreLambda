namespace AuthServer.Configuration
{
    public class SecurityKeyConfig
    {
        [SecureConfig(SecureKeys.Certificate)]
        public string CertificateBase64 { get; set; }

        [SecureConfig(SecureKeys.CertificateFile)]
        public string CertificateFile { get; set; }

        [SecureConfig(SecureKeys.CertificatePassword)]
        public string CertificatePassword { get; set; }

        public string DataProtectionKeyFile { get; set; }

        [SecureConfig(SecureKeys.DataProtectionKey)]
        public string DataProtectionKey { get; set; }

        public string ApplicationName { get; set; }

        [SecureConfig(SecureKeys.AuthDBPassword, true)]
        public string SitecoreDbConnectionString { get; set; }
    }
}
