using Tech.Models;

namespace Tech.Repository
{
    public class ResultRepository : IResultRepository
    {
        TechContext context;
        public ResultRepository(TechContext context)
        {
            this.context = context;
        }
        public IEnumerable<crsResult> GetAll()
        {
            return context.crsResults.ToList();
        }


        public crsResult GetById(int id)
        {
            return context.crsResults.FirstOrDefault(r => r.Id == id);
        }

        public List<crsResult> GetByCourseId(int courseId)
        {
            return context.crsResults.Where(r => r.CrsId == courseId).ToList();
        }

        public void Add(crsResult result)
        {
            context.crsResults.Add(result);
        }

        public void Update(crsResult result)
        {
            context.crsResults.Update(result);
        }

        public void Delete(int id)
        {
            var result = GetById(id);
            if (result != null)
            {
                context.crsResults.Remove(result);
            }
        }

        public void RemoveRange(List<crsResult> results)
        {
            context.crsResults.RemoveRange(results);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
