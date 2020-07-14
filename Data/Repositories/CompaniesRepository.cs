using JobFinder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class CompaniesRepository
    {
        private readonly DBApplicationContext _dbContext;

        public CompaniesRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public Company FindCompanyById(int? id)
        {
            return _dbContext.Companies.Include(c => c.JobListings).FirstOrDefault(c => c.CompanyId == id);
        }

        public bool CompanyExistsByName(string name)
        {
            return _dbContext.Companies.Any(e => e.Name == name);
        }

        public bool CompanyExists(int id)
        {
            return _dbContext.Companies.Any(e => e.CompanyId == id);
        }

        public List<Company> GetCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public List<Company> GetCompaniesAssignedToUser(int userId)
        {
            FormattableString query = $"SELECT * FROM dbo.Companies as c INNER JOIN dbo.CompanyUsers as cu ON cu.CKCompanyId = c.CompanyId WHERE cu.UserId = {userId}";
            return _dbContext.Companies.FromSqlInterpolated(query).ToList();
        }

        public Company GetCompanyByName(string name)
        {
            return _dbContext.Companies.FirstOrDefault(c => c.Name == name);
        }

        public int AddCompany(Company company)
        {
            _dbContext.Add(company);
            _dbContext.SaveChanges();
            return company.CompanyId;
        }

        public void UpdateCompany(Company company)
        {
            _dbContext.Update(company);
            _dbContext.SaveChanges();
        }

        public void DeleteCompany(Company company)
        {
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
        }
    }
}
