using JobFinder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class TemplatesRepository
    {
        private readonly DBApplicationContext _dbContext;

        public TemplatesRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public bool TemplateExists(int? jobListingId)
        {
            return _dbContext.Templates.Any(t => t.JobListingId == jobListingId);
        }

        public Template GetTemplateByJobId(int? jobId)
        {
            return _dbContext.Templates
                .Include(t => t.JobListing)
                .FirstOrDefault(t => t.JobListingId == jobId);
        }


        public void AddTemplate(Template template)
        {
            _dbContext.Templates.Add(template);
            _dbContext.SaveChanges();
        }

        public void EditTemplate(Template template)
        {
            _dbContext.Templates.Update(template);
            _dbContext.SaveChanges();
        }
    }
}
