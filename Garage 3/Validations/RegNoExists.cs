using Garage_3.Data;
using System.ComponentModel.DataAnnotations;

namespace Garage_3
{
    public class RegNoExists : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var context = validationContext.GetRequiredService<Garage_3Context>();

            return base.IsValid(value, validationContext);
        }
    }
}
