using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class CompanyUser
    {
        public int CKCompanyId { get; set; }
        public Company Company { get; set; }

        public int UserId { get; set; }
        public JobFinderUser JobFinderUser { get; set; }
    }
}
