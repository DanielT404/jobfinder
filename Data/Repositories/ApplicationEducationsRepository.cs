using JobFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class ApplicationEducationsRepository
    {
        private readonly DBApplicationContext _dbContext;
        public ApplicationEducationsRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public ApplicationEducation GetApplicationEducationForApplication(int applicationId)
        {
            return _dbContext.ApplicationEducations.FirstOrDefault(we => we.ApplicationId == applicationId);
        }
    }
}
