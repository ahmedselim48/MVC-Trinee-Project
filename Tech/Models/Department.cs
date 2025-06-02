using System.ComponentModel.DataAnnotations;

namespace Tech.Models
{
    public class Department
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public List<Instructore> instructores { get; set; }

        public List<Course> Courses { get; set; }

        public List<Trainee> Trainees { get; set; }

            
    }
}
