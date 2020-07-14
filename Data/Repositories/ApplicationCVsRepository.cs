using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class ApplicationCVsRepository
    {
        private readonly DBApplicationContext _dbContext;
        public ApplicationCVsRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }
    }
}
