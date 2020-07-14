using JobFinder.Models.ChartModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories.Charts
{
    public class ChartsRepository
    {

        private readonly DBApplicationContext _dbContext;
        private readonly JobListingsRepository _jobListingsRepository;
        private readonly ApplicationsRepository _applicationsRepository;

        public ChartsRepository(DBApplicationContext context)
        {
            _dbContext = context;
            _jobListingsRepository = new JobListingsRepository(context);
            _applicationsRepository = new ApplicationsRepository(context);
        }

        public IEnumerable<ChartDTO> GetPopularCategories()
        {
            return _dbContext.JobListings
                .Include(jl => jl.Category)
                .GroupBy(c => c.Category.Name)
                .Select(jl => new ChartDTO
                {
                    CategoryName = jl.Key,
                    CategoryCount = jl.Count()
                })
                .OrderByDescending(jl => jl.CategoryCount)
                .Take(5)
                .ToList();
        }

        public IEnumerable<ChartDTO> GetDesiredCompanies()
        {
            return _dbContext.JobListings
                .Include(jl => jl.Company)
                .GroupBy(c => c.Company.Name)
                .Select(jl => new ChartDTO
                {
                    CompanyName = jl.Key,
                    CompanyCount = jl.Count()
                })
                .OrderByDescending(jl => jl.CompanyCount)
                .Take(5)
                .ToList();
        }

        public int GetNumberOfJobListings(int userId)
        {
            return _jobListingsRepository.GetJobListingsByUserId(userId).Count();
        }

        public int GetNumberOfJobListingsActive(int userId)
        {
            return _jobListingsRepository.GetActiveJobListingsByUserId(userId).Count();
        }

        public int GetNumberOfApplicationsReceived(int userId)
        {
            return _applicationsRepository.GetApplicationsByHRUser(userId).Count();
        }
    }
}
