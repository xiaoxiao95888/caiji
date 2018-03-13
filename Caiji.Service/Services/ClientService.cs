using System;
using System.Linq;
using Caiji.Library.Model;
using Caiji.Library.Service;

namespace Caiji.Service.Services
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(MyDbContext dbContext)
            : base(dbContext)
        {
        }
        public void Insert(Client client)
        {
            DbContext.Clients.Add(client);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }

        public Client GetClient(Guid id)
        {
            return DbContext.Clients.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Client> GetClients()
        {
            return DbContext.Clients.Where(n=>!n.IsDeleted);
        }


        public void Delete(Guid id)
        {
            var model = DbContext.Clients.FirstOrDefault(n => n.Id == id);
            if (model != null)
            {
                DbContext.Clients.Remove(model);
                DbContext.SaveChanges();
            }
        }
    }
}
