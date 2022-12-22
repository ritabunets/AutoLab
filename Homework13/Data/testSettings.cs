using Homework13.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Homework13.Data
{
    public static class TestSettings
    {
        public static Browsers Browser { get; set; }
        public static string HomePage { get; set; }
        public static string ElementsPageUrl { get; set; }
        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile(".\\Tests\\TestSettings.json").Build();

        static TestSettings()
        {
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            HomePage = TestConfiguration["Pages:HomePage"];
            ElementsPageUrl = TestConfiguration["Pages:ElementsPageUrl"];
        }
    }
}