using System.Collections.Generic;
using EUTool.Data;
using EUTool.View;
using System.Linq;
using System.Windows.Documents;

namespace EUTool.ViewModel
{
    public class MarketViewModel
    {
        AuctionDbContext dbContext;
        MarketView marketView = new MarketView();

        public IEnumerable<Auction> Auctions { get; set; }

        public MarketViewModel(AuctionDbContext dbContext)
        {
            this.dbContext = dbContext;
            GetAuctions();
        }

        private void GetAuctions()
        {
            Auctions = dbContext.Auctions.ToList();
            marketView.AuctionDG.ItemsSource = Auctions;
        }
    }
}