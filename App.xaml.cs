using EUTool.Data;
using EUTool.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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


        public App()
        {
            ServiceCollection services = new ServiceCollection();

            var connectionString = "Data Source = " + DbCreator.DATABASE_FILE_PATH;
            services.AddDbContext<AuctionDbContext>(option => { option.UseSqlite(connectionString); });

            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            dbCreator.createConnectionToDatabase();
            dbCreator.createTable();
            dbCreator.fillTable();
            dbCreator.CloseConnection();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}