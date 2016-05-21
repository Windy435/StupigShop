using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;

namespace StupigShop.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        private ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}