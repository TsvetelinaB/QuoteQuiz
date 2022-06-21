using System;
using System.Collections.Generic;

#nullable disable

namespace FamousQuoteQuiz.Models
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public string QuoteText { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
