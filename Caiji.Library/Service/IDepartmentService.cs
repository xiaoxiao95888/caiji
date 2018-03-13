using System;
using System.Linq;
using Caiji.Library.Model;

namespace Caiji.Library.Service
{
    public interface IDepartmentService : IDisposable
    {
        void Insert(Department department);
        void Update();
        Department GetDepartment(Guid id);
        IQueryable<Department> GetDepartments();
        void Delete(Guid id);
    }
}
