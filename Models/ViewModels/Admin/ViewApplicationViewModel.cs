using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels.Admin
{
    public class ViewApplicationViewModel
    {
        public Application Application { get; set; }
        public ApplicationEducation ApplicationEducation { get; set; }
        public ApplicationSkill ApplicationSkill { get; set; }
        public ApplicationWorkExperience ApplicationWorkExperience { get; set; }
        public string OtherNotes { get; set; }
        public string Status { get; set; }
        public DateTime ApplicationWrittenAt { get; set; }
    }
}
