using System.ComponentModel.DataAnnotations;

namespace Tech.Models
{
    public class DivideHoursByThreeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            // Course course = (Course)validationContext.ObjectInstance;
            // Course course = (Course)validationContext.ObjectInstance;

            //if (value is float originalHours)
            //{
            //    course.Hours = originalHours / 3;
            //    return ValidationResult.Success;
            //}

            //return new ValidationResult("Invalid Hours value");

            if (value == null)
                return new ValidationResult("Hours is required.");

            if (float.TryParse(value.ToString(), out float hours))
            {
                if (hours % 3 == 0)
                    return ValidationResult.Success;

                return new ValidationResult("Hours must be divisible by 3.");
            }

            return new ValidationResult("Invalid Hours value.");

        }
    }
}
