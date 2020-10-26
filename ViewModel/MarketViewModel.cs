using EUTool.Data;
using EUTool.View;
using System.Linq;

namespace EUTool.ViewModel
{
    public class MarketViewModel
    {
        AuctionDbContext dbContext;
        MarketView marketView = new MarketView();

        public MarketViewModel(AuctionDbContext dbContext)
        {
            this.dbContext = dbContext;
            GetAuctions();
        }

        private void GetAuctions()
        {
            marketView.AuctionDG.ItemsSource = dbContext.Auctions.ToList();
        }
    }
}
