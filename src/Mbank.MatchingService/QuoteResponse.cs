namespace Mbank.MatchingService
{
    public class QuoteResponse
    {
        public decimal AmountRequested { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Apr { get; set; }

        public decimal MonthlyRepaymentAmount { get; set; }

    }
}