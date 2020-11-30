using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotations_Assignment.Models
{
    public class WebForm_Demo
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [DisplayName("Enter Your Name: ")]
        public string Name { get; set; }

        //Custom Validation
        [Required(ErrorMessage = "Age is mandatory")]
        [DataAnnotations_Assignment.CustomAttribute.AgeAttributeValidation(18)]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "Gender is mandatory")]
        public string Gender { get; set; }
        
        //Validation using Regular Expression
        [Required(ErrorMessage = "Mobile-No is mandatory")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}", ErrorMessage = "Not a valid Phone number")]
         public string MobileNo { get; set; }
        
        [Required(ErrorMessage = "Email-ID is mandatory")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string EmailID { get; set; }


    }
}