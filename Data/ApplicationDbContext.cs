using ElectroLab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectroLab.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
   
            public DbSet<Test> Tests { get; set; }
            public DbSet<Question> Questions { get; set; }
            public DbSet<Submission> Submissions { get; set; }  
            public DbSet<SubmissionAnswer> SubmissionAnswers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly configure the foreign key relationships with NoAction for cascade delete

            // Submissions -> Test
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Test)  // A Submission has one Test
                .WithMany()  // Test can have many Submissions (no navigation property in Test)
                .HasForeignKey(s => s.TestId)  // Foreign key is TestId
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            // SubmissionAnswers -> Question
            modelBuilder.Entity<SubmissionAnswer>()
                .HasOne(sa => sa.Question)  // A SubmissionAnswer has one Question
                .WithMany()  // Question can have many SubmissionAnswers (no navigation property in Question)
                .HasForeignKey(sa => sa.QuestionId)  // Foreign key is QuestionId
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            // SubmissionAnswers -> Submission
            modelBuilder.Entity<SubmissionAnswer>()
                .HasOne(sa => sa.Submission)  // A SubmissionAnswer has one Submission
                .WithMany()  // Submission can have many SubmissionAnswers (no navigation property in Submission)
                .HasForeignKey(sa => sa.SubmissionId)  // Foreign key is SubmissionId
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            // Questions -> Test
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Test)  // A Question has one Test
                .WithMany(t => t.Questions)  // A Test has many Questions
                .HasForeignKey(q => q.TestId)  // Foreign key is TestId
                .OnDelete(DeleteBehavior.Cascade);  // Disable cascade delete
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
