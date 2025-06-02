using System.ComponentModel.DataAnnotations.Schema;

namespace Tech.Models
{
    public class Instructore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(10,2)")]
       
        public Decimal Salary { get; set; }

        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }


        [ForeignKey("Course")]
        public int CrsId { get; set; }


        public Department Department { get; set; }
        public Course Course { get; set; }





    }
}
