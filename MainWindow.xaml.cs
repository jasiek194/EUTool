using EUTool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
