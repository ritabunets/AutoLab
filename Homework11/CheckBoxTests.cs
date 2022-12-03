using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Text;
using Homework11.Configs;

namespace Homework11
{
    public class CheckBoxTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Constants.checkBoxesPage);
        }

        //Test1: Verify that Home is not selected if Desktop selected and check the full message.
        [Test]
        public void SelectFirstLevelChildCheckBox()
        {
            var toogle = _driver.FindElement(By.XPath("//button[@title='Toggle']"));
            toogle.Click();
            var desktopItem = _driver.FindElement(By.XPath("//label[@for='tree-node-desktop']/span"));
            desktopItem.Click();
            var homeCheckBox = _driver.FindElement(By.XPath("//*[@id='tree-node-home']"));
            var desktopCheckBox = _driver.FindElement(By.XPath("//*[@id='tree-node-desktop']"));
            ReadOnlyCollection<IWebElement> selectedItems = _driver.FindElements(By.XPath("//div[@id='result']/span"));
            var selectedCheckBoxNameColor = _driver.FindElement(By.XPath("//span[@class='text-success']")).GetCssValue("color");
            Assert.Multiple(() =>
            {
                Assert.IsFalse(homeCheckBox.Selected);
                Assert.IsTrue(desktopCheckBox.Selected);
                Assert.AreEqual(ExpectedConstants.greenColor, selectedCheckBoxNameColor);
                Assert.AreEqual(ExpectedConstants.messageDesktopIsSelected, GetTextOfCollectionElements(selectedItems));
            });
        }

        //Test2: Verify that all items are selected if Home selected and check items in the message.
        [Test]
        public void SelectAllCheckBoxes()
        {
            var homeItem = _driver.FindElement(By.XPath("//span[@class='rct-checkbox']"));
            homeItem.Click();
            ReadOnlyCollection<IWebElement> selectedItems = _driver.FindElements(By.XPath("//span[@class='text-success']"));
            Assert.Multiple(() =>
            {
                Assert.AreEqual(17, selectedItems.Count);
                Assert.AreEqual(ExpectedConstants.messagePartWithAllSelectedItems, GetTextOfCollectionElements(selectedItems));
            });
        }

        //Test3: Expand all checkboxes
        [Test]
        public void ExpandAllCheckBoxes()
        {
            var expandAllButton = _driver.FindElement(By.XPath("//button[@title='Expand all']"));
            expandAllButton.Click();
            var menuItems = _driver.FindElements(By.XPath("//span[@class='rct-text']"));
            Assert.AreEqual(17, menuItems.Count);
        }

        //Test4: Collapse all checkboxes
        [Test]
        public void CollapseAllCheckBoxes()
        {
            var expandAllButton = _driver.FindElement(By.XPath("//button[@title='Expand all']"));
            expandAllButton.Click();
            var collapseAllButton = _driver.FindElement(By.XPath("//button[@title='Collapse all']"));
            collapseAllButton.Click();
            var menuItems = _driver.FindElements(By.XPath("//span[@class='rct-text']"));
            Assert.AreEqual(1, menuItems.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        public string GetTextOfCollectionElements(ReadOnlyCollection<IWebElement> selectedItems)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < selectedItems.Count; i++)
            {
                IWebElement element = selectedItems[i];
                string text = element.Text;
                stringBuilder.Append($"{text} ");
            }
            var finalString = stringBuilder.ToString();
            return finalString;
        }
    }
}
