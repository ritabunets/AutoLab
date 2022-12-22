using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Helpers;
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
                var filePath = ScreenshotHelper.TakeScreenshot(WebDriverFactory.Driver);
                TestContext.AddTestAttachment(filePath);
            }

            WebDriverFactory.QuitDriver();
        }
    }
}