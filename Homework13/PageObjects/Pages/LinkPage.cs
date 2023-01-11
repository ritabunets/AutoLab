using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.Pages
{
    public class LinkPage
    {
        private DemoQaWebElement _homeLink = new(By.XPath("//a[@id='simpleLink']"));
        private DemoQaWebElement _homeDynamicLink = new(By.XPath("//a[@id='dynamicLink']"));
        private DemoQaWebElement _createdLink = new(By.XPath("//a[@id='created']"));
        private DemoQaWebElement _noContentLink = new(By.XPath("//a[@id='no-content']"));
        private DemoQaWebElement _movedLink = new(By.XPath("//a[@id='moved']"));
        private DemoQaWebElement _badRequestLink = new(By.XPath("//a[@id='bad-request']"));
        private DemoQaWebElement _unauthorizedLink = new(By.XPath("//a[@id='unauthorized']"));
        private DemoQaWebElement _forbiddenLink = new(By.XPath("//a[@id='forbidden']"));
        private DemoQaWebElement _notFoundLink = new(By.XPath("//a[@id='invalid-url']"));
        private DemoQaWebElement _actualMessage = new(By.XPath("//p[@id='linkResponse']"));

        public void ClickHomeLink() => _homeLink.Click();

        public void ClickHomeDynamicLink() => _homeDynamicLink.Click();

        public void ClickCreatedLink() => _createdLink.Click();

        public void ClickNoContentLink() => _noContentLink.Click();

        public void ClickMovedLink() => _movedLink.Click();

        public void ClickBadRequestLink() => _badRequestLink.Click();

        public void ClickUnauthorizedLink() => _unauthorizedLink.Click();

        public void ClickForbiddenLink() => _forbiddenLink.Click();

        public void ClickNotFoundLink() => _notFoundLink.Click();

        public void ConfirmMessageIsDisplayed(string message)
        {
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => _actualMessage.Text.Equals(message));
        }
    }
}