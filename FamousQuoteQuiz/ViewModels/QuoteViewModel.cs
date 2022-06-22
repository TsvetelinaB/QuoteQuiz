namespace FamousQuoteQuiz.ViewModels
{
    public class QuoteViewModel
{
        public int Id { get; set; }

        public string QuoteText { get; set; }
        
        public int? AuthorId { get; set; }

        public string AuthorName { get; set; }

        public int? RandomAuthorId { get; set; }

        public string RandomAuthorName { get; set; }

        public string AnswerText { get; set; }
    }
}
