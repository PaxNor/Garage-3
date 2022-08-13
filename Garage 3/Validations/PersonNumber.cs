using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Garage_3.Auxilary
{
    public class PersonNumber : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {

            Regex rgx = new Regex(@"^\d{10}");

            if(value is string input)
            {
                input = StringFormatter.CompactPersonNumber(input);
                if(rgx.IsMatch(input)) return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
