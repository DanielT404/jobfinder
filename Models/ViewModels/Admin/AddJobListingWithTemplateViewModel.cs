using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels.Admin
{
    public class AddJobListingWithTemplateViewModel
    {
        public int JobListingId { get; set; }

        [Display(Name = "Job Listing Title")]
        [Required(ErrorMessage = "Job Listing Title is required.")]
        public string Title { get; set; }

        [Display(Name = "Job Listing Position")]
        [Required(ErrorMessage = "Job Listing Position is required.")]
        public string Position { get; set; }

        [Display(Name = "Job Listing Type")]
        [Required(ErrorMessage = "Job Listing Type is required.")]
        public string Type { get; set; }

        [Display(Name = "Job Listing Region")]
        [Required(ErrorMessage = "Job Listing Region is required.")]
        public string Region { get; set; }

        [Display(Name = "Job Listing Location")]
        [Required(ErrorMessage = "Job Listing Location is required.")]
        public string Location { get; set; }

        [Display(Name = "Job Listing Description")]
        [MinLength(5)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Job Listing Description is required.")]
        public string Description { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public JobFinderUser JobFinderUser { get; set; }
        
        [Display(Name = "Is job listing active?")]
        [Required]
        public bool JobListingIsActive { get; set; }


        /* Template */

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

        [Display(Name = "Would you like to make this job listing active?")]
        [Required]
        public bool IsActive { get; set; }

        public int TemplateId { get; set; }
    }
}
