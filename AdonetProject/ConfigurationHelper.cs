using Microsoft.Extensions.Configuration;

namespace AdonetProject
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration;
        public static string LocalAdonetDbConnectionString { get; set; }
        public static string LocalMasterDbConnectionString { get; set; }

        static ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            SetValues();
        }

        public static void SetValues()
        {
            LocalAdonetDbConnectionString = Configuration.GetConnectionString("LocalAdonetDb");
            LocalMasterDbConnectionString = Configuration.GetConnectionString("LocalMasterDb");
        }
    }
}