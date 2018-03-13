using System;
using System.Linq;
using Caiji.Library.Model;
using Caiji.Library.Service;

namespace Caiji.Service.Services
{
    public class HospitalService : BaseService, IHospitalService
    {
        public HospitalService(MyDbContext dbContext)
            : base(dbContext)
        {
        }

        public void Delete(Guid id)
        {
            var model = DbContext.Hospitals.FirstOrDefault(n => n.Id == id);
            if (model != null)
            {
                DbContext.Hospitals.Remove(model);
                Update();
            }
        }

        public Hospital GetHospital(Guid id)
        {
            return DbContext.Hospitals.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Hospital> GetHospitals()
        {
            return DbContext.Hospitals.Where(n => !n.IsDeleted);
        }

        public void Insert(Hospital hospital)
        {
            DbContext.Hospitals.Add(hospital);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
