﻿using Homework11.Configs;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework11
{
    public class RadioButtonTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Constants.RadioButtonsPage);
        }

        // Test1: Verify all radio buttons.
        [Test]
        public void VerifyAllRadioBattons()
        {
            var radioButton = _driver.FindElements(By.XPath("//input[@type='radio']"));
            var disabledRadioButton = _driver.FindElements(By.XPath("//input[contains(@class, ('disabled'))]"));
            Assert.Multiple(() =>
            {
                Assert.AreEqual(3, radioButton.Count);
                Assert.AreEqual(1, disabledRadioButton.Count);
            });
        }

        // Test2: Select each not disabled radio button and verify message.
        [Test]
        public void SelectEnabledRadioButton()
        {
            var availableRadioButtonLabel = _driver.FindElements(By.XPath("//label[not(contains(@class, ('disabled')))]"));
            var availableRadioButton = _driver.FindElements(By.XPath("//input[not(contains(@class, ('disabled')))]"));
            for (int i = 0; i < availableRadioButtonLabel.Count; i++)
            {
                availableRadioButtonLabel[i].Click();
                var selectedRadioButtonName = availableRadioButtonLabel[i].Text;
                var selectedRadioButtonNameColor = _driver.FindElement(By.XPath("//span[@class='text-success']")).GetCssValue("color");
                var selectedMessage = _driver.FindElement(By.XPath("//p[@class='mt-3']")).Text;
                var expectedMessage = ExpectedConstants.MessageDefaultText + " " + selectedRadioButtonName;
                Assert.Multiple(() =>
                {
                    Assert.True(availableRadioButton[i].Selected);
                    Assert.AreEqual(expectedMessage, selectedMessage);
                    Assert.AreEqual(ExpectedConstants.GreenColor, selectedRadioButtonNameColor);
                });
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
    }
}
