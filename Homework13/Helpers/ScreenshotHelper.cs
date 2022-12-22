using Homework13.Common.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework13.Helpers
{
    public class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot();
            var screenshotDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Screenshots";
            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            string filePath = $"{screenshotDirectory}\\{DateTime.Now.ToString("yyyyMMdd_HHmm_")}_" + $"{TestContext.CurrentContext.Test.Name}.png";
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return filePath;
        }
    }
}
