using Homework13.Common.Drivers;
using Homework13.Data.Constants;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Homework13.Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.ElementsPageUrl);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                Screenshot screenshot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot();
                var screenshotDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Screenshots";
                if (!Directory.Exists(screenshotDirectory))
                {
                    Directory.CreateDirectory(screenshotDirectory);
                }
                string filePath = $"{screenshotDirectory}\\{ DateTime.Now.ToString("yyyyMMdd_HHmm_")}_" + $"{TestContext.CurrentContext.Test.Name}.png";
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(filePath);
            }
            WebDriverFactory.QuitDriver();
        }
    }
}