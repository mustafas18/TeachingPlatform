using Core.Entities;
using Core.Entities.CourseAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Section>  SectionsSites { get; set; }
        public DbSet<Session> Sessions { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<TeacherRequest> TeacherRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To add migration uncoment the second line. and then run the second command:
            //1. optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bahar20;Trusted_Connection=True;MultipleActiveResultSets=true");
            //2. Add-Migration initial2 -Project DAL

            if (!optionsBuilder.IsConfigured)
            {
                //throw new NullReferenceException("The database is not configured.");
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TeachingPlatform;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Lesson>()
            //    .HasData(new Lesson("IELTS Speaking", "IELTS Speaking", "IELTS Speaking Intermediate")
            //            , new Lesson("IELTS Writing", "IELTS Writing", "IELTS Writing Beginer")

            //            , new Teacher("zahrabazghandi", "زهرا بازقندی", "Zahra Bazghandi")

            //            , new Student("mustafas18")
            //    );

        }
    }
}
