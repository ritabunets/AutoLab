using System.Data;
using AdonetProject.Constants;
using Microsoft.Data.SqlClient;

namespace AdonetProject
{
    public class AdonetDbHelper
    {
        private const string DBName = "AdonetDb";
        private const string UsersTableName = "Users";
        private static string _connectionStringAdonet => ConfigurationHelper.LocalAdonetDbConnectionString;
        private static string _connectionStringMaster => ConfigurationHelper.LocalMasterDbConnectionString;

        public static string CreateDb()
        {
            using (var sqlConnection = new SqlConnection(_connectionStringMaster))
            {
                var sqlQuery = "SELECT name FROM sys.databases;";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];
                var listOfDbNames = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    listOfDbNames.Add(row["name"].ToString());
                }

                if (!listOfDbNames.Contains(DBName))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"CREATE DATABASE {DBName}";
                    command.Connection = sqlConnection;
                    command.ExecuteNonQuery();
                }

                return DBName;
            }
        }

        public static string CreateUsersTable()
        {
            var adonetDb = CreateDb();

            using (var sqlConnection = new SqlConnection(_connectionStringAdonet))
            {
                var sqlQuery = "SELECT name FROM sys.tables;";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];
                var listOfTableNames = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    listOfTableNames.Add(row["name"].ToString());
                }

                if (!listOfTableNames.Contains(UsersTableName))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"CREATE TABLE {UsersTableName} ({UsersTableColumns.Id} INT PRIMARY KEY IDENTITY, " +
                        $"{UsersTableColumns.FirstName} NVARCHAR(100) NOT NULL, {UsersTableColumns.LastName} NVARCHAR(100) NOT NULL, " +
                        $"{UsersTableColumns.Email} NVARCHAR(100) NOT NULL, {UsersTableColumns.Age} INT NOT NULL)";
                    command.Connection = sqlConnection;
                    command.ExecuteNonQuery();
                }

                return UsersTableName;
            }
        }

        public static void AddUser(string firstName, string lastName, string email, int age)
        {
            var usersTable = CreateUsersTable();

            using (var sqlConnection = new SqlConnection(_connectionStringAdonet))
            {
                sqlConnection.Open();
                var sqlQuery = $"INSERT INTO {usersTable} (firstName, lastName, email, age) VALUES ('{firstName}', '{lastName}', '{email}', {age})";
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static string GetLastAddedValue(string columnName)
        {
            using (var sqlConnection = new SqlConnection(_connectionStringAdonet))
            {
                sqlConnection.Open();
                var sqlQuery = "SELECT * FROM Users WHERE id = (SELECT max(id) FROM Users)";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];
                var lastAddedValue = table.Rows[0][columnName].ToString();

                return lastAddedValue;
            }
        }
    }
}