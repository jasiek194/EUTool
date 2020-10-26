using EUTool.Data;
using EUTool.ViewModel;
using System.Linq;
using System.Windows;

namespace EUTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuctionDbContext dbContext;
        public MainWindow(AuctionDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
        }

        private void MarketMenu_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new MarketViewModel(dbContext);
        }
    }
}
