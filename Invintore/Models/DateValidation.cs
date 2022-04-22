using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Invintore.Models
{
    public class DateValidation :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Date = Convert.ToDateTime(value);
            if (Date>DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(base.ErrorMessage);
            }
        }
    }
}