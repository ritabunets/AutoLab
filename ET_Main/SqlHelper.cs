using System.Data.Entity.Core.EntityClient;
using AdonetProject;
using EntityFrameworkProject;

namespace ET_Main
{
    public class SqlHelper
    {
        public static string GetClientExtendedConnectionString(string sqlConnectionString)
        {
            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlConnectionString,
                Metadata = "res://*/AdonetDB.csdl|res://*/AdonetDB.ssdl|res://*/AdonetDB.msl"
            };

            return entityBuilder.ToString();
        }

        public static List<T> GetAdonetDbInstance<T>(Func<AdonetDbEntities, IQueryable<T>> func)
        {
            using (var context = new AdonetDbEntities(GetClientExtendedConnectionString(ConfigurationHelper.LocalAdonetDbConnectionString)))
            {
                var result = func(context);

                return result.ToList();
            }
        }

        public static List<User> GetAdonetDbInstance(Func<AdonetDbEntities, IQueryable<User>> func)
        {
            using (var context = new AdonetDbEntities(GetClientExtendedConnectionString(ConfigurationHelper.LocalAdonetDbConnectionString)))
            {
                var result = func(context);

                return result.ToList();
            }
        }

        public static void AddNewEntryToUsers(User newUser)
        {
            using (var context = new AdonetDbEntities(GetClientExtendedConnectionString(ConfigurationHelper.LocalAdonetDbConnectionString)))
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public static User GetLastEntryFromUsers(int id)
        {
            using (var context = new AdonetDbEntities(GetClientExtendedConnectionString(ConfigurationHelper.LocalAdonetDbConnectionString)))
            {
                return context.Users
                      .Where(u => u.Id == id)
                      .ToList()
                      .LastOrDefault();
            }
        }

        public static AdonetDbEntities GetAdonetdbEntities() =>
            new AdonetDbEntities(GetClientExtendedConnectionString(ConfigurationHelper.LocalAdonetDbConnectionString));
    }
}