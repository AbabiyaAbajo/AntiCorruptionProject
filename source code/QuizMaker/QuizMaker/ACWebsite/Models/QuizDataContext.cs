using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    public class QuizDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> Junction { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<SubmittedAnswers> SubmittedAnswers { get; set; }

        public DbSet<CensoredWord> CensoredWords { get; set; }

        public DbSet<AssignedQuizzes> assigned_quizzes { get; set; }

        public DbSet<Industry> Industries { get; set; }



        public QuizDataContext(DbContextOptions<QuizDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizQuestion>().HasKey(qq => new { qq.quizid, qq.questionid });
            //modelBuilder.Entity<QuizQuestion>().HasOne(qq => qq.quiz).WithMany(q => q.quizQuestions).HasForeignKey(qq => qq.quizid);
            //modelBuilder.Entity<QuizQuestion>().HasOne(qq => qq.question).WithMany(q => q.quizQuestions).HasForeignKey(qq => qq.questionid);
        }
    }
}
