using JobFinder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data
{
    public class DBApplicationContext : DbContext
    {
        public DBApplicationContext(DbContextOptions<DBApplicationContext> options) : base(options) { }

        public DbSet<JobFinderUser> JobFinderUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationEducation> ApplicationEducations { get; set; }
        public DbSet<ApplicationSkill> ApplicationSkills { get; set; }
        public DbSet<ApplicationWorkExperience> ApplicationWorkExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // many-to-many relationship defined between user and company
            modelBuilder.Entity<CompanyUser>().HasKey(cu => new { cu.UserId, cu.CKCompanyId });
            modelBuilder.Entity<CompanyUser>()
                .HasOne<Company>(cu => cu.Company)
                .WithMany(cu => cu.CompanyUsers)
                .HasForeignKey(cu => cu.CKCompanyId);

            modelBuilder.Entity<CompanyUser>()
                .HasOne<JobFinderUser>(jfu => jfu.JobFinderUser)
                .WithMany(jfu => jfu.CompanyUsers)
                .HasForeignKey(jfu => jfu.UserId);

            // one-to-many and many-to-one relationship defined between category and joblisting
            modelBuilder.Entity<Category>()
                .HasMany(c => c.JobListings)
                .WithOne(jl => jl.Category);

            modelBuilder.Entity<JobListing>()
                .HasOne(jl => jl.Category)
                .WithMany(c => c.JobListings);

            // one-to-many and many-to-one relationship defined between company and joblisting
            modelBuilder.Entity<Company>()
                .HasMany(c => c.JobListings)
                .WithOne(jl => jl.Company);

            modelBuilder.Entity<JobListing>()
                .HasOne(jl => jl.Company)
                .WithMany(c => c.JobListings);

            // one-to-many and many-to-one relationship defined between joblisting and application
            modelBuilder.Entity<JobListing>()
                .HasMany(jl => jl.Applications)
                .WithOne(jl => jl.JobListing);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.JobListing)
                .WithMany(jl => jl.Applications);
        }

    }
}
