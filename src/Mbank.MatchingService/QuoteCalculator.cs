using System;
using System.Collections.Generic;
using System.Linq;

namespace Mbank.MatchingService
{
    public class QuoteCalculator
    {
        private readonly IMarketDataStoreProvider _marketDataStoreProvider;

        private const int TimePeriod = 36;

        private const int MonthsInYear = 12;

        private const int HundredPercent = 100;

        public QuoteCalculator(IMarketDataStoreProvider marketDataStoreProvider)
        {
            _marketDataStoreProvider = marketDataStoreProvider;
        }

        public QuoteResponse Calculate(int amount)
        {
            var offers = _marketDataStoreProvider.OffersOnMarket();
            var sortedOffers = offers.OrderBy(x => x.APR);
            var matchedLenders = new List<Lender>();

            var currentAmount = (decimal)amount;
            foreach (var offer in sortedOffers)
            {
                if (currentAmount <= offer.Amount)
                {
                    matchedLenders.Add(new Lender(offer.Name, currentAmount, offer.APR));
                    break;
                }
                else
                {
                    currentAmount -= offer.Amount;
                    matchedLenders.Add(offer);
                }
            }

            var monthlyRepayments = matchedLenders.Sum(x=>CalculateMonthlyRepayment(x));            

            var quoteResponse = new QuoteResponse
            {
                AmountRequested = amount,
                TotalAmount = monthlyRepayments*TimePeriod,
                Apr = ComputeFinalRate(monthlyRepayments, amount),
                MonthlyRepaymentAmount = monthlyRepayments
            };

            return quoteResponse;
        }

        public decimal CalculateMonthlyRepayment(Lender matchedLender)
        {
            var r = matchedLender.APR / MonthsInYear;
            var v = (double)(1 + r);
            var xx = (decimal)(Math.Pow(v, -(TimePeriod)));
            var monthlyRepay = (r * matchedLender.Amount) / (1 - xx);
            return monthlyRepay;
        }

        private decimal ComputeFinalRate(decimal monthlyRepayments, int requestedLoanAmount)
        {
            var computedRate = (((HundredPercent * (monthlyRepayments * TimePeriod)) / requestedLoanAmount) - HundredPercent);
            return Math.Round(computedRate, 1);
        }
    }
}