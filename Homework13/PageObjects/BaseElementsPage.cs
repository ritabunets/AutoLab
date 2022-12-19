using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class BaseElementsPage
    {
        private string _elementsMenuItemLocator = "//span[@class='text' and .//text()='{0}']";
        private MyWebElement _elementsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Elements')]"));
        private MyWebElement _formsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Forms')]"));
        private MyWebElement _alersFrameWindowsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Alerts, Frame & Windows')]"));
        private MyWebElement _widgetsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Widgets')]"));
        private MyWebElement _interactionsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Interactions')]"));
        private MyWebElement _bookStoreApplicationMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Book Store Application')]"));

        public void ClickOnElementsMenuItem(string menuItem) => new MyWebElement(By.XPath(string.Format(_elementsMenuItemLocator, menuItem))).Click();
    }
}