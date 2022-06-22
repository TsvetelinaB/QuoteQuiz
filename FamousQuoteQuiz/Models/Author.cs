using System.Collections.Generic;

namespace FamousQuoteQuiz.Models
{
    public partial class Author
    {
        public Author()
        {
            Quotes = new HashSet<Quote>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
