using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework13.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static WebDriverWait GetWebDriverWait(this IWebDriver driver, int timeoutSeconds = 30, TimeSpan? pollingInterval = null, params Type[] exceptionTypes)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            if (pollingInterval != null)
            {
                webDriverWait.PollingInterval = (TimeSpan)pollingInterval;
            }

            webDriverWait.IgnoreExceptionTypes(exceptionTypes);

            return webDriverWait;
        }

        public static IWebElement GetWebElementWhenExists(this IWebDriver driver, By by) => driver.GetWebDriverWait().Until(drv => drv.FindElement(by));

        public static void SwitchToOriginalWindow(this IWebDriver driver) => driver.SwitchTo().Window(driver.WindowHandles.First());

        public static string GetNewWindowUrl(this IWebDriver driver) => driver.SwitchTo().Window(driver.WindowHandles.Last()).Url;

        public static void CloseAllWindowsExceptFirst(this IWebDriver driver)
        {
            var windows = driver.WindowHandles;
            if (windows.Count > 1)
            {
                var indexOfLastWindow = windows.Count - 1;
                while (indexOfLastWindow != 0)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[indexOfLastWindow]);
                    driver.Close();
                    indexOfLastWindow -= 1;
                }

                SwitchToOriginalWindow(driver);
            }
        }
    }
}