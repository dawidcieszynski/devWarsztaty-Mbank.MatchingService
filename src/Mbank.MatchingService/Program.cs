using System;
using Microsoft.AspNetCore.Hosting;

namespace Mbank.MatchingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting up Matching Service...");

            var host = new WebHostBuilder()
            .UseKestrel()
            .UseUrls("http://localhost:5001")
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }
}
