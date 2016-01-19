using System.Collections.Generic;

namespace AccountAtAGlance.Model.Repository
{
    public interface IMarketsAndNewsRepository
    {
        MarketQuotes GetMarkets();
        List<TickerQuote> GetMarketTickerQuotes();
        List<string> GetMarketNews();
    }
}