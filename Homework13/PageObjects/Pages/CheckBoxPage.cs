using System.Collections.ObjectModel;
using System.Text;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.Pages
{
    public class CheckBoxPage
    {
        private DemoQaWebElement _toogle = new(By.XPath("//button[@title='Toggle']"));
        private DemoQaWebElement _homeCheckbox = new(By.XPath("//*[@id='tree-node-home']"));
        private DemoQaWebElement _homeItem = new(By.XPath("//span[@class='rct-checkbox']"));
        private DemoQaWebElement _desktopCheckbox = new(By.XPath("//*[@id='tree-node-desktop']"));
        private DemoQaWebElement _desktopItem = new(By.XPath("//label[@for='tree-node-desktop']/span"));
        private DemoQaWebElement _selectedCheckBoxName = new(By.XPath("//span[@class='text-success']"));
        private DemoQaWebElement _expandAllButton = new(By.XPath("//button[@title='Expand all']"));
        private DemoQaWebElement _collapseAllButton = new(By.XPath("//button[@title='Collapse all']"));

        public void ClickToogle() => _toogle.Click();

        public void ClickExpandAllButton() => _expandAllButton.Click();

        public void ClickCollapseAllButton() => _collapseAllButton.Click();

        public void ClickHomeItem() => _homeItem.Click();

        public void ClickDesktopItem() => _desktopItem.Click();

        public string GetSelectedCheckBoxNameColor() => _selectedCheckBoxName.GetColor();

        public string GetTextOfResultMessage()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < GetSelectedItems().Count; i++)
            {
                IWebElement element = GetSelectedItems()[i];
                string text = element.Text;
                stringBuilder.Append($"{text} ");
            }

            var finalString = stringBuilder.ToString();

            return finalString;
        }

        public int GetNumberOfSelectedMenuItems()
        {
            var menuItems = _homeItem.FindElements(By.XPath("//span[@class='text-success']")).Count;

            return menuItems;
        }

        public int GetNumberOfShownNameMenuItems()
        {
            var menuItems = _homeItem.FindElements(By.XPath("//span[@class='rct-text']")).Count;

            return menuItems;
        }

        public bool IsHomeCheckboxSelected() => _homeCheckbox.Selected;

        public bool IsDesktopCheckboxSelected() => _desktopCheckbox.Selected;

        private ReadOnlyCollection<IWebElement> GetSelectedItems()
        {
            var selectedItems = _homeItem.FindElements(By.XPath("//div[@id='result']/span"));

            return selectedItems;
        }
    }
}