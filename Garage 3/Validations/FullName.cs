using Garage_3.Models;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.Validations
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
