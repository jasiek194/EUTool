using EUTool.Data;
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
            GetAuctions();
        }

        private void GetAuctions()
        {
            AuctionDG.ItemsSource = dbContext.Auctions.ToList();
        }
    }
}
