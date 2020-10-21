using EUTool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EUTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        private DbCreator dbCreator = new DbCreator();

/*        string dbPath = Environment.CurrentDirectory + "\\Data";
        string dbFilePath;*/



        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<AuctionDbContext>(option =>
            {
                option.UseSqlite("Data Source = EUToolDevDB.db");
            });

            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {

            /*            if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
                            Directory.CreateDirectory(dbPath);
                        dbFilePath = dbPath + "\\EUToolDevDB.db";

                        if (!File.Exists(dbFilePath))
                        {

                            SQLiteConnection.CreateFile("EUToolDevDB.db");
                        }*/
            dbCreator.createDbFile();
            dbCreator.createTable();
            dbCreator.fillTable();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

        }
        
    }
}
