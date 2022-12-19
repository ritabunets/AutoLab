using Homework13.Data.Constants;
using Homework13.PageObjects;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class WebTableTests : BaseTest
    {
        const string firstName = "Rita";
        const string lastName = "Bunets";
        const string email = "email@example.com";
        const string age = "26";
        const string salary = "100000";
        const string department = "QA";
        const string entryValue = "Rita Bunets 26 email@example.com 100000 QA  ";

        [SetUp]
        public void SetUp()
        {
            GenericPages.BaseElementsPage.ClickOnElementsMenuItem(Elements.WebTables);
        }

        // Test1: Check validation of form inputs.
        [Test]
        public void CheckValidation()
        {
            const string validatedFormClass = "was-validated";

            GenericPages.WebTablePage.ClickAddNewEntryButton();
            GenericPages.WebTablePage.ClickSubmitButton();
            Assert.AreEqual(validatedFormClass, GenericPages.WebTablePage.GetFormClass());

            // Postcondition: return to original state.
            GenericPages.WebTablePage.ClickCloseButton();
        }

        // Test2: Search an entry.
        [Test]
        public void SearchEntry()
        {
            // Get the first name from the first row.
            var firstName1 = GenericPages.WebTablePage.GetFirstName1Value();

            // Get the rows before the search operation.
            var allRows = GenericPages.WebTablePage.GetRows();

            // Get the rows from the collection above that contains the first name from the first entry.
            var filteredRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfFilteredRows(GenericPages.WebTablePage.GetListOfNotEmptyRows(allRows), firstName1);

            // Search.
            GenericPages.WebTablePage.FillInSearchInput(firstName1);

            // Get the rows after the search operation.
            var filteredRows = GenericPages.WebTablePage.GetRows();

            // Get the rows from the result collection.
            var resultRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfRows(GenericPages.WebTablePage.GetListOfNotEmptyRows(GenericPages.WebTablePage.GetRows()));

            // Get the rows from the result collection that contains the first name from the first entry.
            var filteredResultRowsCountWithSearchedValue = GenericPages.WebTablePage.GetCountOfFilteredRows(GenericPages.WebTablePage.GetListOfNotEmptyRows(filteredRows), firstName1);

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

            // Fill in form inputs.
            GenericPages.WebTablePage.FillInFirstNameInput(firstName);
            GenericPages.WebTablePage.FillInLastNameInput(lastName);
            GenericPages.WebTablePage.FillInEmailInput(email);
            GenericPages.WebTablePage.FillInAgeInput(age);
            GenericPages.WebTablePage.FillInSalaryInput(salary);
            GenericPages.WebTablePage.FillInDepartmentInput(department);
            GenericPages.WebTablePage.ClickSubmitButton();

            // Get text of new entry and compare it with expected.
            Assert.AreEqual(entryValue, GenericPages.WebTablePage.GetTextOfCollectionElements(GenericPages.WebTablePage.GetNewRow()));
        }

        // Test4: Edit first entry.
        [Test]
        public void EditFirstEntry()
        {
            GenericPages.WebTablePage.ClickEditEntryButton();

            // Clear form inputs.
            GenericPages.WebTablePage.ClearFirstNameInput();
            GenericPages.WebTablePage.ClearLastNameInput();
            GenericPages.WebTablePage.ClearEmailInput();
            GenericPages.WebTablePage.ClearAgeInput();
            GenericPages.WebTablePage.ClearSalaryInput();
            GenericPages.WebTablePage.ClearDepartmentInput();

            // Fill in form inputs.
            GenericPages.WebTablePage.FillInFirstNameInput(firstName);
            GenericPages.WebTablePage.FillInLastNameInput(lastName);
            GenericPages.WebTablePage.FillInEmailInput(email);
            GenericPages.WebTablePage.FillInAgeInput(age);
            GenericPages.WebTablePage.FillInSalaryInput(salary);
            GenericPages.WebTablePage.FillInDepartmentInput(department);
            GenericPages.WebTablePage.ClickSubmitButton();

            // Get text of updated entry and compare it with expected.
            Assert.AreEqual(entryValue, GenericPages.WebTablePage.GetTextOfCollectionElements(GenericPages.WebTablePage.GetEditedRow()));
        }

        // Test5: Delete first entry.
        [Test]
        public void DeleteFirstEntry()
        {
            // Get the first name from the first row.
            var firstName1 = GenericPages.WebTablePage.GetFirstName1Value();

            // Get the rows number with first name from condition before the delete opetarion.
            var initialRows = GenericPages.WebTablePage.GetRows();
            var rowsWithInitialValue = GenericPages.WebTablePage.GetCountOfFilteredRows(GenericPages.WebTablePage.GetListOfNotEmptyRows(initialRows), firstName1);

            // Remove the first row.
            GenericPages.WebTablePage.ClickDeleteEntryButton();

            // Get the rows number with first name from condition after the delete opetarion.
            var resultRows = GenericPages.WebTablePage.GetRows();
            var rowsWithRemovedValue = GenericPages.WebTablePage.GetCountOfFilteredRows(GenericPages.WebTablePage.GetListOfNotEmptyRows(resultRows), firstName1);

            // Check that number of rows with first name from the condition is less by 1 then it was before the delete operation
            Assert.AreEqual(rowsWithInitialValue, rowsWithRemovedValue+1);
        }
    }
}