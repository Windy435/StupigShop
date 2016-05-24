using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;

namespace StupigShop.Data.Repositories
{
    public interface ISystemConfigRepository:IRepository<SystemConfig>
    {
    }

    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}