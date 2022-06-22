using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FamousQuoteQuiz.ViewModels;

namespace FamousQuoteQuiz.Services
{
    public interface IQuotesService
    {
        QuoteViewModel GetQuote();
    }
}
