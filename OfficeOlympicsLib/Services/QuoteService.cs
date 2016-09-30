using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOlympicsLib.Models;

namespace OfficeOlympicsLib.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly Random _rng;

        public QuoteService()
        {
            _rng = new Random();
        }

        public Quote GetRandomQuote()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                int minQuoteId = context.Quotes.Min(obj => obj.Id);
                int maxQuoteId = context.Quotes.Max(obj => obj.Id);
                int randomQuoteId = _rng.Next(minQuoteId, maxQuoteId + 1);

                return context.Quotes.Single(obj => obj.Id == randomQuoteId);
            }
        }
    }
}
