﻿using Microsoft.Data.Sqlite;
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

                string createTransactionTable = "CREATE TABLE IF NOT EXISTS PurchaseHistory" +
                    "(ISBN smallint NOT NULL," +
                    "Customer_Id smallint NOT NULL," +
                    "Quatity smallint NOT NULL," +
                    "DateTime NVARCHAR(32) NOT NULL," +
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
                if (Quantity>Remaining) 
                { MessageBox.Show("Not enough Book"); return; }
                int price = int.Parse(BookData[3].ToString());
                int totalPrice = Quantity * price;
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO PurchaseHistory VALUES (@ISBN,@customer_id,@Quatity,@DateTime,@Total_Price)";
                insertCommand.Parameters.AddWithValue("@customer_id", id);
                insertCommand.Parameters.AddWithValue("@ISBN", isbn);
                insertCommand.Parameters.AddWithValue("@Quatity", Quantity);
                insertCommand.Parameters.AddWithValue("@DateTime", getDateTime());
                insertCommand.Parameters.AddWithValue("@Total_Price", totalPrice);


                insertCommand.ExecuteReader();
                db.Close();
                Books.set(isbn, "Remaining", (int.Parse(BookData[4].ToString())-Quantity).ToString());
            }
        }




        public static ArrayList get(int id)
        {
            ArrayList entries = new ArrayList();
            using (SqliteConnection db =
               new SqliteConnection("Filename=StoreData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from PurchaseHistory WHERE Customer_Id = " + id, db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }
        public static string getDateTime()
        {
            return DateTime.Now.ToString() + "  UTC+7";
        }
    }
}