using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Models
{
    public partial class QuoteQuizDbContext : DbContext
    {
        public QuoteQuizDbContext()
        {
        }

        public QuoteQuizDbContext(DbContextOptions<QuoteQuizDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.Property(e => e.QuoteText)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Quotes__AuthorId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
