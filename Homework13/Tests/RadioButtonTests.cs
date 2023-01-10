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
            GenericPages.BaseElementsPage.ClickOnCategoryMenuItem(Categories.Elements);
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.RadioButton);
        }

        // Test1: Verify all radio buttons.
        [Test]
        public void VerifyAllRadioButtons()
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

            var availableRadioButtonsCount = GenericPages.RadioButtonPage.GetAvailableRadioButtonsCount();
            for (int i = 0; i < availableRadioButtonsCount; i++)
            {
                var expectedMessage = messageDefaultText + " " + GenericPages.RadioButtonPage.GetSelectedRadioButtonName(i);
                GenericPages.RadioButtonPage.ClickOnAvailableRadioButton(i);
                Assert.Multiple(() =>
                {
                    Assert.True(GenericPages.RadioButtonPage.IsRadioButtonSelected(i));
                    Assert.AreEqual(expectedMessage, GenericPages.RadioButtonPage.GetSelectedMessageText());
                    Assert.AreEqual(greenColor, GenericPages.RadioButtonPage.GetSelectedRadioButtonNameColor());
                });
            }
        }
    }
}