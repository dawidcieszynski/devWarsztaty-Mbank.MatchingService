using System;
using System.Collections.Generic;

namespace Mbank.MatchingService
{
    public class Lender
    {
        public Lender(string name, decimal amount, decimal apr)
        {            
            Name = name;
            Amount = amount;
            APR = apr;
        }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public decimal APR { get; set; }

    }
    public class InMemoryMarketDataStoreProvider : IMarketDataStoreProvider
    {
        public List<Lender> OffersOnMarket()
        {
            return new List<Lender>
            {
                new Lender("Pawel", 500, 5.6m),
                new Lender("Pawel", 500, 5.6m),
                new Lender("Pawel", 500, 5.6m),
                new Lender("Pawel", 500, 5.6m),
            };
        }
    }
}