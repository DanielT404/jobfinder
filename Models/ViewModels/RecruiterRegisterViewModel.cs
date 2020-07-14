using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels
{
    public class RecruiterRegisterViewModel
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

        [Display(Name = "Enter company name")]
        [Required(ErrorMessage = "Company name is required.")]
        public string Name { get; set; }

        [Display(Name = "Enter a brief company description")]
        [MinLength(5)]
        [MaxLength(1500)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Company description is required.")]
        public string Description { get; set; }

        [Display(Name = "Enter the foundation date of the company")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Foundation date is required")]
        public DateTime StartDate { get; set; }
    }
}
