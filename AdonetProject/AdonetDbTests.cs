using AdonetProject.Models;
using NUnit.Framework;

namespace AdonetProject
{
    public class AdonetDbTests
    {
        [Test]
        public void CreateNewUserViaAdonetAndCheckData()
        {
            var newUser = new User("Rita", "Bunets", "rb@example.com", 26);

            AdonetDbHelper.AddUser(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Age);

            var firstNameInDB = AdonetDbHelper.GetLastAddedValue("FirstName");
            var lastNameInDB = AdonetDbHelper.GetLastAddedValue("LastName");
            var emailInDB = AdonetDbHelper.GetLastAddedValue("Email");
            var ageInDB = AdonetDbHelper.GetLastAddedValue("Age");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(newUser.FirstName, firstNameInDB);
                Assert.AreEqual(newUser.LastName, lastNameInDB);
                Assert.AreEqual(newUser.Email, emailInDB);
                Assert.AreEqual(newUser.Age.ToString(), ageInDB);
            });
        }
    }
}