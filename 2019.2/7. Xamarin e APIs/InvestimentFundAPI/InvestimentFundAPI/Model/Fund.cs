using System;

namespace InvestimentFundAPI.Model
{
    public class Fund
    {
        public int FundId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
