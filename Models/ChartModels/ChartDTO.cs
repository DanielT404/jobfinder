using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ChartModels
{
    public class ChartDTO
    {
        
        // properties for most desired companies chart
        public string CompanyName { get; set; }
        public int CompanyCount { get; set; }

        // properties for most popular job industries
        public string CategoryName { get; set; }
        public int CategoryCount { get; set; }
    }
}
