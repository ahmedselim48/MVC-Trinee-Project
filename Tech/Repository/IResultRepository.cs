using Tech.Models;

namespace Tech.Repository
{
    public interface IResultRepository : IRepository<crsResult>
    {
        //List<crsResult> GetAll();
        //crsResult GetById(int id);
        //List<crsResult> GetByCourseId(int courseId);
        //void Add(crsResult result);
        //void Update(crsResult result);
        //void Delete(int id);
        //void RemoveRange(List<crsResult> results);
        //void Save();

        List<crsResult> GetByCourseId(int courseId);
        void RemoveRange(List<crsResult> results);
    }
}
