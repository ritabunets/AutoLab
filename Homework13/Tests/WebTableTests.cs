using Homework13.Data.Constants;
using Homework13.Helpers;
using Homework13.PageObjects;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class WebTableTests : BaseTest
    {
        private string _firstName = RandomHelper.GetRandomString(10);
        private string _lastName = RandomHelper.GetRandomString(10);
        private string _email = $"{RandomHelper.GetRandomString(10)}@example.com";
        private string _age = RandomHelper.GetRandomInt(100);
        private string _salary = RandomHelper.GetRandomInt(100000);
        private string _department = RandomHelper.GetRandomString(10);

        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.WebTables);
        }

        // Test1: Check validation of form inputs.
        [Test]
        public void CheckValidation()
        {
            GenericPages.WebTablePage.ClickAddNewEntryButton();
            GenericPages.WebTablePage.ClickSubmitButton();
            Assert.IsTrue(GenericPages.WebTablePage.IsFormValidated());

            // Postcondition: return to original state.
            GenericPages.WebTablePage.ClickCloseButton();
        }

        // Test2: Search an entry.
        [Test]
        public void SearchEntry()
        {
            // Get the first name from the first row.
            var firstName1 = GenericPages.WebTablePage.GetFirstName1Value();

            // Get the rows from the collection above that contains the first name from the first entry.
            var filteredRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName1);

            // Search.
            GenericPages.WebTablePage.FillInSearchTextBox(firstName1);

            // Get the rows from the result collection.
            var resultRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfRows(GenericPages.WebTablePage.GetListOfNotEmptyRows());

            // Get the rows from the result collection that contains the first name from the first entry.
            var filteredResultRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName1);

            // Check that: 1) Each result row contains the first name from the first entry. 2) Number of rows with the first name before the search is the same as after the search.
            Assert.Multiple(() =>
            {
                Assert.AreEqual(filteredResultRowsCountWithSearchedValue, resultRowsCountWithSearchedValue);
                Assert.AreEqual(filteredRowsCountWithSearchedValue, resultRowsCountWithSearchedValue);
            });
        }

        // Test3: Add new entry.
        [Test]
        public void AddNewEntry()
        {
            GenericPages.WebTablePage.ClickAddNewEntryButton();

            // Calculate estimated new row id.
            var numberOfExistingRows = GenericPages.WebTablePage.GetListOfNotEmptyRows().Count;
            var indexOfNewEntryRow = numberOfExistingRows + 2;

            // Fill in form inputs.
            GenericPages.WebTablePage.FillInFirstNameTextBox(_firstName);
            GenericPages.WebTablePage.FillInLastNameTextBox(_lastName);
            GenericPages.WebTablePage.FillInEmailTextBox(_email);
            GenericPages.WebTablePage.FillInAgeTextBox(_age);
            GenericPages.WebTablePage.FillInSalaryTextBox(_salary);
            GenericPages.WebTablePage.FillInDepartmentTextBox(_department);
            GenericPages.WebTablePage.ClickSubmitButton();

            // Get text of new entry and compare it with expected.
            var entryValue = $"{_firstName} {_lastName} {_age} {_email} {_salary} {_department}";
            Assert.AreEqual(entryValue, GenericPages.WebTablePage.GetTextOfElement(indexOfNewEntryRow));
        }

        // Test4: Edit first entry.
        [Test]
        public void EditFirstEntry()
        {
            // Open edit form for the first entry.
            var firstName1 = GenericPages.WebTablePage.GetFirstName1Value();
            GenericPages.WebTablePage.ClickEditEntryButton(firstName1);

            // Clear form inputs.
            GenericPages.WebTablePage.ClearFirstNameTextBox();
            GenericPages.WebTablePage.ClearLastNameTextBox();
            GenericPages.WebTablePage.ClearEmailTextBox();
            GenericPages.WebTablePage.ClearAgeTextBox();
            GenericPages.WebTablePage.ClearSalaryTextBox();
            GenericPages.WebTablePage.ClearDepartmentTextBox();

            // Fill in form inputs.
            GenericPages.WebTablePage.FillInFirstNameTextBox(_firstName);
            GenericPages.WebTablePage.FillInLastNameTextBox(_lastName);
            GenericPages.WebTablePage.FillInEmailTextBox(_email);
            GenericPages.WebTablePage.FillInAgeTextBox(_age);
            GenericPages.WebTablePage.FillInSalaryTextBox(_salary);
            GenericPages.WebTablePage.FillInDepartmentTextBox(_department);
            GenericPages.WebTablePage.ClickSubmitButton();

            // Get text of updated entry and compare it with expected.
            var entryValue = $"{_firstName} {_lastName} {_age} {_email} {_salary} {_department}";
            Assert.AreEqual(entryValue, GenericPages.WebTablePage.GetTextOfElement(2));
        }

        // Test5: Delete first entry.
        [Test]
        public void DeleteFirstEntry()
        {
            // Get the first name from the first row.
            var firstName1 = GenericPages.WebTablePage.GetFirstName1Value();

            // Get the rows number with first name from condition before the delete operation.
            var rowsWithInitialValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName1);

            // Remove the first row.
            GenericPages.WebTablePage.ClickDeleteEntryButton();

            // Get the rows number with first name from condition after the delete opetarion.
            var rowsWithRemovedValue = GenericPages.WebTablePage.GetCountOfRowsWithValue(firstName1);

            // Calculate estimated rows count.
            var estimatedRowsCount = rowsWithRemovedValue + 1;

            // Check that number of rows with first name from the condition is less by 1 then it was before the delete operation.
            Assert.AreEqual(rowsWithInitialValue, estimatedRowsCount);
        }
    }
}