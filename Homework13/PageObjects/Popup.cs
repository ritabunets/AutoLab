using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class Popup
    {
        private DemoQaWebElement _firstNameTextBox = new(By.XPath("//input[@id='firstName']"));
        private DemoQaWebElement _lastNameTextBox = new(By.XPath("//input[@id='lastName']"));
        private DemoQaWebElement _emailTextBox = new(By.XPath("//input[@id='userEmail']"));
        private DemoQaWebElement _ageTextBox = new(By.XPath("//input[@id='age']"));
        private DemoQaWebElement _salaryTextBox = new(By.XPath("//input[@id='salary']"));
        private DemoQaWebElement _departmentTextBox = new(By.XPath("//input[@id='department']"));
        private DemoQaWebElement _submitButton = new(By.XPath("//button[@id='submit']"));
        private DemoQaWebElement _closeButton = new(By.XPath("//span[contains(text(),'×')]"));

        public void CloseForm() => _closeButton.Click();

        public void SubmitForm() => _submitButton.Click();

        public void ClearFormTextBoxes()
        {
            _firstNameTextBox.ClearTextBox();
            _lastNameTextBox.ClearTextBox();
            _emailTextBox.ClearTextBox();
            _ageTextBox.ClearTextBox();
            _salaryTextBox.ClearTextBox();
            _departmentTextBox.ClearTextBox();
        }

        public void FillInFormTextBoxes(string firstName, string lastName, string email, string age, string salary, string department)
        {
            _firstNameTextBox.SendKeys(firstName);
            _lastNameTextBox.SendKeys(lastName);
            _emailTextBox.SendKeys(email);
            _ageTextBox.SendKeys(age);
            _salaryTextBox.SendKeys(salary);
            _departmentTextBox.SendKeys(department);
        }
    }
}