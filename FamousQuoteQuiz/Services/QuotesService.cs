using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FamousQuoteQuiz.Models;
using FamousQuoteQuiz.ViewModels;

namespace FamousQuoteQuiz.Services
{
    public class QuotesService : IQuotesService
    {
        private readonly QuoteQuizDbContext data;

        public QuotesService(QuoteQuizDbContext data)
        {
            this.data = data;
        }

        public QuoteViewModel GetQuote()
        {
            var quotesCount = this.data.Quotes.Count();
            var rnd = new Random();
            var rndQuote = rnd.Next(1, quotesCount + 1);

            var quote = this.data.Quotes
                .Where(q => q.QuoteId == rndQuote)
                .Select(q => new QuoteViewModel
                {
                    Id = q.QuoteId,
                    QuoteText = q.QuoteText,
                    AuthorId = q.AuthorId
                }).FirstOrDefault();

            return quote;
        }
    }
}
