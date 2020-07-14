using JobFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class ApplicationSkillsRepository
    {
        private readonly DBApplicationContext _dbContext;
        public ApplicationSkillsRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public ApplicationSkill GetApplicationSkillForApplication(int applicationId)
        {
            return _dbContext.ApplicationSkills.FirstOrDefault(we => we.ApplicationId == applicationId);
        }
    }
}
