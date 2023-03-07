using Core.Entities;
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
        public DbSet<CourseCategory> Categories { get; set; }
        //public DbSet<Section>  Sections { get; set; }
        public DbSet<Session> Sessions { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<TeacherRequest> TeacherRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // EntityFrameworkCore\Add-Migration <Migration-Name> -Project Infrastructure

            if (!optionsBuilder.IsConfigured)
            {
                //throw new NullReferenceException("The database is not configured.");
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TeachingPlatform;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Lesson>()
                .HasData(new Lesson(1,"IELTS Speaking", "IELTS Speaking", "IELTS Speaking")
                        , new Lesson(2,"IELTS Writing", "IELTS Writing", "IELTS Writing")

                );
            modelBuilder.Entity<CourseCategory>()
              .HasData(new CourseCategory { Id = 1, NameEn = "IELTS", NameFa = "IELTS" });

            modelBuilder.Entity<Teacher>()
              .HasData(new Teacher { Id = 1,  UserName="zahra_bazghandi",FullNameEn = "Zahra Bazghandi",  FullNameFa = "زهرا بازقندی" }



              );

        }
    }
}
