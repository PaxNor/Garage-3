using Garage_3.Auxiliary;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Garage_3.Validations
{
    public class PersonNumber : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {

            Regex rgx = new Regex(@"^\d{12}");

            if(value is string input)
            {
                input = StringFormatter.CompactPersonNumber(input);
                if(rgx.IsMatch(input) && input.Length == 12) return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
