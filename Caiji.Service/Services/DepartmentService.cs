using System;
using System.Linq;
using Caiji.Library.Model;
using Caiji.Library.Service;

namespace Caiji.Service.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(MyDbContext dbContext)
            : base(dbContext)
        {
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }

        public void Insert(Department department)
        {
            DbContext.Departments.Add(department);
            Update();
        }

        public Department GetDepartment(Guid id)
        {
            return DbContext.Departments.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Department> GetDepartments()
        {
            return DbContext.Departments.Where(n => !n.IsDeleted);
        }

        public void Delete(Guid id)
        {
            var model = DbContext.Departments.FirstOrDefault(n => n.Id == id);
            if (model != null)
            {
                DbContext.Departments.Remove(model);
                DbContext.SaveChanges();
            }
        }
    }
}
