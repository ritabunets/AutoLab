using Homework17.HttpClients;
using Homework17.Models;
using Homework17.Models.JsonModels;

namespace Homework17.Services
{
    public class RequestsService
    {
        private const string BaseUrl = "https://reqres.in/api";

        public static RestResponse<ListOfUsersToGet> GetUsersList() => BasicHttpClient.PerformGetRequest<ListOfUsersToGet>($"{BaseUrl}/users", null);

        public static RestResponse<ListOfUsersToGet> GetUsersListOnSetPage(int id) =>
            BasicHttpClient.PerformGetRequest<ListOfUsersToGet>($"{BaseUrl}/users?page={id}", null);

        public static RestResponse<CreatedUser> CreateUser(UserToCreate userToCreate) =>
            BasicHttpClient.PerformPostRequest<UserToCreate, CreatedUser>($"{BaseUrl}/users", userToCreate, null);

        public static RestResponse<UpdatedUser> UpdateUser(UserToCreate userToCreate,int id) =>
           BasicHttpClient.PerformPutRequest<UserToCreate, UpdatedUser>($"{BaseUrl}/users/{id}", userToCreate, null);

        public static RestResponse DeleteUser(int id) =>
           BasicHttpClient.PerformDeleteRequest($"{BaseUrl}/users/{id}", null);
    }
}