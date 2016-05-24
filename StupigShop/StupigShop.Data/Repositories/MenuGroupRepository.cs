using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;

namespace StupigShop.Data.Repositories
{
    public interface IMenuGroupRepository:IRepository<MenuGroup>
    {
    }

    public class MenuGroupRepository : RepositoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}