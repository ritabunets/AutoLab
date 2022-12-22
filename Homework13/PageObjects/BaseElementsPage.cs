using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class BaseElementsPage
    {
        private string _elementsMenuItemLocator = "//span[@class='text' and .//text()='{0}']";
        private DemoQaWebElement _formsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Forms')]"));
        private DemoQaWebElement _alertsFrameWindowsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Alerts, Frame & Windows')]"));
        private DemoQaWebElement _widgetsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Widgets')]"));
        private DemoQaWebElement _interactionsMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Interactions')]"));
        private DemoQaWebElement _bookStoreApplicationMenuItem = new(By.XPath("//div[@class='header-text' and contains(text(), 'Book Store Application')]"));

        public void ClickOnElementsMenuItem(string menuItem) => new DemoQaWebElement(By.XPath(string.Format(_elementsMenuItemLocator, menuItem))).Click();
    }
}