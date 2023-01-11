using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Helpers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Homework13.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.HomePage);
        }

        [TearDown]
        public void TearDown()
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