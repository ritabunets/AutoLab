using System.Collections.ObjectModel;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class RadioButtonPage
    {
        private DemoQaWebElement _ridioButtonsArea = new(By.XPath("//div[@class='col-12 mt-4 col-md-6']"));
        private DemoQaWebElement _noRadioButton = new(By.XPath("//input[@id='noRadio']"));
        private DemoQaWebElement _selectedRadioButtonName = new(By.XPath("//span[@class='text-success']"));
        private DemoQaWebElement _selectedMessage = new(By.XPath("//p[@class='mt-3']"));

        public string GetSelectedRadioButtonNameColor() => _selectedRadioButtonName.GetColor();

        public string GetSelectedMessageText() => _selectedMessage.Text;

        public int GetAllRadioButtonsCount()
        {
            var allRadioButtons = _ridioButtonsArea.FindElements(By.XPath(".//child::input"));

            return allRadioButtons.Count;
        }

        public ReadOnlyCollection<IWebElement> GetAvailableRadioButtonLables()
        {
            var availableRadioButtonLabels = _ridioButtonsArea.FindElements(By.XPath(".//label[not(contains(@class, ('disabled')))]"));

            return availableRadioButtonLabels;
        }

        public ReadOnlyCollection<IWebElement> GetAvailableRadioButtons()
        {
            var availableRadioButtons = _ridioButtonsArea.FindElements(By.XPath(".//input[not(contains(@class, ('disabled')))]"));

            return availableRadioButtons;
        }

        public bool IsNoRadioButtonDisabled() => _noRadioButton.IsElementDisabled();

        public void ClickOnRadioButton(IWebElement element) => element.Click();
    }
}