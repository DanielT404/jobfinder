using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels.Admin
{
    public class JobListingTemplateViewModel
    {
        [Key]
        public int TemplateId { get; set; }

        [Display(Name = "Would you like to allow candidates to write their education?")]
        [Required]
        public bool Education { get; set; }

        [Display(Name = "Would you like to allow candidates to write their work experience?")]
        [Required]
        public bool WorkExperience { get; set; }

        [Display(Name = "Would you like to allow candidates to write their skills?")]
        [Required]
        public bool Skills { get; set; }


        [Display(Name = "Would you like to allow candidates to write anything extra?")]
        [Required]
        public bool OtherNotes { get; set; }

        public int JobListingId { get; set; }
        [ForeignKey("JobListingId")]
        public JobListing JobListing { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime TemplateAddedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TemplateUpdatedAt { get; set; }
    }
}
