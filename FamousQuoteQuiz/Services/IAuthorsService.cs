using FamousQuoteQuiz.ViewModels;

namespace FamousQuoteQuiz.Services
{
    public interface IAuthorsService
    {
        AnswerViewModel CheckAuthor(int? authorId, int? randomAuthorId, int quoteId, string buttonValue);
    }
}
