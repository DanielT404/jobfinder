using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "Insert your email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string UserEmail { get; set; }

        [Display(Name = "Insert your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string UserPassword { get; set; }
    }
}
