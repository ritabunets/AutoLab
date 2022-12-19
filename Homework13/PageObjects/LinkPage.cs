using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class LinkPage
    {
        private MyWebElement _homeLink = new(By.XPath("//a[@id='simpleLink']"));
        private MyWebElement _homeDynamicLink = new(By.XPath("//a[@id='dynamicLink']"));
        private MyWebElement _createdLink = new(By.XPath("//a[@id='created']"));
        private MyWebElement _noContentLink = new(By.XPath("//a[@id='no-content']"));
        private MyWebElement _movedLink = new(By.XPath("//a[@id='moved']"));
        private MyWebElement _badRequestLink = new(By.XPath("//a[@id='bad-request']"));
        private MyWebElement _unauthorizedLink = new(By.XPath("//a[@id='unauthorized']"));
        private MyWebElement _forbiddenLink = new(By.XPath("//a[@id='forbidden']"));
        private MyWebElement _notFoundLink = new(By.XPath("//a[@id='invalid-url']"));
        private MyWebElement _actualMessage = new(By.XPath("//p[@id='linkResponse']"));

        public void ClickHomeLink() => _homeLink.Click();

        public void ClickHomeDynamicLink() => _homeDynamicLink.Click();

        public void ClickCreatedLink() => _createdLink.Click();

        public void ClickNoContentLink() => _noContentLink.Click();

        public void ClickMovedLink() => _movedLink.Click();

        public void ClickBadRequestLink() => _badRequestLink.Click();

        public void ClickUnauthorizedLink() => _unauthorizedLink.Click();

        public void ClickForbiddenLink() => _forbiddenLink.Click();

        public void ClickNotFoundLink() => _notFoundLink.Click();

        public string GetResponseMessageText() => _actualMessage.Text;
    }
}