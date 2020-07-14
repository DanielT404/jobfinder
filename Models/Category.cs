using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class Category
    {
        
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Category name")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Slug { get; set; }

        public ICollection<JobListing> JobListings { get; set; }
    }
}
