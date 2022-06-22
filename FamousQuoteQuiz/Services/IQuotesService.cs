using FamousQuoteQuiz.ViewModels;

namespace FamousQuoteQuiz.Services
{
    public interface IQuotesService
    {
        QuoteViewModel GetQuote();
    }
}
