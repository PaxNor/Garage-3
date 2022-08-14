using Garage_3.Auxiliary;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Garage_3.Validations
{
    public class AgeVerification : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {

            if (value is string input) {
                input = StringFormatter.CompactPersonNumber(input);
                if(ageCheck(input)) return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }

        private static bool ageCheck(string personNumber) {
            DateTime birthDate;
            DateTime presentDate;
            int yearsElapsed;
            int year, month, day;

            string yearString = personNumber.Substring(0, 4);
            string monthString = personNumber.Substring(4, 2);
            string dayString = personNumber.Substring(6, 2);

            // maybe throw exception
            if (int.TryParse(yearString, out year) == false) return false;
            if (int.TryParse(monthString, out month) == false) return false;
            if (int.TryParse(dayString, out day) == false) return false;

            birthDate = new DateTime(year, month, day);
            presentDate = DateTime.Now;
            yearsElapsed = presentDate.Year - birthDate.Year;

            if (birthDate.Month == presentDate.Month &&
               presentDate.Day < birthDate.Day ||
               presentDate.Month < birthDate.Month) {
                yearsElapsed--;
            }

            if (yearsElapsed >= 18) {
                return true;
            }

            return false;
        }

    }
}
