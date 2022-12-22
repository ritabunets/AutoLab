using System;
using System.Text;
using Homework13.Common.WebElements;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace Homework13.PageObjects
{
    public class WebTablePage
    {
        private DemoQaWebElement _addNewEntryButton = new(By.XPath("//button[@id='addNewRecordButton']"));
        private DemoQaWebElement _submitButton = new(By.XPath("//button[@id='submit']"));
        private DemoQaWebElement _form = new(By.XPath("//form"));
        private DemoQaWebElement _firstName1 = new(By.XPath("((//div[@role='rowgroup'])[1]//descendant::div[@role='gridcell'])[1]"));
        private DemoQaWebElement _tableRows = new(By.XPath("//div[@class='rt-tbody']"));
        private DemoQaWebElement _searchTextBox = new(By.XPath("//input[@id='searchBox']"));
        private DemoQaWebElement _firstNameTextBox = new(By.XPath("//input[@id='firstName']"));
        private DemoQaWebElement _lastNameTextBox = new(By.XPath("//input[@id='lastName']"));
        private DemoQaWebElement _emailTextBox = new(By.XPath("//input[@id='userEmail']"));
        private DemoQaWebElement _ageTextBox = new(By.XPath("//input[@id='age']"));
        private DemoQaWebElement _salaryTextBox = new(By.XPath("//input[@id='salary']"));
        private DemoQaWebElement _departmentTextBox = new(By.XPath("//input[@id='department']"));
        private DemoQaWebElement _deleteButton = new(By.XPath("//span[@id='delete-record-1']"));
        private DemoQaWebElement _closeButton = new(By.XPath("//span[contains(text(),'×')]"));

        public bool IsFormValidated() => _form.GetClass().Contains("was-validated");

        public void ClickAddNewEntryButton() => _addNewEntryButton.Click();

        public void ClickCloseButton() => _closeButton.Click();

        public void ClickSubmitButton() => _submitButton.Click();

        public void ClickEditEntryButton(string firstName) => _editButton(firstName).Click();

        public void ClickDeleteEntryButton() => _deleteButton.Click();

        public string GetFirstName1Value() => _firstName1.Text;

        public List<string> GetListOfNotEmptyRows()
        {
            var rows = _tableRows.FindElements(By.XPath("//div[@role='rowgroup']"));
            List<string> rowsText = new List<string>();
            for (int i = 0; i < rows.Count; i++)
            {
                var stringBuilder = new StringBuilder();
                {
                    IWebElement element = rows[i];
                    string text = element.Text;
                    stringBuilder.Append($"{text}");
                }

                var finalString = stringBuilder.ToString().Trim();
                bool isNull = string.IsNullOrEmpty(finalString);
                if (!isNull)
                {
                    rowsText.Add(finalString);
                }

            }

            return rowsText;
        }

        public int GetCountOfRowsWithValue(string filterValue) => GetListOfNotEmptyRows().Count(x => x.Contains(filterValue));

        public int GetCountOfRows(List<string> rows) => rows.Count;

        public string GetTextOfElement(int index)
        {
            string text = GetRow(index).Text;
            var actualString = text.Replace("\r\n", " ");

            return actualString;
        }

        public void FillInSearchTextBox(string value) => _searchTextBox.SendKeys(value);

        public void FillInFirstNameTextBox(string value) => _firstNameTextBox.SendKeys(value);

        public void FillInLastNameTextBox(string value) => _lastNameTextBox.SendKeys(value);

        public void FillInEmailTextBox(string value) => _emailTextBox.SendKeys(value);

        public void FillInAgeTextBox(string value) => _ageTextBox.SendKeys(value);

        public void FillInSalaryTextBox(string value) => _salaryTextBox.SendKeys(value);

        public void FillInDepartmentTextBox(string value) => _departmentTextBox.SendKeys(value);

        public void ClearFirstNameTextBox() => _firstNameTextBox.ClearTextBox();

        public void ClearLastNameTextBox() => _lastNameTextBox.ClearTextBox();

        public void ClearEmailTextBox() => _emailTextBox.ClearTextBox();

        public void ClearAgeTextBox() => _ageTextBox.ClearTextBox();

        public void ClearSalaryTextBox() => _salaryTextBox.ClearTextBox();

        public void ClearDepartmentTextBox() => _departmentTextBox.ClearTextBox();

        private DemoQaWebElement GetRow(int index) => new DemoQaWebElement(By.XPath($"(//div[@role='row'])[{index}]"));

        private DemoQaWebElement _editButton(string firstName) => new DemoQaWebElement(By.XPath($"(//div[contains(text(),'{firstName}')]/ancestor::div[@role='row']//div[@role='gridcell']//span)[1]"));
    }
}