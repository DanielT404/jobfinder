using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class ApplicationSkill
    {
        [Key]
        public int SkillId { get; set; }

        public string Name { get; set; }

        public Int16 Rating { get; set; }

        public string Description { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

    }
}
