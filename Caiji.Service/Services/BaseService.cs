namespace Caiji.Service.Services
{
    public class BaseService
    {
        public readonly MyDbContext DbContext;

        public BaseService(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
