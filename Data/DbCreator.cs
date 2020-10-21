using System;
using System.Data.SQLite;
using System.IO;

namespace EUTool.Data
{
    public class DbCreator
    {
        static string WORKING_DIRECTORY = Environment.CurrentDirectory;
        static string MAIN_PROJECT_DIRECTORY = Directory.GetParent(WORKING_DIRECTORY).Parent.Parent.FullName;
        static string DB_PATH = MAIN_PROJECT_DIRECTORY + "\\db\\";
        static string DATABASE_NAME = "BazaTestowaSQlite.db";
        public static string DATABASE_FILE_PATH;

        SQLiteConnection dbConnection = new SQLiteConnection("Data Source = " + DB_PATH + DATABASE_NAME + ";Version=3;New=True;Compress=True;");
        SQLiteCommand command = new SQLiteCommand();
        string sqlQuery;

        public void createDbFile()
        {
            if (!string.IsNullOrEmpty(DB_PATH) && !Directory.Exists(DB_PATH))
                Directory.CreateDirectory(DB_PATH);

            DATABASE_FILE_PATH = DB_PATH + DATABASE_NAME;

            if (!File.Exists(DATABASE_FILE_PATH))
            {
                SQLiteConnection.CreateFile(DATABASE_NAME);
            }
        }

        public void createTable()
        {
            if (!checkIfExist("Auctions"))
            {
                sqlQuery = "CREATE TABLE Auctions(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name STRING, Quantity DOUBLE, Price DOUBLE, Tax DOUBLE, Value DOUBLE)";
                executeQuery(sqlQuery);
            }
        }

        public bool checkIfExist(string tableName)
        {
            command.CommandText = ("SELECT name FROM sqlite_master WHERE name ='" + tableName + "'");
           /* createConnectionToDatabase();*/
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

                sqlQuery = "INSERT INTO Auctions (NAME,Quantity, Price, Tax, Value) values ('Lysterium Ingot', 3121, 1878.50,1.54,9999)";
                executeQuery(sqlQuery);
            }
        }

        public void createConnectionToDatabase()
        {
            command.Connection = dbConnection;
            dbConnection.Open();
        }
    }
}
