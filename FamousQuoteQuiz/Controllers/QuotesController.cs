using FamousQuoteQuiz.Services;

using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IQuotesService quotes;
        private readonly IAuthorsService authors;

        public QuotesController(IQuotesService quotes, IAuthorsService authors)
        {
            this.authors = authors;
            this.quotes = quotes;
        }

        public IActionResult RandomQuote()
        {
            var quote = this.quotes.GetQuote();

            if (quote == null)
            {
                return NotFound();
            }

            return this.View(quote);
        }
    }
}
