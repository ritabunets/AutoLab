using Homework11.Configs;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Homework11
{
    public class ButtonTests
    {
        private IWebDriver _driver;
        private Actions _driverActions;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driverActions = new Actions(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Constants.ButtonsPage);
        }

        // Test1: Check Double click button.
        [Test]
        public void VerifyDoubleClickBatton()
        {
            var doubleClickButton = _driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            _driverActions.DoubleClick(doubleClickButton).Perform();
            var messageForDoubleClickAction = _driver.FindElement(By.XPath("//p[@id='doubleClickMessage']")).Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExpectedConstants.ExpectedDoubleClickButtonName, doubleClickButton.Text);
                Assert.AreEqual(ExpectedConstants.ExpectedMessageForDoubleClick, messageForDoubleClickAction);
            });
        }

        // Test2: Check Right click button.
        [Test]
        public void VerifyRightClickBatton()
        {
            var rightClickButton = _driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            _driverActions.ContextClick(rightClickButton).Perform();
            var actualMessageForRightClick = _driver.FindElement(By.XPath("//p[@id='rightClickMessage']")).Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExpectedConstants.ExpectedRightClickButtonName, rightClickButton.Text);
                Assert.AreEqual(ExpectedConstants.ExpectedMessageForRightClick, actualMessageForRightClick);
            });
        }

        // Test3: Check Dynamic click button.
        [Test]
        public void VerifyDynamicClickBatton()
        {
            var dynamicClickButton = _driver.FindElement(By.XPath("//button[text()='Click Me']"));
            dynamicClickButton.Click();
            var actualMessageForDynamicClick = _driver.FindElement(By.XPath("//p[@id='dynamicClickMessage']")).Text;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExpectedConstants.ExpectedDynamicClickButtonName, dynamicClickButton.Text);
                Assert.AreEqual(ExpectedConstants.ExpectedMessageForDynamicClick, actualMessageForDynamicClick);
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
    }
}
