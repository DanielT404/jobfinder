using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels.Admin
{
    public class UserAdminRegisterViewModel
    {
        [Display(Name = "Insert your first name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Insert your last name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Insert your email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Display(Name = "Insert your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; }

        [Display(Name = "Insert your phone number")]
        [Required(ErrorMessage = "Phone number is required.")]

        public string PhoneNumber { get; set; }

        [Display(Name = "Pick one of the available roles")]
        [Required(ErrorMessage = "Role setting is required.")]
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }

        public DateTime UserAddedAt { get; set; }

        public DateTime UserUpdatedAt { get; set; }
    }
}
