using System.Linq;

using FamousQuoteQuiz.Models;
using FamousQuoteQuiz.ViewModels;

namespace FamousQuoteQuiz.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly QuoteQuizDbContext data;

        public AuthorsService(QuoteQuizDbContext data)
        {
            this.data = data;
        }

        public AnswerViewModel CheckAuthor(int? authorId, int? randomAuthorId, int quoteId, string buttonValue)
        {
            var answerText = "";

            if ((buttonValue == "Yes" && authorId == randomAuthorId) || (buttonValue == "No" && authorId != randomAuthorId))
            {
                answerText = "Correct! The right answer is...";
                
            }

            else
            {
                answerText = "Sorry, you are wrong! The right answer is...";
            }

            var authorName = this.data.Authors
                .Where(a => a.AuthorId == authorId)
                .Select(a => a.AuthorName)
                .FirstOrDefault();

            var quoteText = this.data.Quotes
                .Where(q => q.QuoteId == quoteId)
                .Select(q => q.QuoteText)
                .FirstOrDefault();

            var answer = new AnswerViewModel
            {
                AnswerText = answerText,
                AuthorId = authorId,
                AuthorName = authorName,
                QuoteText = quoteText
            };

            return answer;
        }
    }
}
