using Homework13.Data.Constants;
using Homework13.PageObjects;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class RadioButtonTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.RadioButton);
        }

        // Test1: Verify all radio buttons.
        [Test]
        public void VerifyAllRadioBattons()
        {
            var allRadioButtonsCount = GenericPages.RadioButtonPage.GetAllRadioButtonsCount();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(3, allRadioButtonsCount);
                Assert.IsTrue(GenericPages.RadioButtonPage.IsNoRadioButtonDisabled());
            });
        }

        // Test2: Select each not disabled radio button and verify message.
        [Test]
        public void SelectEnabledRadioButton()
        {
            const string greenColor = "rgba(40, 167, 69, 1)";
            const string messageDefaultText = "You have selected";

            var availableRadioButtonsCount = GenericPages.RadioButtonPage.GetAvailableRadioButtons().Count;
            for (int i = 0; i < availableRadioButtonsCount; i++)
            {
                var currentRadioButtonLabel = GenericPages.RadioButtonPage.GetAvailableRadioButtonLables()[i];
                var currentRadioButton = GenericPages.RadioButtonPage.GetAvailableRadioButtons()[i];
                GenericPages.RadioButtonPage.ClickOnRadioButton(currentRadioButtonLabel);
                var expectedMessage = messageDefaultText + " " + currentRadioButtonLabel.Text;
                Assert.Multiple(() =>
                {
                    Assert.True(currentRadioButton.Selected);
                    Assert.AreEqual(expectedMessage, GenericPages.RadioButtonPage.GetSelectedMessageText());
                    Assert.AreEqual(greenColor, GenericPages.RadioButtonPage.GetSelectedRadioButtonNameColor());
                });
            }
        }
    }
}