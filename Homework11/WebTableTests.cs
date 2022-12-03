using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text;
using Homework11.Configs;

namespace Homework11
{
    public class WebTableTests
    {

        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Constants.webTablesPage);
        }

        [Test]
        public void CheckValidation()
        {
            var addNewEntryButton = _driver.FindElement(By.XPath("//button[@id='addNewRecordButton']"));
            addNewEntryButton.Click();
            var submitButton = _driver.FindElement(By.XPath("//button[@id='submit']"));
            submitButton.Click();
            string validatedFormClass = "was-validated";
            var formClass = _driver.FindElement(By.XPath("//form")).GetAttribute("class");
            Assert.AreEqual(validatedFormClass, formClass);
        }

        [Test]
        public void SearchEntry()
        {
            var searchInput = _driver.FindElement(By.XPath("//input[@id='searchBox']"));
            FillInInput(searchInput, Constants.lastNameForSearch);
            var expectedCell = _driver.FindElements(By.XPath("//div[contains(text(),'Vega')]"));
            Assert.AreEqual(1, expectedCell.Count);
        }

        [Test]
        public void AddNewEntry()
        {
            var addNewEntryButton = _driver.FindElement(By.XPath("//button[@id='addNewRecordButton']"));
            addNewEntryButton.Click();
            //find form inputs
            var fistNameInput = _driver.FindElement(By.XPath("//input[@id='firstName']"));
            var lastNameInput = _driver.FindElement(By.XPath("//input[@id='lastName']"));
            var emailInput = _driver.FindElement(By.XPath("//input[@id='userEmail']"));
            var ageInput = _driver.FindElement(By.XPath("//input[@id='age']"));
            var salaryInput = _driver.FindElement(By.XPath("//input[@id='salary']"));
            var departmentInput = _driver.FindElement(By.XPath("//input[@id='department']"));
            var submitButton = _driver.FindElement(By.XPath("//button[@id='submit']"));
            //fill in form inputs
            FillInInput(fistNameInput, Constants.firstName);
            FillInInput(lastNameInput, Constants.lastName);
            FillInInput(emailInput, Constants.email);
            FillInInput(ageInput, Constants.age);
            FillInInput(salaryInput, Constants.salary);
            FillInInput(departmentInput, Constants.department);
            submitButton.Click();
            //get text of new entry
            ReadOnlyCollection<IWebElement> gridcell = _driver.FindElements(By.XPath("((//div[@role='row'])[5])/div"));
            Assert.AreEqual(ExpectedConstants.newEntryValue, GetTextOfCollectionElements(gridcell));
        }

        [Test]
        public void EditFirstEntry()
        {
            var editButton = _driver.FindElement(By.XPath("//span[@title='Edit']"));
            editButton.Click();
            //find form inputs
            var fistNameInput = _driver.FindElement(By.XPath("//input[@id='firstName']"));
            var lastNameInput = _driver.FindElement(By.XPath("//input[@id='lastName']"));
            var emailInput = _driver.FindElement(By.XPath("//input[@id='userEmail']"));
            var ageInput = _driver.FindElement(By.XPath("//input[@id='age']"));
            var salaryInput = _driver.FindElement(By.XPath("//input[@id='salary']"));
            var departmentInput = _driver.FindElement(By.XPath("//input[@id='department']"));
            var submitButton = _driver.FindElement(By.XPath("//button[@id='submit']"));
            //clear form inputs
            DeleteValue(fistNameInput);
            DeleteValue(lastNameInput);
            DeleteValue(emailInput);
            DeleteValue(ageInput);
            DeleteValue(salaryInput);
            DeleteValue(departmentInput);
            //fill in form inputs
            FillInInput(fistNameInput, Constants.firstName);
            FillInInput(lastNameInput, Constants.lastName);
            FillInInput(emailInput, Constants.email);
            FillInInput(ageInput, Constants.age);
            FillInInput(salaryInput, Constants.salary);
            FillInInput(departmentInput, Constants.department);
            submitButton.Click();
            //get text of updated entry
            ReadOnlyCollection<IWebElement> gridcell = _driver.FindElements(By.XPath("((//div[@role='row'])[2])/div"));
            Assert.AreEqual(ExpectedConstants.newEntryValue, GetTextOfCollectionElements(gridcell));
        }

        [Test]
        public void DeleteFirstEntry()
        {
            var deleteButton = _driver.FindElement(By.XPath("//span[@title='Delete']"));
            deleteButton.Click();
            var expectedCell = _driver.FindElements(By.XPath("//div[contains(text(),'Vega')]"));
            Assert.AreEqual(0, expectedCell.Count);
        }

        [TearDown]
        public void TearDown()
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
