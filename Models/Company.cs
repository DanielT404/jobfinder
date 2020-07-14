using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "Enter company name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Enter company description")]
        [MinLength(5)]
        [MaxLength(1500)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        public IEnumerable<CompanyUser> CompanyUsers { get; set; }

        public ICollection<JobListing> JobListings { get; set; }


    }
}
