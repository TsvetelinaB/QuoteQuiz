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
           
            if (answer == null)
            {
                return NotFound();
            }

            return View("AuthorYesNo", answer);
        }

        public IActionResult CorrectAuthor(int? authorId, int quoteId)
        {
            var answer = this.authors.CorrectAuthor(authorId, quoteId);

            if (answer == null)
            {
                return NotFound();
            }

            return View("AuthorTriple", answer);
        }

        public IActionResult WrongAuthor(int? authorId, int quoteId)
        {
            var answer = this.authors.WrongAuthor(authorId, quoteId);

            if (answer == null)
            {
                return NotFound();
            }

            return View("AuthorTriple", answer);
        }
    }
}
