using System.Collections.Generic;
using Quotes_API.Entity;

namespace Quotes_API.Interfaces
{
    public interface IQuotesRepository
    {
        IReadOnlyList<Quote> GetAll();  
    }
}