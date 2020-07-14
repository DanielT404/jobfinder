using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        public int JobListingId { get; set; }
        [ForeignKey("JobListingId")]
        public JobListing JobListing { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public JobFinderUser JobFinderUser { get; set; }

        public string Status { get; set; }

        public string OtherNotes { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ApplicationWrittenAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ApplicationUpdatedAt { get; set; }


    }
}
