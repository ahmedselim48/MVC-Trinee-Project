using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Name Of Course")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Unique(ErrorMessage = "This course already exists in the selected department.")]
        
        public string Name { get; set; }

        [Range(50,100, ErrorMessage="Must be Between 50 and  100 ")]
        public double Degree { get; set; }

        [Remote(action: "CheckMinDegree", controller: "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than Degree")]

        public double MinDegree { get; set; }

        [DivideHoursByThree(ErrorMessage = "Invalid hours")]
        public float Hours { get; set; }

        [ForeignKey("Department")]
    
        public int DeptId { get; set; }

        public Department? Department { get; set; }

        public List<crsResult>? crsResults { get; set; }

    }
}
