﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotations_Assignment.CustomAttribute
{
    public class AgeAttributeValidation : ValidationAttribute
    {
        private int _minAge;
        public AgeAttributeValidation(int value)
        {
            _minAge = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is int)
                {
                    int minimumage = (int)value;
                    if (minimumage < _minAge)
                    {
                        return new ValidationResult("Minimum age must be " + _minAge);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}