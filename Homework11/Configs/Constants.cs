using Microsoft.Extensions.Configuration;

namespace Homework11.Configs
{
    public class Constants
    {
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("Configs\\TestConfig.json").Build();
        public static string HomePage => TestConfiguration["Pages:HomePage"];
        public static string CheckBoxesPage => TestConfiguration["Pages:CheckBoxesPage"];
        public static string RadioButtonsPage => TestConfiguration["Pages:RadioButtonsPage"];
        public static string WebTablesPage => TestConfiguration["Pages:WebTablesPage"];
        public static string ButtonsPage => TestConfiguration["Pages:ButtonsPage"];
        public static string LinksPage => TestConfiguration["Pages:LinksPage"];
        public static string FirstName => TestConfiguration["UserData:FirstName"];
        public static string LastName => TestConfiguration["UserData:LastName"];
        public static string Email => TestConfiguration["UserData:Email"];
        public static string Age => TestConfiguration["UserData:Age"];
        public static string Salary => TestConfiguration["UserData:Salary"];
        public static string Department => TestConfiguration["UserData:Department"];
    }
}