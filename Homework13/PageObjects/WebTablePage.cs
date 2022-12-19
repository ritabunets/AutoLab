using System.Collections.ObjectModel;
using System.Text;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class WebTablePage
    {
        private MyWebElement _addNewEntryButton = new(By.XPath("//button[@id='addNewRecordButton']"));
        private MyWebElement _submitButton = new(By.XPath("//button[@id='submit']"));
        private MyWebElement _form = new(By.XPath("//form"));
        private MyWebElement _firstName1 = new(By.XPath("((//div[@role='rowgroup'])[1]//descendant::div[@role='gridcell'])[1]"));
        private MyWebElement _row = new(By.XPath("//div[@role='rowgroup']"));
        private MyWebElement _searchInput = new(By.XPath("//input[@id='searchBox']"));
        private MyWebElement _firstNameInput = new(By.XPath("//input[@id='firstName']"));
        private MyWebElement _lastNameInput = new(By.XPath("//input[@id='lastName']"));
        private MyWebElement _emailInput = new(By.XPath("//input[@id='userEmail']"));
        private MyWebElement _ageInput = new(By.XPath("//input[@id='age']"));
        private MyWebElement _salaryInput = new(By.XPath("//input[@id='salary']"));
        private MyWebElement _departmentInput = new(By.XPath("//input[@id='department']"));
        private MyWebElement _editButton = new(By.XPath("//span[@title='Edit']"));
        private MyWebElement _deleteButton = new(By.XPath("//span[@id='delete-record-1']"));
        private MyWebElement _closeButton = new(By.XPath("//span[contains(text(),'×')]"));

        public void ClickAddNewEntryButton() => _addNewEntryButton.Click();

        public void ClickCloseButton() => _closeButton.Click();

        public void ClickSubmitButton() => _submitButton.Click();

        public void ClickEditEntryButton() => _editButton.Click();

        public void ClickDeleteEntryButton() => _deleteButton.Click();

        public string GetFormClass() => _form.GetAttribute("class");

        public string GetFirstName1Value() => _firstName1.Text;

        public ReadOnlyCollection<IWebElement> GetRows()
        {
            var rows = _row.FindElements(By.XPath("//div[@role='rowgroup']"));

            return rows;
        }

        public List<string> GetListOfNotEmptyRows(ReadOnlyCollection<IWebElement> rows)
        {
            List<string> rowsText = new List<string>();
            for (int i = 0; i < rows.Count; i++)
            {
                var stringBuilder = new StringBuilder();
                {
                    IWebElement element = rows[i];
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

        public List<string> GetListOfFilteredRows(List<string> rows, string filterValue)
        {
            List<string> filteredListOfRows = new List<string>();
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Contains(filterValue))
                {
                    filteredListOfRows.Add(rows[i]);
                }
            }

            return filteredListOfRows;
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

        public void FillInSearchInput(string value) => _searchInput.SendKeys(value);

        public void FillInFirstNameInput(string value) => _firstNameInput.SendKeys(value);

        public void FillInLastNameInput(string value) => _lastNameInput.SendKeys(value);

        public void FillInEmailInput(string value) => _emailInput.SendKeys(value);

        public void FillInAgeInput(string value) => _ageInput.SendKeys(value);

        public void FillInSalaryInput(string value) => _salaryInput.SendKeys(value);

        public void FillInDepartmentInput(string value) => _departmentInput.SendKeys(value);

        public void ClearFirstNameInput() => _firstNameInput.SendKeys(Keys.Control + "a" + Keys.Delete);

        public void ClearLastNameInput() => _lastNameInput.SendKeys(Keys.Control + "a" + Keys.Delete);

        public void ClearEmailInput() => _emailInput.SendKeys(Keys.Control + "a" + Keys.Delete);

        public void ClearAgeInput() => _ageInput.SendKeys(Keys.Control + "a" + Keys.Delete);

        public void ClearSalaryInput() => _salaryInput.SendKeys(Keys.Control + "a" + Keys.Delete);

        public void ClearDepartmentInput() => _departmentInput.SendKeys(Keys.Control + "a" + Keys.Delete);

        public ReadOnlyCollection<IWebElement> GetNewRow()
        {
            var newRow = _row.FindElements(By.XPath("((//div[@role='row'])[5])/div"));

            return newRow;
        }

        public ReadOnlyCollection<IWebElement> GetEditedRow()
        {
            var editedRow = _row.FindElements(By.XPath("((//div[@role='row'])[2])/div"));

            return editedRow;
        }
    }
}