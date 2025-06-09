using Tech.Models;

namespace Tech.Repository
{
    public interface IInstructorRepository :  IRepository<Instructore>
    {
        //IEnumerable<Instructore> GetAll();
        //Instructore GetById(int id);
        //List<Instructore> GetByCourseId(int courseId);
        //void Add(Instructore instructor);
        //void Update(Instructore instructor);
        //void Delete(int id);
        //void RemoveRange(List<Instructore> instructors);
        //void Save();
        List<Instructore> GetByCourseId(int courseId);
        void RemoveRange(List<Instructore> instructors);
    }
}
