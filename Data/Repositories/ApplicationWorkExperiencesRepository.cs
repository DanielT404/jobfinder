using JobFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class ApplicationWorkExperiencesRepository
    {
        private readonly DBApplicationContext _dbContext;
        public ApplicationWorkExperiencesRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public ApplicationWorkExperience GetApplicationWorkExperienceForApplication(int applicationId)
        {
            return _dbContext.ApplicationWorkExperiences.FirstOrDefault(we => we.ApplicationId == applicationId);
        }
    }
}
