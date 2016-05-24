using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace StupigShop.Data.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetByAlias(string alias);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias);
        }
    }
}