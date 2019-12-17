using System;

namespace InvestmentFundApp.Model
{
    public class Fund
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
