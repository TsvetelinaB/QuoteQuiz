using FamousQuoteQuiz.Services;

using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService authors;

        public AuthorsController(IAuthorsService authors)
        {
            this.authors = authors;
        }

        public IActionResult CheckAuthor(int? authorId, int? randomAuthorId, int quoteId, string buttonValue)
        {
            var answer = this.authors.CheckAuthor(authorId, randomAuthorId, quoteId, buttonValue);

            return View(answer);
        }
    }
}
