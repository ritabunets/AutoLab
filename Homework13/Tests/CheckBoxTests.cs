using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Data.Constants;
using Homework13.PageObjects;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class CheckBoxTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnCategoryMenuItem(Categories.Elements);
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.CheckBox);
        }

        // Test1: Verify that Home is not selected if Desktop selected and check the full message.
        [Test]
        public void SelectFirstLevelChildCheckBox()
        {
            const string greenColor = "rgba(40, 167, 69, 1)";
            const string messageDesktopIsSelected = "You have selected : desktop notes commands ";

            GenericPages.CheckBoxPage.ClickToogle();
            GenericPages.CheckBoxPage.ClickDesktopItem();
            var homeCheckboxSelected = GenericPages.CheckBoxPage.IsHomeCheckboxSelected();
            var desktopCheckboxSelected = GenericPages.CheckBoxPage.IsDesktopCheckboxSelected();
            Assert.Multiple(() =>
            {
                Assert.IsFalse(homeCheckboxSelected);
                Assert.IsTrue(desktopCheckboxSelected);
                Assert.AreEqual(greenColor, GenericPages.CheckBoxPage.GetSelectedCheckBoxNameColor());
                Assert.AreEqual(messageDesktopIsSelected, GenericPages.CheckBoxPage.GetTextOfResultMessage());
            });
        }

        // Test2: Verify that all items are selected if Home selected and check items in the message.
        [Test]
        public void SelectAllCheckBoxes()
        {
            const string messagePartWithAllSelectedItems = "You have selected : home desktop notes commands documents workspace " +
                "react angular veu office public private classified general downloads wordFile excelFile ";

            GenericPages.CheckBoxPage.ClickHomeItem();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(17, GenericPages.CheckBoxPage.GetNumberOfSelectedMenuItems());
                Assert.AreEqual(messagePartWithAllSelectedItems, GenericPages.CheckBoxPage.GetTextOfResultMessage());
            });

            // Postcondition: return to original state.
            GenericPages.CheckBoxPage.ClickHomeItem();
        }

        // Test3: Expand all checkboxes.
        [Test]
        public void ExpandAndCollapseAllCheckBoxes()
        {
            GenericPages.CheckBoxPage.ClickExpandAllButton();
            Assert.AreEqual(17, GenericPages.CheckBoxPage.GetNumberOfShownNameMenuItems());
            GenericPages.CheckBoxPage.ClickCollapseAllButton();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.CheckBoxPage.GetNumberOfShownNameMenuItems().Equals(1));
        }
    }
}