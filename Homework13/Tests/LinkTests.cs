using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.Pages;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class LinkTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnCategoryMenuItem(Categories.Elements);
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.Links);
        }

        // Test1: Check links that open new tab.
        [Test]
        public void VerifyLinksOpenNewTabs()
        {
            GenericPages.LinkPage.ClickHomeLink();
            Assert.AreEqual(TestSettings.HomePage, WebDriverFactory.Driver.GetNewWindowUrl());

            WebDriverFactory.Driver.SwitchToOriginalWindow();
            GenericPages.LinkPage.ClickHomeDynamicLink();
            Assert.AreEqual(TestSettings.HomePage, WebDriverFactory.Driver.GetNewWindowUrl());
        }

        // Test2: Check links that simulate work with API.
        [Test]
        public void VerifyLinksSendApiCall()
        {
            const string expectedMessageCreated = "Link has responded with staus 201 and status text Created";
            const string expectedMessageNoContent = "Link has responded with staus 204 and status text No Content";
            const string expectedMessageMoved = "Link has responded with staus 301 and status text Moved Permanently";
            const string expectedMessageBadRequest = "Link has responded with staus 400 and status text Bad Request";
            const string expectedMessageUnauthorized = "Link has responded with staus 401 and status text Unauthorized";
            const string expectedMessageForbidden = "Link has responded with staus 403 and status text Forbidden";
            const string expectedMessageNotFound = "Link has responded with staus 404 and status text Not Found";

            GenericPages.LinkPage.ClickCreatedLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageCreated);

            GenericPages.LinkPage.ClickNoContentLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageNoContent);

            GenericPages.LinkPage.ClickMovedLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageMoved);

            GenericPages.LinkPage.ClickBadRequestLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageBadRequest);

            GenericPages.LinkPage.ClickUnauthorizedLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageUnauthorized);

            GenericPages.LinkPage.ClickForbiddenLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageForbidden);

            GenericPages.LinkPage.ClickNotFoundLink();
            GenericPages.LinkPage.ConfirmMessageIsDisplayed(expectedMessageNotFound);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverFactory.Driver.CloseAllWindowsExceptFirst();
        }
    }
}