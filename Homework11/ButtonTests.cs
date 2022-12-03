using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Homework11.Configs;

namespace Homework11
{
    public class ButtonTests
    {
        private IWebDriver _driver;
        private Actions _driverActions;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Constants.buttonsPage);
            _driverActions = new Actions(_driver);
        }

        //Test1:Check Double click button.
        [Test]
        public void VerifyDoubleClickBatton()
        {
            var doubleClickButton = _driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            _driverActions.DoubleClick(doubleClickButton).Perform();
            var messageForDoubleClickAction = _driver.FindElement(By.XPath("//p[@id='doubleClickMessage']")).Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExpectedConstants.expectedDoubleClickButtonName, GetText(doubleClickButton));
                Assert.AreEqual(ExpectedConstants.expectedMessageForDoubleClick, messageForDoubleClickAction);
            });
        }

        //Test2:Check Right click button.
        [Test]
        public void VerifyRightClickBatton()
        {
            var rightClickButton = _driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            _driverActions.ContextClick(rightClickButton).Perform();
            var actualMessageForRightClick = _driver.FindElement(By.XPath("//p[@id='rightClickMessage']")).Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExpectedConstants.expectedRightClickButtonName, GetText(rightClickButton));
                Assert.AreEqual(ExpectedConstants.expectedMessageForRightClick, actualMessageForRightClick);
            });
        }

        //Test3:Check Dynamic click button.
        [Test]
        public void VerifyDynamicClickBatton()
        {
            var dynamicClickButton = _driver.FindElement(By.XPath("//button[text()='Click Me']"));
            dynamicClickButton.Click();
            var actualMessageForDynamicClick = _driver.FindElement(By.XPath("//p[@id='dynamicClickMessage']")).Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExpectedConstants.expectedDynamicClickButtonName, GetText(dynamicClickButton));
                Assert.AreEqual(ExpectedConstants.expectedMessageForDynamicClick, actualMessageForDynamicClick);
            });
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        public string GetText(IWebElement element) => element.Text;
    }
}
