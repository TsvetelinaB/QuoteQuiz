using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FamousQuoteQuiz.ViewModels
{
    public class QuoteViewModel
{
        public int Id { get; set; }

        public string QuoteText { get; set; }

        public int?  AuthorId { get; set; }
    }
}
