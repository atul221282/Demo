using System.Collections.Generic;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Model.Repository
{
    public interface ISecurityRepository
    {
        Security GetSecurity(string symbol);
        List<TickerQuote> GetSecurityTickerQuotes();
        OperationStatus UpdateSecurities();
    }
}