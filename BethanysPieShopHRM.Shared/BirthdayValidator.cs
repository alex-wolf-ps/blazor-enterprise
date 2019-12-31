using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class BirthdayValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
        {
            DateTime birthdate;

            if (DateTime.TryParse(value.ToString(), out birthdate))
            {
                if(birthdate > DateTime.Now.AddYears(-18))
                {
                    return new ValidationResult("Employee must be at least 18.", new[] { validationContext.MemberName });
                } else
                {
                    return null;
                }
            } else
            {
                return new ValidationResult("Invalid birth date.", new[] { validationContext.MemberName });
            }
        }
    }
}
