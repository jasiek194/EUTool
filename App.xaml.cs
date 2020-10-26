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

            services.AddDbContext<AuctionDbContext>(option =>
            {
                option.UseSqlite("Data Source = " + DbCreator.DATABASE_FILE_PATH);
            });

            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            dbCreator.createDbFile();
            dbCreator.createConnectionToDatabase();
            dbCreator.createTable();
            dbCreator.fillTable();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

        }
        
    }
}
