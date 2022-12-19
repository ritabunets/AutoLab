using System.Collections.ObjectModel;
using System.Drawing;
using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using OpenQA.Selenium;

namespace Homework13.Common.WebElements
{
    public class MyWebElement : IWebElement
    {
        protected By By { get; set; }

        protected IWebElement WebElement => WebDriverFactory.Driver.GetWebElementWhenExists(By);

        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;

        public MyWebElement(By by)
        {
            By = by;
        }

        public IWebElement FindElement(By by) => WebElement.FindElement(by);

        public void Clear() => WebElement.Clear();

        public void Click()
        {
            try
            {
                WebElement.Click();
            }
            catch(ElementClickInterceptedException)
            {
                ScrollIntoView();
                WebElement.Click();
            }
        }

        public void RightClick()
        {
            WebDriverFactory.Actions.ContextClick(WebElement).Build().Perform();
        }

        public void DoubleClick()
        {
            WebDriverFactory.Actions.DoubleClick(WebElement).Build().Perform();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                return WebElement.FindElements(by);
            }
            catch (StaleElementReferenceException)
            {
                return WebElement.FindElements(by);
            }
        }

        public string GetAttribute(string attributeName) => WebElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => WebElement.GetCssValue(propertyName);

        public string GetDomAttribute(string attributeName) => WebElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => WebElement.GetDomProperty(propertyName);

        public void SendKeys(string text) => WebElement.SendKeys(text);

        public void Submit() => WebElement.Submit();

        public ISearchContext GetShadowRoot() => WebElement.GetShadowRoot();

        public void ScrollIntoView() => WebDriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView()", WebElement);
    }
}