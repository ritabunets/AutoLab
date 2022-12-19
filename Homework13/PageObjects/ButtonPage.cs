using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class ButtonPage
    {
        private MyWebElement _doubleClickButton = new(By.XPath("//button[@id='doubleClickBtn']"));
        private MyWebElement _messageForDoubleClickAction = new(By.XPath("//p[@id='doubleClickMessage']"));
        private MyWebElement _rightClickButton = new(By.XPath("//button[@id='rightClickBtn']"));
        private MyWebElement _messageForRightClickAction = new(By.XPath("//p[@id='rightClickMessage']"));
        private MyWebElement _dynamicClickButton = new(By.XPath("//button[text()='Click Me']"));
        private MyWebElement _messageForDynamicClickAction = new(By.XPath("//p[@id='dynamicClickMessage']"));

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