using Homework17.Helpers;
using Homework17.Models.JsonModels;
using Homework17.Services;
using NUnit.Framework;

namespace Homework17.Tests
{
    public class UsersTests
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm";

        // Test 1: Get list of users and check the number of users.
        [Test]
        public void CheckNumberOfUsers()
        {
            const int expectedTotalUsers = 12;

            var response = RequestsService.GetUsersList();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(200, (int)response.StatusCode);
                Assert.AreEqual(expectedTotalUsers, response.ResponseModel.Total);
            });
        }

        // Test 2: Get list of users and check if a random user exists.
        [Test]
        public void CheckRandomUsers()
        {
            var randomFirstName = RandomHelper.GetRandomString(5);
            var response = RequestsService.GetUsersList();
            var numberOfPages = response.ResponseModel.Total_pages;

            // Verify if there is a random name in the list.
            for (int i = 1; i < numberOfPages + 1; i++)
            {
                var responsePerPage = RequestsService.GetUsersListOnSetPage(i).ResponseModel.Data.ToArray();
                var listOfFirstNames = responsePerPage.Select(x => x.First_name).ToList();
                Assert.Multiple(() =>
                {
                    Assert.IsFalse(listOfFirstNames.Contains(randomFirstName));
                    Assert.AreEqual(200, (int)response.StatusCode);
                });
            }
        }

        // Test 3: Create user and check the data of the created user.
        [Test]
        public void CreateUser()
        {
            var name = RandomHelper.GetRandomString(5);
            var job = RandomHelper.GetRandomString(5);
            var userToCreate = new UserToCreate(name, job);
            var response = RequestsService.CreateUser(userToCreate);
            var createdAt = response.ResponseModel.CreatedAt.ToString(DateTimeFormat);
            var expectedCreatedAt = DateTime.UtcNow.ToString(DateTimeFormat);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(201, (int)response.StatusCode);
                Assert.AreEqual(name, response.ResponseModel.Name);
                Assert.AreEqual(job, response.ResponseModel.Job);
                Assert.IsNotNull(response.ResponseModel.Id);
                Assert.AreEqual(expectedCreatedAt, createdAt);
            });
        }

        // Test 4: Update user and check the data of the updated user.
        [Test]
        public void UpdateUser()
        {
            var name = RandomHelper.GetRandomString(5);
            var job = RandomHelper.GetRandomString(5);
            var userToUpdate = new UserToCreate(name, job);
            var response = RequestsService.UpdateUser(userToUpdate, 1);
            var updatedAt = response.ResponseModel.UpdatedAt.ToString(DateTimeFormat);
            var expectedUpdatedAt = DateTime.UtcNow.ToString(DateTimeFormat);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(200, (int)response.StatusCode);
                Assert.AreEqual(name, response.ResponseModel.Name);
                Assert.AreEqual(job, response.ResponseModel.Job);
                Assert.AreEqual(expectedUpdatedAt, updatedAt);
            });
        }

        // Test 5: Remove user.
        [Test]
        public void DeleteUser()
        {
            var id = RandomHelper.GetRandomInt(12);
            var response = RequestsService.DeleteUser(id);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(204, (int)response.StatusCode);
            });
        }
    }
}