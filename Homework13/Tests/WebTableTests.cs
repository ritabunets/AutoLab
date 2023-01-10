using Homework13.Data.Constants;
using Homework13.Helpers;
using Homework13.PageObjects;
using Homework13.UIElements;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class WebTableTests : BaseTest
    {
        private const string FirstNameColumn = "First Name";
        private string _firstName = RandomHelper.GetRandomString(10);
        private string _lastName = RandomHelper.GetRandomString(10);
        private string _email = $"{RandomHelper.GetRandomString(10)}@example.com";
        private string _age = RandomHelper.GetRandomInt(100);
        private string _salary = RandomHelper.GetRandomInt(100000);
        private string _department = RandomHelper.GetRandomString(10);

        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnCategoryMenuItem(Categories.Elements);
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.WebTables);
        }

        // Test1: Check validation of form inputs.
        [Test]
        public void CheckValidation()
        {
            GenericPages.WebTablePage.ClickAddNewEntryButton();
            GenericElements.Popup.SubmitForm();
            Assert.IsTrue(GenericPages.WebTablePage.IsFormValidated());

            // Postcondition: return to original state.
            GenericElements.Popup.CloseForm();
        }

        // Test2: Search an entry.
        [Test]
        public void SearchEntry()
        {
            // Get the first name from the first row.
            var firstName = GenericPages.WebTablePage.GetFieldValue(FirstNameColumn, 1);

            // Get the rows from the collection above that contains the first name from the first entry.
            var filteredRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName);

            // Get the rows beforethe search.
            var rowsCount = GenericPages.WebTablePage.GetListOfNotEmptyRows().Count;

            // Search.
            GenericPages.WebTablePage.FillInSearchTextBox(firstName);

            // Get the rows from the result collection.
            var resultRowsCountWithSearchedValue = GenericPages.WebTablePage.GetListOfNotEmptyRows().Count;

            // Get the rows from the result collection that contains the first name from the first entry.
            var filteredResultRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName);

            // Get the rows after the search.
            var rowsCountAfterSearch = GenericPages.WebTablePage.GetListOfNotEmptyRows().Count;

            // Compare the number of rows before and after the search
            bool isRowsNumberDecreased = rowsCount > rowsCountAfterSearch;

            // Check that: 1) Each result row contains the first name from the first entry. 2) Number of rows with the first name before the search is the same as after the search.
            Assert.Multiple(() =>
            {
                Assert.AreEqual(filteredResultRowsCountWithSearchedValue, resultRowsCountWithSearchedValue);
                Assert.AreEqual(filteredRowsCountWithSearchedValue, resultRowsCountWithSearchedValue);
                Assert.IsTrue(isRowsNumberDecreased);
            });
        }

        // Test3: Add new entry.
        [Test]
        public void AddNewEntry()
        {
            GenericPages.WebTablePage.ClickAddNewEntryButton();

            // Calculate estimated new row id.
            var numberOfExistingRows = GenericPages.WebTablePage.GetListOfNotEmptyRows().Count;
            var indexOfNewEntryRow = numberOfExistingRows + 1;

            // Fill in form inputs.
            GenericElements.Popup.FillInFormTextBoxes(_firstName, _lastName, _email, _age, _salary, _department);
            GenericElements.Popup.SubmitForm();

            // Get text of new entry and compare it with expected.
            var entryValue = $"{_firstName} {_lastName} {_age} {_email} {_salary} {_department}";
            Assert.AreEqual(entryValue, GenericPages.WebTablePage.GetTextOfTableRow(indexOfNewEntryRow));
        }

        // Test4: Edit first entry.
        [Test]
        public void EditFirstEntry()
        {
            // Open edit form for the first entry.
            var firstName = GenericPages.WebTablePage.GetFieldValue(FirstNameColumn, 1);
            GenericPages.WebTablePage.ClickEditEntryButton(firstName);

            // Clear form inputs.
            GenericElements.Popup.ClearFormTextBoxes();

            // Fill in form inputs.
            GenericElements.Popup.FillInFormTextBoxes(_firstName, _lastName, _email, _age, _salary, _department);
            GenericElements.Popup.SubmitForm();

            // Get text of updated entry and compare it with expected.
            var entryValue = $"{_firstName} {_lastName} {_age} {_email} {_salary} {_department}";
            Assert.AreEqual(entryValue, GenericPages.WebTablePage.GetTextOfTableRow(1));
        }

        // Test5: Delete first entry.
        [Test]
        public void DeleteFirstEntry()
        {
            // Get the first name from the first row.
            var firstName = GenericPages.WebTablePage.GetFieldValue(FirstNameColumn, 1);

            // Get the rows number with first name from condition before the delete operation.
            var rowsWithInitialValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName);

            // Remove the first row.
            GenericPages.WebTablePage.ClickDeleteButton(firstName);

            // Get the rows number with first name from condition after the delete opetarion.
            var rowsWithRemovedValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName);

            // Calculate estimated rows count.
            var estimatedRowsCount = rowsWithRemovedValue + 1;

            // Check that number of rows with first name from the condition is less by 1 then it was before the delete operation.
            Assert.AreEqual(rowsWithInitialValue, estimatedRowsCount);
        }
    }
}