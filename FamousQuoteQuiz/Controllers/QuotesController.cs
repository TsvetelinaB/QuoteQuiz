using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FamousQuoteQuiz.Models;
using FamousQuoteQuiz.Services;
using FamousQuoteQuiz.ViewModels;

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

        public IActionResult Get()
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
