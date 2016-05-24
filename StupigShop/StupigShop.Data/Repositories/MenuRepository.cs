using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;

namespace StupigShop.Data.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
    }

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}