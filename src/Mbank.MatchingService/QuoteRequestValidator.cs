namespace Mbank.MatchingService
{
    public static class QuoteRequestValidator
    {
        public static bool Validate(QuoteRequest QuoteRequest)
        {
            if (QuoteRequest.Amount % 100 != 0 || QuoteRequest.Amount < 1000 || QuoteRequest.Amount > 15000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class ValidationError
    {
        public string Message { get; set; }
    }
}