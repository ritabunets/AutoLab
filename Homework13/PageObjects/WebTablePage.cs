using System.Collections.ObjectModel;
using System.Text;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class WebTablePage
    {
        private DemoQaWebElement _addNewEntryButton = new(By.XPath("//button[@id='addNewRecordButton']"));
        private DemoQaWebElement _form = new(By.XPath("//form"));
        private DemoQaWebElement _header = new(By.XPath("(//div[@role='row'])[1]"));
        private DemoQaWebElement _tableRows = new(By.XPath("//div[@class='rt-tbody']"));
        private DemoQaWebElement _searchTextBox = new(By.XPath("//input[@id='searchBox']"));

        public bool IsFormValidated() => _form.GetClass().Contains("was-validated");

        public void ClickAddNewEntryButton() => _addNewEntryButton.Click();

        public void ClickEditEntryButton(string firstName) => GetEditButton(firstName).Click();

        public void ClickDeleteButton(string firstName) => GetDeleteButton(firstName).Click();

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

        public string GetTextOfTableRow(int index)
        {
            string text = GetRow(index).Text;
            var actualString = text.Replace("\r\n", " ");

            return actualString;
        }

        public void FillInSearchTextBox(string value) => _searchTextBox.SendKeys(value);

        public string GetFieldValue(string columnName, int rowIndex)
        {
            int columnIndex = GetColumnIndex(columnName);
            string fieldValue = GetField(rowIndex, columnIndex).Text;
            return fieldValue;
        }

        private int GetColumnIndex(string columnName)
        {
            ReadOnlyCollection<IWebElement> columnHeaders = _header.FindElements(By.XPath(".//div[@role='columnheader']"));
            List<string> listOfColumnHeaders = new List<string>();
            for (int i = 0; i < columnHeaders.Count; i++)
            {
                string columnHeader = columnHeaders[i].Text;
                listOfColumnHeaders.Add(columnHeader);
            }

            int columnIndex = listOfColumnHeaders.FindIndex(x => x.Equals(columnName));

            return columnIndex;
        }

        private DemoQaWebElement GetField(int rowIndex, int columnIndex) => new DemoQaWebElement(By.XPath($"((//div[@role='rowgroup'])['{rowIndex}']" +
            $"//div[@role='gridcell'])['{columnIndex}']"));

        private DemoQaWebElement GetRow(int index) => new DemoQaWebElement(By.XPath($"(//div[@role='rowgroup'])[{index}]"));

        private DemoQaWebElement GetEditButton(string firstName) => new DemoQaWebElement(By.XPath($"(//div[contains(text(),'{firstName}')]" +
            $"/ancestor::div[@role='row']//div[@role='gridcell']//span)[1]"));

        private DemoQaWebElement GetDeleteButton(string firstName) => new DemoQaWebElement(By.XPath($"(//div[contains(text(),'{firstName}')]" +
            $"/ancestor::div[@role='row']//div[@role='gridcell']//span)[2]"));
    }
}