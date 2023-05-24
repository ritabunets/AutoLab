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

            var userInDb = SqlHelper.GetLastEntryFromUsers(newUser.Id);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(newUser.FirstName, userInDb.FirstName);
                Assert.AreEqual(newUser.LastName, userInDb.LastName);
                Assert.AreEqual(newUser.Email, userInDb.Email);
                Assert.AreEqual(newUser.Age.ToString(), userInDb.Age.ToString());
            });
        }
    }
}