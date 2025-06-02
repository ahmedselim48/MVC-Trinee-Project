using System.ComponentModel.DataAnnotations.Schema;

namespace Tech.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public double Degree { get; set; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }

        public Course Course { get; set; }

        public Trainee Trainee { get; set; }

    }
}
