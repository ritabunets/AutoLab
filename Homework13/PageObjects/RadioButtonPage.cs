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

        public string GetSelectedRadioButtonName(int index)
        {
                var availableRadioButton = _ridioButtonsArea.FindElements(By.XPath(".//label[not(contains(@class, ('disabled')))]"));
                string selectedRadioButtonName = availableRadioButton[index].Text;

                return selectedRadioButtonName;
        }

        public bool IsRadioButtonSelected(int index)
        {
            var availableRadioButton = _ridioButtonsArea.FindElements(By.XPath(".//input[not(contains(@class, ('disabled')))]"));
            bool isRadioButtonSelected = availableRadioButton[index].Selected;

            return isRadioButtonSelected;
        }

        public int GetAllRadioButtonsCount()
        {
            var allRadioButtons = _ridioButtonsArea.FindElements(By.XPath(".//child::input"));

            return allRadioButtons.Count;
        }

        public int GetAvailableRadioButtonsCount()
        {
            var availableRadioButtons = _ridioButtonsArea.FindElements(By.XPath(".//input[not(contains(@class, ('disabled')))]"));

            return availableRadioButtons.Count;
        }

        public bool IsNoRadioButtonDisabled() => _noRadioButton.IsElementDisabled();

        public void ClickOnAvailableRadioButton(int index)
        {
            var availableRadioButtonLabel = _ridioButtonsArea.FindElements(By.XPath(".//label[not(contains(@class, ('disabled')))]"));
            availableRadioButtonLabel[index].Click();
        }
    }
}