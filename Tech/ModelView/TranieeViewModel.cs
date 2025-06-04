using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tech.Models;

namespace Tech.ModelView
{
    public class TraineeViewModel
    {
        [ForeignKey("Trainee")]
        public int Id { get; set; }
        
        public string TraineeName { get; set; }
        public double Degree { get; set; }
        public double MinDegree { get; set; }
        public string CourseName { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
    }
}
