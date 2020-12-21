using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_SC.Models
{
    public class Signup
    {
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email-ID is mandatory")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email_id { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile-No is mandatory")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}", ErrorMessage = "Not a valid Phone number")]
        public int Mobile_no { get; set; }
    }
}