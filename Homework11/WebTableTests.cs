using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text;
using Homework11.Configs;
using System.Collections.Generic;

namespace Homework11
{
    public class WebTableTests
    {

        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Constants.WebTablesPage);
        }

        // Test1: Check validation of form inputs.
        [Test]
        public void CheckValidation()
        {
            const string validatedFormClass = "was-validated";
            var addNewEntryButton = _driver.FindElement(By.XPath("//button[@id='addNewRecordButton']"));
            addNewEntryButton.Click();
            var submitButton = _driver.FindElement(By.XPath("//button[@id='submit']"));
            submitButton.Click();
            var formClass = _driver.FindElement(By.XPath("//form")).GetAttribute("class");
            Assert.AreEqual(validatedFormClass, formClass);
        }

        // Test2: Search an entry.
        [Test]
        public void SearchEntry()
        {
            var numberOfRowsWithSearchTerm = _driver.FindElements(By.XPath("//div[contains(text(),'"+Constants.LastNameForSearch+"')]/ancestor::div[@role='row']")).Count;
            var searchInput = _driver.FindElement(By.XPath("//input[@id='searchBox']"));
            FillInInput(searchInput, Constants.LastNameForSearch);
            var numberOfRowsWithSearchTermAfterSearch = _driver.FindElements(By.XPath("//div[contains(text(),'"+Constants.LastNameForSearch+"')]/ancestor::div[@role='row']")).Count;
            Assert.AreEqual(numberOfRowsWithSearchTerm, numberOfRowsWithSearchTermAfterSearch);
        }

        // Test3: Add new entry.
        [Test]
        public void AddNewEntry()
        {
            var addNewEntryButton = _driver.FindElement(By.XPath("//button[@id='addNewRecordButton']"));
            addNewEntryButton.Click();

            // Find form inputs.
            var fistNameInput = _driver.FindElement(By.XPath("//input[@id='firstName']"));
            var lastNameInput = _driver.FindElement(By.XPath("//input[@id='lastName']"));
            var emailInput = _driver.FindElement(By.XPath("//input[@id='userEmail']"));
            var ageInput = _driver.FindElement(By.XPath("//input[@id='age']"));
            var salaryInput = _driver.FindElement(By.XPath("//input[@id='salary']"));
            var departmentInput = _driver.FindElement(By.XPath("//input[@id='department']"));
            var submitButton = _driver.FindElement(By.XPath("//button[@id='submit']"));

            // Fill in form inputs.
            FillInInput(fistNameInput, Constants.FirstName);
            FillInInput(lastNameInput, Constants.LastName);
            FillInInput(emailInput, Constants.Email);
            FillInInput(ageInput, Constants.Age);
            FillInInput(salaryInput, Constants.Salary);
            FillInInput(departmentInput, Constants.Department);
            submitButton.Click();

            // Get text of new entry.
            ReadOnlyCollection<IWebElement> gridcell = _driver.FindElements(By.XPath("((//div[@role='row'])[5])/div"));
            Assert.AreEqual(ExpectedConstants.NewEntryValue, GetTextOfCollectionElements(gridcell));
        }

        // Test4: Edit first entry.
        [Test]
        public void EditFirstEntry()
        {
            var editButton = _driver.FindElement(By.XPath("//span[@title='Edit']"));
            editButton.Click();

            // Find form inputs.
            var fistNameInput = _driver.FindElement(By.XPath("//input[@id='firstName']"));
            var lastNameInput = _driver.FindElement(By.XPath("//input[@id='lastName']"));
            var emailInput = _driver.FindElement(By.XPath("//input[@id='userEmail']"));
            var ageInput = _driver.FindElement(By.XPath("//input[@id='age']"));
            var salaryInput = _driver.FindElement(By.XPath("//input[@id='salary']"));
            var departmentInput = _driver.FindElement(By.XPath("//input[@id='department']"));
            var submitButton = _driver.FindElement(By.XPath("//button[@id='submit']"));

            // Clear form inputs.
            DeleteValue(fistNameInput);
            DeleteValue(lastNameInput);
            DeleteValue(emailInput);
            DeleteValue(ageInput);
            DeleteValue(salaryInput);
            DeleteValue(departmentInput);

            // Fill in form inputs.
            FillInInput(fistNameInput, Constants.FirstName);
            FillInInput(lastNameInput, Constants.LastName);
            FillInInput(emailInput, Constants.Email);
            FillInInput(ageInput, Constants.Age);
            FillInInput(salaryInput, Constants.Salary);
            FillInInput(departmentInput, Constants.Department);
            submitButton.Click();

            // Get text of updated entry.
            ReadOnlyCollection<IWebElement> gridcell = _driver.FindElements(By.XPath("((//div[@role='row'])[2])/div"));
            Assert.AreEqual(ExpectedConstants.NewEntryValue, GetTextOfCollectionElements(gridcell));
        }

        // Test5: Delete first entry.
        [Test]
        public void DeleteFirstEntry()
        {
            var deleteButton = _driver.FindElement(By.XPath("//span[@title='Delete']"));
            deleteButton.Click();
            var expectedCell = _driver.FindElements(By.XPath("//div[contains(text(),'Vega')]"));
            Assert.AreEqual(0, expectedCell.Count);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        public void DeleteValue(IWebElement element)
        {
            element.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        public void FillInInput(IWebElement element, string value)
        {
            element.SendKeys(value);
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
