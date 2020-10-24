using Library_SQL.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Library_SQL.Service
{
    public static class SQLite_Service// lite anorlunda
    { //initialize 
        private static string dbName { get; set; }
        private static string dbPath { get; set; }

        public static async Task InitializeSqliteAsync(string databaseName, string @databaseLocation) //location jag välja||eller localfolder
        {
            dbName = databaseName;
            dbPath = Path.Combine(databaseLocation, dbName); //vi ! använda -ApplicationData - det for UWP app, så specificiera var det ligger

            using (var db=new SqliteConnection($"Filename={dbPath }"))
            {
                db.Open();
                var guery = "CREATE TABLE IF NOT EXIST Customers(Id INTEGER PRIMARY KEY, FirstName NVARCHAR(50) NOT NULL, LastName NVARCHAR(50) NOT NULL, Email  NVARCHAR(100) NOT NULL";
                var cmd = new SqliteCommand(guery, db);

                await cmd.ExecuteReaderAsync();//++ await, -Ásync;
                db.Close();
            }
        }

        public static async Task AddCustomerAsync(Customer customer) //copy from initialize . only guery
        {
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var query = "INSERT INTO Customers (FirstName,LastName,Email) VALUES(@FirstName,@LastName,@Email)";//@ place hålder
                var cmd = new SqliteCommand(query, db);
               
                // ++parameter
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);

                await cmd.ExecuteReaderAsync();
                db.Close();
            }
        }

        public static async Task<IEnumerable<Customer>> GetCustomersAsync()// hämta
        {
            var customers = new List<Customer>();//skapa list

            using (var db = new SqliteConnection($"Filename={dbPath}"))//koppla
            {
                db.Open();

                var query = "SELECT * FROM Customers";
                var cmd = new SqliteCommand(query, db); //hämta

                var result = await cmd.ExecuteReaderAsync();//spara

                while (result.Read())
                {
                   // customers.Add(new Customer(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3)));

                    var customer = new Customer(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3));
                    // Id, FN, LN, email//conrtol att ha CTOR i customer class for alla 4
                    customers.Add(customer);
                }

                db.Close();

                return customers;//lista
            }
        }

        
    }
}
