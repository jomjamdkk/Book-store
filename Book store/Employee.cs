using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace Book_store {
    internal class Employee {
        public Employee() {
            using (SqliteConnection db = new SqliteConnection("Filename=StoreData.db")) {
                db.Open();

                string creatEmployeeTable = "CREATE TABLE IF NOT EXISTS Employee" +
                    "(Employee_ID BIT PRIMARY KEY," +
                    "Employee_Name NVARCHAR(128) NOT NULL," +
                    "Address NVARCHAR(128) NOT NULL," +
                    "NationalID NVARCHAR (13) UNIQUE," +
                    "Password NVARCHAR(64) NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(creatEmployeeTable, db);

                createTable.ExecuteReader();

                db.Close();
            }
        }




        public static void add(int id, string name, string address, int NationalID, int pw) {
            using (SqliteConnection db =
              new SqliteConnection("Filename=StoreData.db")) {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Employee VALUES (@Employee_Id,@Employee_name,@Employee_address,@Employee_NationalId,@PW)";
                insertCommand.Parameters.AddWithValue("@Employee_Id", id);
                insertCommand.Parameters.AddWithValue("@Employee_name", name);
                insertCommand.Parameters.AddWithValue("@Employee_address", address);
                insertCommand.Parameters.AddWithValue("@Employee_NationalId", NationalID);
                insertCommand.Parameters.AddWithValue("@PW", pw);



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

                updateCommand.CommandText = "UPDATE Employee SET " + fieldName + " = '" + data + "' WHERE Employee_ID = " + id + "; ";



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
                    ("SELECT * from Employee WHERE Employee_ID = " + id, db);
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

    }
}
