using FamousQuoteQuiz.Services;

using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IQuotesService quotes;

        public QuotesController(IQuotesService quotes)
        {
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

        public IActionResult RandomQuoteTriple()
        {
            var quote = this.quotes.GetQuoteTripleAnswer();

            if (quote == null)
            {
                return NotFound();
            }

            return this.View(quote);
        }
    }
}
