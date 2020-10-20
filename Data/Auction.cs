using System;
using System.Collections.Generic;
using System.Text;

namespace EUTool.Data
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public double Value { get; set; }
    }
}
