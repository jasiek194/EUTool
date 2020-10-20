using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EUTool.Data
{
    public class AuctionDbContext: DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Auction> Auctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasData(GetAuctions());
            base.OnModelCreating(modelBuilder);
        }

        private Auction[] GetAuctions()
        {
            return new Auction[] {
            new Auction { Id = 1, Name = "Belkar", Quantity = 3, Price = 5.21, Tax = 0.54, Value = 15 },
            new Auction { Id = 2, Name = "Pyrenite Ingot", Quantity = 1212, Price = 5.51, Tax = 1.00, Value = 21 },
        };
        }
    }
}
