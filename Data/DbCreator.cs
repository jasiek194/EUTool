using System;
using System.Data.SQLite;
using System.IO;

namespace EUTool.Data
{
    public class DbCreator
    {
        SQLiteConnection dbConnection;
        SQLiteCommand command;
        string sqlQuery;
        string dbPath = Environment.CurrentDirectory + "\\D:\\Programowanie\\EUTool";
        string dbFilePath;

        public void createDbFile()
        {
            if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);
            dbFilePath = dbPath + "\\TestDatabase.db";

            if (!File.Exists(dbFilePath))
            {

                SQLiteConnection.CreateFile("TestDatabase.db");
            }
        }

        public void createTable()
        {
            if (!checkIfExist("Auctions"))
            {
                sqlQuery = "CREATE TABLE Auctions(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name STRING, Quantity DOUBLE, Price DOUBLE, Tax DOUBLE, Value DOUBLE";
                executeQuery(sqlQuery);
            }
        }

        public bool checkIfExist(string tableName)
        {
            command.CommandText = "SELECT name FROM sqlite_master WHERE name ='" + tableName + "'";
            var result = command.ExecuteScalar();

            return result != null && result.ToString() == tableName ? true : false;
        }

        public void executeQuery(string sqlQuery)
        {
            SQLiteCommand triggerCommand = dbConnection.CreateCommand();
            triggerCommand.CommandText = sqlQuery;
            triggerCommand.ExecuteNonQuery();
        }

        public bool checkIfTableContainsData(string tableName)
        {
            command.CommandText = "SELECT count(*) FROM " + tableName;
            var result = command.ExecuteScalar();

            return Convert.ToInt32(result) > 0 ? true : false;
        }
        
        public void fillTable()
        {
            if (!checkIfTableContainsData("Auctions"))
            {
                sqlQuery = "INSERT INTO Auctions (NAME,Quantity, Price, Tax, Value) values ('Belkar Ingot', 1000, 1654.50,0.54,3212)";
                executeQuery(sqlQuery);
            }
        }
    }
}
