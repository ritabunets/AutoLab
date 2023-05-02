using EntityFrameworkProject;
using NUnit.Framework;

namespace ET_Main
{
    public class EntityFrameworkTests
    {
        [Test]
        public void CreateNewUserViaEF()
        {
            var newUser = new User() { FirstName = "Ivan", LastName = "Zialinski", Email = "iz@example.com", Age = 26 };

            SqlHelper.AddNewEntryToUsers(newUser);

            var userInDbFirstName = SqlHelper.GetLastEntryFromUsers(newUser.Id).FirstName;
            var userInDbLastName = SqlHelper.GetLastEntryFromUsers(newUser.Id).LastName;
            var userInDbEmail = SqlHelper.GetLastEntryFromUsers(newUser.Id).Email;
            var userInDbAge = SqlHelper.GetLastEntryFromUsers(newUser.Id).Age.ToString();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(newUser.FirstName, userInDbFirstName);
                Assert.AreEqual(newUser.LastName, userInDbLastName);
                Assert.AreEqual(newUser.Email, userInDbEmail);
                Assert.AreEqual(newUser.Age.ToString(), userInDbAge);
            });
        }
    }
}