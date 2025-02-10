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
            public DbSet<Report> Reports { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Submissions -> Test
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Test)  
                .WithMany()  
                .HasForeignKey(s => s.TestId)  
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

            // Reports -> Course
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Course)  
                .WithMany()  
                .HasForeignKey(r => r.CourseId)  
                .OnDelete(DeleteBehavior.NoAction);
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
