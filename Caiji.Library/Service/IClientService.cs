using System;
using System.Linq;
using Caiji.Library.Model;

namespace Caiji.Library.Service
{
    public interface IClientService : IDisposable
    {
        void Insert(Client client);
        void Update();
        Client GetClient(Guid id);
        IQueryable<Client> GetClients();
        void Delete(Guid id);
    }
}
