using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace StupigShop.Data.Repositories
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetByAlias(string alias);
    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Page> GetByAlias(string alias)
        {
            return this.DbContext.Pages.Where(x => x.Alias == alias);
        }
    }
}