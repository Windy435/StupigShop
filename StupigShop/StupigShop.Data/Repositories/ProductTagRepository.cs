using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;

namespace StupigShop.Data.Repositories
{
    public interface IProductTagRepository:IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}