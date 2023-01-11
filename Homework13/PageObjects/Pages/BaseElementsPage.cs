using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.Pages
{
    public class BaseElementsPage
    {
        private string _categoryMenuItemLocator = "//div[@class='card-body' and .//text()='{0}']";
        private string _elementsMenuItemLocator = "//span[@class='text' and .//text()='{0}']";

        public void ClickOnCategoryMenuItem(string menuItem) => new DemoQaWebElement(By.XPath(string.Format(_categoryMenuItemLocator, menuItem))).Click();

        public void ClickOnElementsMenuItem(string menuItem) => new DemoQaWebElement(By.XPath(string.Format(_elementsMenuItemLocator, menuItem))).Click();
    }
}