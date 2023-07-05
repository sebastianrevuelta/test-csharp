using System;
using System.Data.SqlClient;

namespace SQLInjectionExample
{
    class SQLi
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a username:");
            string username = Console.ReadLine();

            string connectionString = "Data Source=your_server;Initial Catalog=your_database;User ID=your_username;Password=your_password";
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'"; // Vulnerable to SQL injection

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("Username: " + reader["Username"]);
                        Console.WriteLine("Email: " + reader["Email"]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
