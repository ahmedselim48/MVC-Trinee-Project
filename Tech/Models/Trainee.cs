using System.ComponentModel.DataAnnotations.Schema;

namespace Tech.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Address { get; set; }

        public double Grade { get; set; } 

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department Department { get; set; }

     public List<crsResult> crsResults { get; set; }
    }
}
