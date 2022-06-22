using System;
using System.Linq;

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
            var rndQ = new Random();
            var rndQuoteNum = rndQ.Next(1, quotesCount + 1);

            var quote = this.data.Quotes
                .Where(q => q.QuoteId == rndQuoteNum)
                .Select(q => new QuoteViewModel
                {
                    Id = q.QuoteId,
                    QuoteText = q.QuoteText,
                    AuthorId = q.AuthorId,
                    AuthorName = q.Author.AuthorName,
                }).FirstOrDefault();

            var authorssCount = this.data.Authors.Count();
            var rndA = new Random();
            var rndAuthorNum = rndA.Next(1, authorssCount + 1);

            quote.RandomAuthorId = rndAuthorNum;
            quote.RandomAuthorName = this.data.Authors
                .Where(a => a.AuthorId == rndAuthorNum)
                .Select(q => q.AuthorName)
                .FirstOrDefault();

            return quote;
        }
    }
}
