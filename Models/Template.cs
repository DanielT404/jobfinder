using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class Template
    {
        [Key]
        public int TemplateId { get; set; }

        [Display(Name = "Would you like to allow candidates to write their education?")]
        [Required]
        public byte Education { get; set; }

        [Display(Name = "Would you like to allow candidates to write their work experience?")]
        [Required]
        public byte WorkExperience { get; set; }

        [Display(Name = "Would you like to allow candidates to write their skills?")]
        [Required]
        public byte Skills { get; set; }


        [Display(Name = "Would you like to allow candidates to write anything extra?")]
        [Required]
        public byte OtherNotes { get; set; }

        public int JobListingId { get; set; }
        [ForeignKey("JobListingId")]
        public JobListing JobListing { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public JobFinderUser JobFinderUser { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TemplateAddedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TemplateUpdatedAt { get; set; }

    }
}
