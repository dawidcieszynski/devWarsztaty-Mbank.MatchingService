using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Mbank.MatchingService
{
    public class QuoteRequest
    {
        public int Amount { get; set; }
    }    

    public class QuoteCalculatorModule
    {
        public Task Calculate(HttpContext context)
        {
            var requestBody = this.DeserializeAsync<QuoteRequest>(context);
            if (!QuoteRequestValidator.Validate(requestBody))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var validationError = new ValidationError
                {
                    Message = "Requested amount doesn't meet criteria, has to be between 1000 and 15000, and multiply of 100"
                };
                var response = JsonConvert.SerializeObject(validationError);
                return context.Response.WriteAsync(response);
            }
            else
            {
                var quoteCalculator = new QuoteCalculator(new InMemoryMarketDataStoreProvider());
                var quoteResponse = quoteCalculator.Calculate(requestBody.Amount);                
                var jsonResponse = JsonConvert.SerializeObject(quoteResponse);
                return context.Response.WriteAsync(jsonResponse);
            }
        }

        public T DeserializeAsync<T>(HttpContext context) where T : class
        {
            if (context.Request.Body.CanRead)
            {
                using (var sr = new StreamReader(context.Request.Body))
                using (var jr = new JsonTextReader(sr))
                {
                    return new JsonSerializer().Deserialize<T>(jr);
                }
            }
            else
            {
                return null;
            }
        }
    }
}