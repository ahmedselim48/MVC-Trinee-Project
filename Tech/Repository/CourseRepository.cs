using Microsoft.EntityFrameworkCore;
using Tech.Models;

namespace Tech.Repository
{
    public class CourseRepository : ICourseRepository
    {
        TechContext context;
       public CourseRepository(TechContext context)
        {
           this.context = context;
        }

        public void Add(Course course)
        {
            context.Add(course);


        }
        public void Update(Course course)
        {
            context.Update(course);
        }
        public void Delete(int id) 
        {
           Course cor =  GetById(id);
            context.Remove(cor);

        }
      public IEnumerable<Course> GetAll()
        {
           // return context.Courses.ToList();
            return context.Courses.Include(c => c.Department).ToList();

        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(d => d.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
