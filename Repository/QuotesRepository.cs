using System.Collections.Generic;
using System.Linq;
using Quotes_API.Data;
using Quotes_API.Entity;
using Quotes_API.Interfaces;

namespace Quotes_API.Repository
{
    public class QuotesRepository : IQuotesRepository
    {
        public QuotesContext _context { get; }
        public QuotesRepository(QuotesContext context)
        {
            _context = context;
        }

        public IReadOnlyList<Quote> GetAll()
        {
            return _context.Quotes.ToList();
        }
    }
}