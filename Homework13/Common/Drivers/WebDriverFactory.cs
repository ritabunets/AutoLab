using System.Collections.Concurrent;
using Homework13.Data;
using Homework13.Data.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace Homework13.Common.Drivers
{
    public class WebDriverFactory
    {
        private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new ConcurrentDictionary<string, IWebDriver>();

        public static IWebDriver Driver
        {
            get
            {
                if (!DriverCollection.Keys.Contains(TestContextValues.ExecutableClassName))
                {
                    InitializeDriver();
                }

                return DriverCollection.First(pair => pair.Key == TestContextValues.ExecutableClassName).Value;
            }


            private set => DriverCollection.TryAdd(TestContextValues.ExecutableClassName, value);
        }

        public static Actions Actions => new Actions(Driver);

        public static IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor)Driver;

        public static void QuitDriver()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private static void InitializeDriver()
        {
            Driver = TestSettings.Browser switch
            {
                Data.Enums.Browsers.Chrome => new ChromeDriver(),
                Data.Enums.Browsers.Edge => new EdgeDriver(),
                Data.Enums.Browsers.Firefox => new FirefoxDriver(),
                _ => throw new NotSupportedException(),
            };

            Driver.Manage().Window.Maximize();
        }
    }
}