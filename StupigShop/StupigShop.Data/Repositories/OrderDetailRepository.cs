using StupigShop.Data.Infrastructure;
using StupigShop.Model.Models;

namespace StupigShop.Data.Repositories
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}