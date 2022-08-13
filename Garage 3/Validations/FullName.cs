using Garage_2._0.Auxilary;
using Garage_2._0.Models;
using Garage_2._0.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Garage_2._0.Validations
{
    public class FullName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string input)
            {
                var model = validationContext.ObjectInstance as Member;

                if(model is not null)
                {
                    if(model.FirstName != input)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
                
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
