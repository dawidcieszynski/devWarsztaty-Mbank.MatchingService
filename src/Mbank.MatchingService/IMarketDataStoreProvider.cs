using System.Collections.Generic;

namespace Mbank.MatchingService
{
    public interface IMarketDataStoreProvider
    {
        List<Lender> OffersOnMarket();
    }
}