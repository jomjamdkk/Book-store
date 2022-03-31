using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Book_store {
    public class Customers {
        public Customers() {
            using (SqliteConnection db = new SqliteConnection("Filename=StoreData.db")) {
                db.Open();

                string createCustomersTable = "CREATE TABLE IF NOT EXISTS Customers" +
                    "(Customer_Id smallint PRIMARY KEY," +
                    "Customer_Name NVARCHAR(128) NOT NULL," +
                    "Address NVARCHAR(128) NOT NULL," +
                    "Email NVARCHAR(128) UNIQUE)";

                SqliteCommand createTable = new SqliteCommand(createCustomersTable, db);

                createTable.ExecuteReader();

                db.Close();
            }
        }





        public static void add(int id, string name, string address, string email) {
            using (SqliteConnection db =
              new SqliteConnection("Filename=StoreData.db")) {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customers VALUES (@customer_id,@customer_name,@customer_address,@customer_email)";
                insertCommand.Parameters.AddWithValue("@customer_id", id);
                insertCommand.Parameters.AddWithValue("@customer_name", name);
                insertCommand.Parameters.AddWithValue("@customer_address", address);
                insertCommand.Parameters.AddWithValue("@customer_email", email);



                insertCommand.ExecuteReader();
                db.Close();
            }
        }





        public static void set(int id, string fieldName, string data) {
            using (SqliteConnection db =
              new SqliteConnection("Filename=StoreData.db")) {
                db.Open();
                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Customers SET " + fieldName + " = '" + data + "' WHERE Customer_Id = " + id + "; ";



                updateCommand.ExecuteReader();
                db.Close();
            }
        }





        public static ArrayList get(int id) {
            ArrayList entries = new ArrayList();
            using (SqliteConnection db =
               new SqliteConnection("Filename=StoreData.db")) {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers WHERE Customer_id = " + id, db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read()) {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                    entries.Add(query.GetString(4));
                }
                db.Close();
            }

            return entries;

        }





        public static ArrayList get(string email) {
            ArrayList entries = new ArrayList();
            using (SqliteConnection db =
               new SqliteConnection("Filename=StoreData.db")) {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers WHERE Email = " + email, db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read()) {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }

            return entries;

        }





        public static void delete(int id) {
            using (SqliteConnection db =
                new SqliteConnection("Filename=StoreData.db")) {
                db.Open();
                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM Customers WHERE Customer_Id = " + id + ";";
                deleteCommand.ExecuteReader();
                db.Close();
            }

        }
    }
}