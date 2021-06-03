using API.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasOne(e => e.questionnaire)
                .WithMany(c => c.questions);
            modelBuilder.Entity<Result>()
        .HasKey(c => new { c.userId, c.questionnaireId});
            modelBuilder.Entity<Result>()
                .HasOne(e => e.questionnaire)
                .WithMany(c => c.results);
            modelBuilder.Entity<Result>()
                .HasOne(e => e.user)
                .WithMany(c => c.results);
        }
    }
}