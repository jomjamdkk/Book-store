using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace Book_store
{
    public class Books
    {
        public Books()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();

                string createBooksTable = "CREATE TABLE IF NOT EXISTS Books" +
                    "(ISBN smallint PRIMARY KEY," +
                    "Title NVARCHAR(64) NOT NULL," +
                    "Description NVARCHAR(1024) NULL," +
                    "Price smallmoney NOT NULL," +
                    "Remaining smallint NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(createBooksTable, db);
                createTable.ExecuteReader();

                db.Close();

            }
        }




        public static void add(int isbn, string title, string description, float price, int remaining)
        {
            using (SqliteConnection db =
              new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Books VALUES (@book_isbn,@book_title,@book_description,@book_price,@book_remaining)";
                insertCommand.Parameters.AddWithValue("@book_isbn", isbn);
                insertCommand.Parameters.AddWithValue("@book_title", title);
                insertCommand.Parameters.AddWithValue("@book_description", description);
                insertCommand.Parameters.AddWithValue("@book_price", price);
                insertCommand.Parameters.AddWithValue("@book_remaining", remaining);


                insertCommand.ExecuteReader();
                db.Close();
            }
        }




        public static void set(int isbn, string fieldName, string data)
        {
            using (SqliteConnection db =
              new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();
                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Books SET " + fieldName + " = '" + data + "' WHERE ISBN = " + isbn + "; ";

                updateCommand.ExecuteReader();
                db.Close();
            }
        }




        public static ArrayList get(int isbn)
        {
            ArrayList entries = new ArrayList();
            using (SqliteConnection db =
               new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books WHERE ISBN = " + isbn, db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));//ISBN
                    entries.Add(query.GetString(1));//Title
                    entries.Add(query.GetString(2));//Description
                    entries.Add(query.GetString(3));//Price
                    entries.Add(query.GetString(4));//Remaining
                }
                db.Close();
            }
            return entries;
        }




        public static void delete(int id)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();
                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM Books WHERE ISBN = " + id + ";";
                deleteCommand.ExecuteReader();
                db.Close();
            }

        }
    }
}