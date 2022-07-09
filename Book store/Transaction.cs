using Microsoft.Data.Sqlite;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store
{
    public class Transaction
    {
        public Transaction()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();

                string createTransactionTable = "CREATE TABLE IF NOT EXISTS Transaction_" +
                    "(ISBN smallint NOT NULL," +
                    "Customer_Id smallint NOT NULL," +
                    "Quatity smallint NOT NULL," +
                    "Date NVARCHAR(10) NOT NULL," +
                    "Time NVARCHAR(5) NOT NULL," +
                    "Total_Price smallmoney NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(createTransactionTable, db);
                createTable.ExecuteReader();
                db.Close();

            }
        }




        public static void add(int isbn, int id, int Quantity)
        {
            using (SqliteConnection db =
              new SqliteConnection("Filename=StoreData.db"))
            {
                ArrayList BookData = new ArrayList();
                BookData = Books.get(isbn);
                int Remaining = int.Parse(BookData[4].ToString());
                if (Quantity > Remaining) { MessageBox.Show("Not enough Book"); return; }
                int price = int.Parse(BookData[3].ToString());
                int totalPrice = Quantity * price;
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Transaction_ VALUES (@ISBN,@customer_id,@Quatity,@Date,@Time,@Total_Price)";
                insertCommand.Parameters.AddWithValue("@customer_id", id);
                insertCommand.Parameters.AddWithValue("@ISBN", isbn);
                insertCommand.Parameters.AddWithValue("@Quatity", Quantity);
                insertCommand.Parameters.AddWithValue("@Date", getDate());
                insertCommand.Parameters.AddWithValue("@Time", getTime());
                insertCommand.Parameters.AddWithValue("@Total_Price", totalPrice);


                insertCommand.ExecuteReader();
                db.Close();
                Books.set(isbn, "Remaining", (int.Parse(BookData[4].ToString()) - Quantity).ToString());
            }
        }




        public static ArrayList get()
        {
            ArrayList entries = new ArrayList();
            using (SqliteConnection db =
               new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Transaction_", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                    entries.Add(query.GetString(4));
                    entries.Add(query.GetString(5));
                }
                db.Close();
            }
            return entries;
        }
        public static string getDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
        public static string getTime() 
        {
            return DateTime.Now.ToString("HH:mm");
        }
    }
}