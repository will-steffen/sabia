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

        public DbSet<User> User { get; set; }

        public DbSet<Skill> Skill { get; set; }

        public DbSet<UserSkill> UserSkill { get; set; }

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
            builder.Entity<Skill>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
