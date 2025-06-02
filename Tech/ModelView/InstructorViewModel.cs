using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Tech.Models;

namespace Tech.ModelView
{

    public class InstructorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
   
        public string Name { get; set; }

        public string? ImageUrl { get; set; }
        //public IFormFile? ImageUrl { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "You must select a department")]
        [Display(Name= "Department")]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "You must select a course")]
        [Display(Name = "Courses")]
        public int CrsId { get; set; }

        
        public List<SelectListItem> Departments { get; set; } = new();
        public List<SelectListItem> Courses { get; set; } = new();
    }
}
