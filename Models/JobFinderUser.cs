using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class JobFinderUser
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email address is required.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        public int UserRoleId { get; set; }

        [Display(Name = "Role")]
        public UserRole UserRole { get; set; }

        [Display(Name = "Added at")]
        [DataType(DataType.DateTime)]
        public DateTime UserAddedAt { get; set; }

        [Display(Name = "Updated at")]
        [DataType(DataType.DateTime)]
        public DateTime UserUpdatedAt { get; set; }

        [Display(Name = "Approved?")]
        public bool IsApproved { get; set; }

        
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }

        public IEnumerable<CompanyUser> CompanyUsers { get; set; }

    }
}
