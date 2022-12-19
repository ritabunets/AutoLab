using System.Collections.ObjectModel;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class RadioButtonPage
    {
        private MyWebElement _radioButton = new(By.XPath("//input[@type='radio']"));
        private MyWebElement _selectedRadioButtonName = new(By.XPath("//span[@class='text-success']"));
        private MyWebElement _selectedMessage = new(By.XPath("//p[@class='mt-3']"));

        public string GetSelectedRadioButtonNameColor() => _selectedRadioButtonName.GetCssValue("color");

        public string GetSelectedMessageText() => _selectedMessage.Text;

        public int GetAllRadioButtonsCount()
        {
            var allRadioButtons = _radioButton.FindElements(By.XPath("//input[@type='radio']"));

            return allRadioButtons.Count;
        }

        public ReadOnlyCollection<IWebElement> GetAvailableRadioButtonLables()
        {
            var availableRadioButtonLabels = _radioButton.FindElements(By.XPath("//label[not(contains(@class, ('disabled')))]"));

            return availableRadioButtonLabels;
        }

        public ReadOnlyCollection<IWebElement> GetAvailableRadioButtons()
        {
            var availableRadioButtons = _radioButton.FindElements(By.XPath("//input[not(contains(@class, ('disabled')))]"));

            return availableRadioButtons;
        }

        public int GetDisabledRadioButtonsCount()
        {
            var disabledRadioButtons = _radioButton.FindElements(By.XPath("//input[contains(@class, ('disabled'))]"));

            return disabledRadioButtons.Count;
        }
    }
}