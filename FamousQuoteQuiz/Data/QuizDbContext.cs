using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Data
{
    public class QuizDbContext : IdentityDbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {
        }
    }
}
