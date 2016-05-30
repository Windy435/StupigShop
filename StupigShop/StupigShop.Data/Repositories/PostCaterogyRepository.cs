using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace StupigShop.Data.Repositories
{
    public interface IPostCategoryRepository:IRepository<PostCategory>
    {
        IEnumerable<PostCategory> GetByAlias(string alias);
    }

    public class PostCaterogyRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCaterogyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<PostCategory> GetByAlias(string alias)
        {
            return this.DbContext.PostCategories.Where(x => x.Alias == alias);
        }
    }
}