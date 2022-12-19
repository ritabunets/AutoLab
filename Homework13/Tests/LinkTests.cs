using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Data.Constants;
using Homework13.PageObjects;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class LinkTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
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

            // Postcondition: return to original state.
            WebDriverFactory.Driver.SwitchToOriginalWindow();
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
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageCreated));

            GenericPages.LinkPage.ClickNoContentLink();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageNoContent));

            GenericPages.LinkPage.ClickMovedLink();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageMoved));

            GenericPages.LinkPage.ClickBadRequestLink();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageBadRequest));

            GenericPages.LinkPage.ClickUnauthorizedLink();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageUnauthorized));

            GenericPages.LinkPage.ClickForbiddenLink();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageForbidden));

            GenericPages.LinkPage.ClickNotFoundLink();
            WebDriverFactory.Driver.GetWebDriverWait().Until(d => GenericPages.LinkPage.GetResponseMessageText().Equals(expectedMessageNotFound));
        }
    }
}