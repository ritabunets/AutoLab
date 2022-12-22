using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class ButtonPage
    {
        private DemoQaWebElement _doubleClickButton = new(By.XPath("//button[@id='doubleClickBtn']"));
        private DemoQaWebElement _messageForDoubleClickAction = new(By.XPath("//p[@id='doubleClickMessage']"));
        private DemoQaWebElement _rightClickButton = new(By.XPath("//button[@id='rightClickBtn']"));
        private DemoQaWebElement _messageForRightClickAction = new(By.XPath("//p[@id='rightClickMessage']"));
        private DemoQaWebElement _dynamicClickButton = new(By.XPath("//button[text()='Click Me']"));
        private DemoQaWebElement _messageForDynamicClickAction = new(By.XPath("//p[@id='dynamicClickMessage']"));

        public string GetMessageTextForDoubleClick() => _messageForDoubleClickAction.Text;

        public string GetMessageTextForRightClick() => _messageForRightClickAction.Text;

        public string GetMessageTextForDynamicClick() => _messageForDynamicClickAction.Text;

        public string GetDoubleClickButtonText() => _doubleClickButton.Text;

        public string GetRightClickButtonText() => _rightClickButton.Text;

        public string GetDynamicButtonText() => _dynamicClickButton.Text;

        public void DoubleClickOnDoubleClickButton() => _doubleClickButton.DoubleClick();

        public void RightClickOnRightClickButton() => _rightClickButton.RightClick();

        public void ClickDynamicButton() => _dynamicClickButton.Click();
    }
}