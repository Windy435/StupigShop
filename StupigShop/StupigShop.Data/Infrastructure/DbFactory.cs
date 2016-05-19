using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupigShop.Data.Infrastructure
{
    public class DbFactory : Dispoable, IDbFactory
    {
        private StupigShopDbContext dbContext;
        public StupigShopDbContext Init()
        {
            return dbContext ?? (dbContext = new StupigShopDbContext());
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
                dbContext.Dispose();
        }
    }
}
