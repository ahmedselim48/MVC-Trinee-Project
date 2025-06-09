using Tech.Models;

namespace Tech.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
     

        TechContext context;
        public InstructorRepository(TechContext context)
        {
            this.context = context;
        }
        public IEnumerable<Instructore> GetAll()
        {
            return context.Instructors.ToList(); 
        }

        public Instructore GetById(int id)
        {
            return context.Instructors.FirstOrDefault(i => i.Id == id);
        }

        public List<Instructore> GetByCourseId(int courseId)
        {
            return context.Instructors.Where(i => i.CrsId == courseId).ToList();
        }

        public void Add(Instructore instructor)
        {
            context.Instructors.Add(instructor);
        }

        public void Update(Instructore instructor)
        {
            context.Instructors.Update(instructor);
        }

        public void Delete(int id)
        {
            var instructor = GetById(id);
            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
            }
        }

        public void RemoveRange(List<Instructore> instructors)
        {
            context.Instructors.RemoveRange(instructors);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
