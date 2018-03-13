using System;
using System.Linq;
using Caiji.Library.Model;

namespace Caiji.Library.Service
{
    public interface IHospitalService : IDisposable
    {
        void Insert(Hospital hospital);
        void Update();
        Hospital GetHospital(Guid id);
        IQueryable<Hospital> GetHospitals();
        void Delete(Guid id);
    }
}
