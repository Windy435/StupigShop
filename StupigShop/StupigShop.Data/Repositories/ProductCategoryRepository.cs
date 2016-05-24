using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StupigShop.Data.Repositories
{
    public interface IProductCategoryRepositoy:IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepositoy
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategorys.Where(x => x.Alias == alias);
        }
    }
}