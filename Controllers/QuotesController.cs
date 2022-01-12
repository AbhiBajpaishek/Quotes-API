using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quotes_API.Entity;
using Quotes_API.Interfaces;

namespace Quotes_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        public IQuotesRepository _quotesRepo { get; }

        public QuotesController(IQuotesRepository quotesRepo)
        {
            _quotesRepo= quotesRepo;
        }

        [HttpGet]
        [Authorize]
        public IReadOnlyList<Quote> GetAll()
        {
           return _quotesRepo.GetAll();
        }
    }
}