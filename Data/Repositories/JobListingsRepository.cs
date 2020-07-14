using JobFinder.Models;
using JobFinder.Models.ChartModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class JobListingsRepository
    {
        private readonly DBApplicationContext _dbContext;
        public JobListingsRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public List<JobListing> GetAllJobListingsActive()
        {
            return _dbContext.JobListings.Include(jl => jl.Company).Include(jl => jl.Category).Where(jl => jl.IsActive == 1).ToList();
        }

        public List<JobListing> GetActiveJobListingsByUserId(int userId)
        {
            return _dbContext.JobListings.Include(jl => jl.Company).Include(jl => jl.Category).Where(jl => (jl.UserId == userId && jl.IsActive == 1)).ToList();
        }

        public List<JobListing> GetJobListingsByUserId(int userId)
        {
            return _dbContext.JobListings.Include(jl => jl.Company).Include(jl => jl.Category).Where(jl => jl.UserId == userId).ToList();
        }

        public List<JobListing> GetJobListingsByCategorySlug(string categorySlug)
        {
            return _dbContext.JobListings
                .Include(jl => jl.Company)
                .Include(jl => jl.Category)
                .Where(jl => (jl.Category.Slug == categorySlug && jl.IsActive == 1))
                .ToList();
        }

        public JobListing GetJobListingById(int? id)
        {
            return _dbContext.JobListings.Include(jl => jl.Category).Include(jl => jl.Company).Include(jl => jl.JobFinderUser).FirstOrDefault(m => m.JobListingId == id);
        }

        public List<Application> GetApplicationsByJobListing(int? id)
        {
            return _dbContext.Applications
                .Include(a => a.JobListing)
                .Include(a => a.JobListing.Company)
                .Include(a => a.JobListing.Category)
                .Include(a => a.JobFinderUser)
                .Where(a => a.JobListingId == id).ToList();
        }

        public int AddJobListing(JobListing jobListing, int userId)
        {
            _dbContext.JobListings.Add(jobListing);
            _dbContext.SaveChanges();
            return jobListing.JobListingId;
        }

        public void EditJobListing(JobListing jobListing)
        {
            _dbContext.Update(jobListing);
            _dbContext.SaveChanges();
        }

        public void DeleteJobListing(JobListing jobListing)
        {
            jobListing.IsActive = 0;
            _dbContext.JobListings.Update(jobListing);
            _dbContext.SaveChanges();
        }

        public bool isAllowedToModifyJobListing(int userId, int? companyId)
        {
            return _dbContext.CompanyUsers.Any(cu => (cu.CKCompanyId == companyId && cu.UserId == userId));
        }

        public bool isAllowedToSetTemplate(int userId, int? jobListingId)
        {
            return _dbContext.JobListings.Any(jl => (jl.UserId == userId && jl.JobListingId == jobListingId));
        }

        public bool JobListingExists(int? id)
        {
            return _dbContext.JobListings.Any(e => e.JobListingId == id);
        }
    }
}
