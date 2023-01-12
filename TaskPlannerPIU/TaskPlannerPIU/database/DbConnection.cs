using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TaskPlannerPIU.entities;

namespace TaskPlannerPIU.database
{
    public class DatabaseConnection
    {
        private SqlConnection _connection;
        private string _connectionString;

        public void connect()
        {
            _connectionString = @"Data Source=MONICA24\SQLEXPRESS;Initial Catalog=idm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public List<User> getAllUsers()
        {
            List<User> users = new List<User>(); 

            if (_connection == null)
                throw new Exception("connection is null");

            string sql = "SELECT username, password from dbo.users";
            SqlCommand cmd = new SqlCommand(sql, _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User user = new User { Username = reader.GetValue(0).ToString() ,Password = reader.GetValue(1).ToString() };
                users.Add(user);
            }

            return users;
        }

        public void closeConnection()
        {
            if (_connection != null)
                _connection.Close();
        }
    }
}
