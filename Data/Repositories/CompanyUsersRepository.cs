using JobFinder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class CompanyUsersRepository
    {
        private readonly DBApplicationContext _dbContext;
        public CompanyUsersRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public List<CompanyUser> GetAllCompanyUsers()
        {
            return _dbContext.CompanyUsers.Include(c => c.Company).Include(c => c.JobFinderUser).ToList();
        }

        public void AssignUserToCompany(CompanyUser companyUser)
        {

            _dbContext.Add(companyUser);
            _dbContext.SaveChanges();
        }

        public CompanyUser GetUserByUserIdAndCompanyId(int? userId, int? companyId)
        {
            return _dbContext.CompanyUsers
                .Include(c => c.Company)
                .Include(c => c.JobFinderUser)
                .FirstOrDefault(m => m.UserId == userId && m.CKCompanyId == companyId);
        }

        public void UnassignUserToCompany(int? userId, int? companyId)
        {
            _dbContext.Database.ExecuteSqlInterpolated($"DELETE FROM CompanyUsers WHERE UserId = {userId} AND CKCompanyId = {companyId}");
            _dbContext.SaveChanges();
        }

        public bool CompanyUserExists(int userId, int companyId)
        {
            return _dbContext.CompanyUsers.Any(cu => (cu.UserId == userId && cu.CKCompanyId == companyId));
        }
    }
}
