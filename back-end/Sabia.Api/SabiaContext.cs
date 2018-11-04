using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api
{
    public class SabiaContext : DbContext
    {
        public SabiaContext(DbContextOptions<SabiaContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseType> CourseTypes { get; set; }

        public DbSet<CourseClass> CourseClasses { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobRequirement> JobsRequirements { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string current = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = Environment.GetConfiguration();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
 
        }
    }
}
