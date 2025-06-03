using System.ComponentModel.DataAnnotations;

namespace Tech.Models
{
    public class UniqueAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

           

            Course courseFromReq = (Course)validationContext.ObjectInstance;

            string name = value?.ToString();

            TechContext context = new TechContext();

            Course courseFromDb = context.Courses
                .FirstOrDefault(c => c.Name == name && c.DeptId == courseFromReq.DeptId);

            if (courseFromDb == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Course name already exists in the selected department.");
        }




    }
}
