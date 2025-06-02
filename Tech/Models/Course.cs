using System.ComponentModel.DataAnnotations.Schema;

namespace Tech.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Degree { get; set; }
        public double MinDegree { get; set; }
     

        public float Hours { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department Department { get; set; }

        public List<crsResult> crsResults { get; set; }

    }
}
