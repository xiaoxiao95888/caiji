using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Caiji.Library.Model;

namespace Caiji.Library.Service
{
    public interface IDataContext : IObjectContextAdapter, IDisposable
    {
        IDbSet<Hospital> Hospitals { get; set; }
        IDbSet<Department> Departments { get; set; }
        IDbSet<Client> Clients { get; set; }

        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
