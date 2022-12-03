using Microsoft.Extensions.Configuration;

namespace Homework11.Configs
{
    public class Constants
    {
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("C:\\Users\\Marharyta.Bunets\\source\\repos\\AutoLab\\Homework11\\Configs\\TestConfig.json").Build();
        public static string homePage => TestConfiguration["Pages:homePage"];
        public static string checkBoxesPage => TestConfiguration["Pages:checkBoxesPage"];
        public static string radioButtonsPage => TestConfiguration["Pages:radioButtonsPage"];
        public static string webTablesPage => TestConfiguration["Pages:webTablesPage"];
        public static string buttonsPage => TestConfiguration["Pages:buttonsPage"];
        public static string linksPage => TestConfiguration["Pages:linksPage"];
        public static string firstName => TestConfiguration["UserData:firstName"];
        public static string lastName => TestConfiguration["UserData:lastName"];
        public static string email => TestConfiguration["UserData:email"];
        public static string age => TestConfiguration["UserData:age"];
        public static string salary => TestConfiguration["UserData:salary"];
        public static string department => TestConfiguration["UserData:department"];
        public static string lastNameForSearch => TestConfiguration["SearchData:lastNameForSearch"];
    }
}