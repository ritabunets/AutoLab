using Homework13.Data.Constants;
using Homework13.PageObjects.Pages;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class ButtonTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnCategoryMenuItem(Categories.Elements);
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.Buttons);
        }

        // Test1: Check Double click button.
        [Test]
        public void VerifyDoubleClickButton()
        {
            const string expectedDoubleClickButtonName = "Double Click Me";
            const string expectedMessageForDoubleClick = "You have done a double click";

            GenericPages.ButtonPage.DoubleClickOnDoubleClickButton();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDoubleClickButtonName, GenericPages.ButtonPage.GetDoubleClickButtonText());
                Assert.AreEqual(expectedMessageForDoubleClick, GenericPages.ButtonPage.GetMessageTextForDoubleClick());
            });
        }

        // Test2: Check Right click button.
        [Test]
        public void VerifyRightClickButton()
        {
            const string expectedDoubleClickButtonName = "Right Click Me";
            const string expectedMessageForRightClick = "You have done a right click";

            GenericPages.ButtonPage.RightClickOnRightClickButton();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDoubleClickButtonName, GenericPages.ButtonPage.GetRightClickButtonText());
                Assert.AreEqual(expectedMessageForRightClick, GenericPages.ButtonPage.GetMessageTextForRightClick());
            });
        }

        // Test3: Check Dynamic click button.
        [Test]
        public void VerifyDynamicClickButton()
        {
            const string expectedDynamicButtonName = "Click Me";
            const string expectedMessageForDynamicClick = "You have done a dynamic click";

            GenericPages.ButtonPage.ClickDynamicButton();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDynamicButtonName, GenericPages.ButtonPage.GetDynamicButtonText());
                Assert.AreEqual(expectedMessageForDynamicClick, GenericPages.ButtonPage.GetMessageTextForDynamicClick());
            });
        }
    }
}