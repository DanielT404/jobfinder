using JobFinder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class ApplicationsRepository
    {
        private readonly DBApplicationContext _dbContext;
        public ApplicationsRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public Application GetApplicationById(int applicationId)
        {
            return _dbContext.Applications
                .Include(a => a.JobFinderUser)
                .Include(a => a.JobListing)
                .Include(a => a.JobListing.Company)
                .Include(a => a.JobListing.Category)
                .FirstOrDefault(a => a.ApplicationId == applicationId);
        }

        public List<Application> GetApplicationsByUserId(int userId)
        {
            return _dbContext.Applications.Where(a => a.UserId == userId).Include(a => a.JobFinderUser).Include(a => a.JobListing).ToList();
        }

        public List<Application> GetApplicationsByHRUser(int HrUserId)
        {
            return 
                _dbContext.Applications
                .Include(a => a.JobFinderUser).Include(a => a.JobListing)
                .Include(a => a.JobListing.Company).Include(a => a.JobListing.Category)
                .Where(a => a.JobListing.UserId == HrUserId).ToList();
        }

        public void ModifyApplicationStatus(Application application)
        {
            _dbContext.Applications.Update(application);
            _dbContext.SaveChanges();
        }

        public int AddApplication(Application application)
        {
            _dbContext.Applications.Add(application);
            _dbContext.SaveChanges();
            return application.ApplicationId;
        }

        public bool UserAppliedAlready(int userId, int? jobListingId)
        {
            return _dbContext.Applications.Any(a => (a.UserId == userId && a.JobListingId == jobListingId));
        }
    }
}
