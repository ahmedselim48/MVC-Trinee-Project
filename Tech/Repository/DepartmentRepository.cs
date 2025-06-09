using Tech.Models;

namespace Tech.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        TechContext context;
        public DepartmentRepository(TechContext context)
        {
            this.context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Department department)
        {
            context.Departments.Add(department);
        }
        public void Update(Department department)
        {
            context.Departments.Update(department);
        }
        public void Delete(int id)
        {
            var dept = GetById(id);
            if (dept != null)
                context.Departments.Remove(dept);
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
