using System.Collections.ObjectModel;
using System.Text;
using Homework11.Configs;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        }

        [SetUp]
        public void SetUp()
        {
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
            // Get the first name from the first row.
            var firstName1 = _driver.FindElement(By.XPath("((//div[@role='rowgroup'])[1]//descendant::div[@role='gridcell'])[1]")).Text;

            // Get the rows before the search operation.
            ReadOnlyCollection<IWebElement> rows = _driver.FindElements(By.XPath("//div[@role='rowgroup']"));

            // Get the rows from the collection above that contains the first name from the first entry.
            var filteredRowsWithSearchedValue = GetListOfFilteredRows(GetListOfNotEmptyRows(rows), firstName1);

            // Search.
            var searchInput = _driver.FindElement(By.XPath("//input[@id='searchBox']"));
            FillInInput(searchInput, firstName1);

            // Get the rows after the search operation.
            ReadOnlyCollection<IWebElement> resultRows = _driver.FindElements(By.XPath("//div[@role='rowgroup']"));

            // Get the rows from the result collection.
            var resultRowsWithSearchedValue = GetListOfNotEmptyRows(resultRows);

            // Get the rows from the result collection that contains the first name from the first entry.
            var filteredResultRowsWithSearchedValue = GetListOfFilteredRows(GetListOfNotEmptyRows(resultRows), firstName1);

            // Check that: 1) Each result row contains the first name from the first entry. 2) Number of rows with the first name before the search is the same as after the search.
            Assert.Multiple(() =>
            {
                Assert.AreEqual(filteredResultRowsWithSearchedValue.Count, resultRowsWithSearchedValue.Count);
                Assert.AreEqual(filteredRowsWithSearchedValue.Count, resultRowsWithSearchedValue.Count);
            });
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
            // Get the first name from the first row.
            var firstName1 = _driver.FindElement(By.XPath("((//div[@role='rowgroup'])[1]//descendant::div[@role='gridcell'])[1]")).Text;

            // Remove the first row.
            var deleteButton = _driver.FindElement(By.XPath("//span[@id='delete-record-1']"));
            deleteButton.Click();

            // Get the rows left after the delete operation.
            ReadOnlyCollection<IWebElement> rows = _driver.FindElements(By.XPath("//div[@role='rowgroup']"));

            // Get the rows from the collection above that contains the first name from removed entry.
            var rowsWithRemovedValue = GetListOfFilteredRows(GetListOfNotEmptyRows(rows), firstName1);
            Assert.AreEqual(0, rowsWithRemovedValue.Count);
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

        private string GetTextOfCollectionElements(ReadOnlyCollection<IWebElement> selectedItems)
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

        private List<string> GetListOfNotEmptyRows(ReadOnlyCollection<IWebElement> selectedRows)
        {
            List<string> rowsText = new List<string>();
            for (int i = 0; i < selectedRows.Count; i++)
            {
                var stringBuilder = new StringBuilder();
                {
                    IWebElement element = selectedRows[i];
                    string text = element.Text;
                    stringBuilder.Append($"{text} ");
                }
                var finalString = stringBuilder.ToString();
                if (finalString != "        ")
                {
                    rowsText.Add(finalString);
                }
            }

            return rowsText;
        }

        private List<string> GetListOfFilteredRows(List<string> listOfRows, string filterValue)
        {
            List<string> filteredListOfRows = new List<string>();
            for (int i = 0; i < listOfRows.Count; i++)
            {
                if (listOfRows[i].Contains(filterValue))
                {
                    filteredListOfRows.Add(listOfRows[i]);
                }
            }

            return filteredListOfRows;
        }
    }
}
