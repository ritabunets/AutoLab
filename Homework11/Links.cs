using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Homework11.Configs;
using OpenQA.Selenium.Support.UI;

namespace Homework11
{
    public class Links
    {
        public class ButtonTests
        {
            private IWebDriver _driver;
            private WebDriverWait _driverWait;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Constants.LinksPage);
                _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            }

            // Test1: Check links that open new tab.
            [Test]
            public void VerifyLinksOpenNewTabs()
            {
                var homeLink = _driver.FindElement(By.XPath("//a[@id='simpleLink']"));
                homeLink.Click();
                Assert.AreEqual(Constants.HomePage, GetNewWindowUrl());

                SwitchToOriginalWindow();
                var homeDynamicLink = _driver.FindElement(By.XPath("//a[@id='dynamicLink']"));
                homeDynamicLink.Click();
                Assert.AreEqual(Constants.HomePage, GetNewWindowUrl());
            }

            // Test2: Check links that simulate work with API.
            [Test]
            public void VerifyLinksSendApiCall()
            {
                var createdLink = _driver.FindElement(By.XPath("//a[@id='created']"));
                createdLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageCreated));

                var noContentLink = _driver.FindElement(By.XPath("//a[@id='no-content']"));
                noContentLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageNoContent));

                var movedLink = _driver.FindElement(By.XPath("//a[@id='moved']"));
                movedLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageMoved));

                var badRequestLink = _driver.FindElement(By.XPath("//a[@id='bad-request']"));
                badRequestLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageBadRequest));

                var unauthorizedLink = _driver.FindElement(By.XPath("//a[@id='unauthorized']"));
                unauthorizedLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageUnauthorized));

                var forbiddenLink = _driver.FindElement(By.XPath("//a[@id='forbidden']"));
                forbiddenLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageForbidden));

                var notFoundLink = _driver.FindElement(By.XPath("//a[@id='invalid-url']"));
                notFoundLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.ExpectedMessageNotFound));
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _driver.Quit();
            }

            public void SwitchToOriginalWindow() => _driver.SwitchTo().Window(_driver.WindowHandles.First());

            public string GetNewWindowUrl() => _driver.SwitchTo().Window(_driver.WindowHandles.Last()).Url;

            public string GetResponseMessage()
            {
                var actualMessage = _driver.FindElement(By.XPath("//p[@id='linkResponse']")).Text;

                return actualMessage;
            }
        }
    }
}
