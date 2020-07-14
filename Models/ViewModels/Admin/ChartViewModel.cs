using JobFinder.Models.ChartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels.Admin
{
    public class ChartViewModel
    {
        public IEnumerable<ChartDTO> CategoryChartData { get; set; }
        public IEnumerable<ChartDTO> CompanyChartData { get; set; }
        public int NumberOfApplicationsReceived { get; set; }
        public int NumberOfJobListingsActive { get; set; }

        public int NumberOfJobListings { get; set; }
    }
}
