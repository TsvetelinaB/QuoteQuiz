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

            var rndAuthorNum = GetRandomAuthorId();

            quote.RandomAuthorId = rndAuthorNum;
            quote.RandomAuthorName = GetAuthorName(rndAuthorNum);

            return quote;
        }       

        public QuoteViewModel GetQuoteTripleAnswer()
        {
            var quote = GetQuote();

            var authorId = quote.AuthorId;
            var randomAuthorId = quote.RandomAuthorId;

            if(authorId == randomAuthorId)
            {
                while(authorId == randomAuthorId)
                {
                    randomAuthorId = GetRandomAuthorId();
                }

                quote.RandomAuthorId = randomAuthorId;
                quote.RandomAuthorName = GetAuthorName(randomAuthorId);
            }

            var secondRandomAuthorId = GetRandomAuthorId();

            if(secondRandomAuthorId == authorId || secondRandomAuthorId == randomAuthorId)
            {
                while (secondRandomAuthorId == authorId || secondRandomAuthorId == randomAuthorId)
                {
                    secondRandomAuthorId = GetRandomAuthorId();
                }                
            }

            quote.SecondRandomAuthorId = secondRandomAuthorId;
            quote.SecondRandomAuthorName = GetAuthorName(secondRandomAuthorId);

            return quote;
        }

        private int? GetRandomAuthorId()
        {
            var authorssCount = this.data.Authors.Count();
            var rndA = new Random();
            var rndAuthorNum = rndA.Next(1, authorssCount + 1);
            return rndAuthorNum;
        }

        private string GetAuthorName(int? rndAuthorNum)
        {
            var name = this.data.Authors
            .Where(a => a.AuthorId == rndAuthorNum)
            .Select(q => q.AuthorName)
            .FirstOrDefault();

            return name;
        }
    }
}
