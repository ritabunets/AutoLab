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

            [SetUp]
            public void SetUp()
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Constants.linksPage);
                _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            }

            //Test1: Check links that open new tab.
            [Test]
            public void VerifyLinksOpenNewTabs()
            {
                var homeLink = _driver.FindElement(By.XPath("//a[@id='simpleLink']"));
                homeLink.Click();
                Assert.AreEqual(Constants.homePage, GetNewWindowUrl());

                SwitchToOriginalWindow();
                var homeDynamicLink = _driver.FindElement(By.XPath("//a[@id='dynamicLink']"));
                homeDynamicLink.Click();
                Assert.AreEqual(Constants.homePage, GetNewWindowUrl());
            }

            //Test2: Check links that simulate work with API.
            [Test]
            public void VerifyLinksSendApiCall()
            {
                var createdLink = _driver.FindElement(By.XPath("//a[@id='created']"));
                createdLink.Click();
                Assert.AreEqual(ExpectedConstants.expectedMessageCreated, GetResponseMessage());

                var noContentLink = _driver.FindElement(By.XPath("//a[@id='no-content']"));
                noContentLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.expectedMessageNoContent));
                Assert.AreEqual(ExpectedConstants.expectedMessageNoContent, GetResponseMessage());

                var movedLink = _driver.FindElement(By.XPath("//a[@id='moved']"));
                movedLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.expectedMessageMoved));
                Assert.AreEqual(ExpectedConstants.expectedMessageMoved, GetResponseMessage());

                var badRequestLink = _driver.FindElement(By.XPath("//a[@id='bad-request']"));
                badRequestLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.expectedMessageBadRequest));
                Assert.AreEqual(ExpectedConstants.expectedMessageBadRequest, GetResponseMessage());

                var unauthorizedLink = _driver.FindElement(By.XPath("//a[@id='unauthorized']"));
                unauthorizedLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.expectedMessageUnauthorized));
                Assert.AreEqual(ExpectedConstants.expectedMessageUnauthorized, GetResponseMessage());

                var forbiddenLink = _driver.FindElement(By.XPath("//a[@id='forbidden']"));
                forbiddenLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.expectedMessageForbidden));
                Assert.AreEqual(ExpectedConstants.expectedMessageForbidden, GetResponseMessage());

                var notFoundLink = _driver.FindElement(By.XPath("//a[@id='invalid-url']"));
                notFoundLink.Click();
                _driverWait.Until(_driver => GetResponseMessage().Equals(ExpectedConstants.expectedMessageNotFound));
                Assert.AreEqual(ExpectedConstants.expectedMessageNotFound, GetResponseMessage());
            }

            [TearDown]
            public void TearDown()
            {
                _driver.Quit();
            }

            public void SwitchToOriginalWindow() => _driver.SwitchTo().Window(_driver.WindowHandles.First());

            public string GetNewWindowUrl() => _driver.SwitchTo().Window(_driver.WindowHandles.Last()).Url;

            public string GetResponseMessage()
            {
                _driverWait.Until(_driver => _driver.FindElements(By.XPath("//p[@id='linkResponse']/b")).Count == 2);
                var statusCode = _driver.FindElement(By.XPath("(//p[@id='linkResponse']/b)[1]")).Text;
                var status = _driver.FindElement(By.XPath("(//p[@id='linkResponse']/b)[2]")).Text;
                return $"Link has responded with staus {statusCode} and status text {status}";
            }
        }
    }
}
