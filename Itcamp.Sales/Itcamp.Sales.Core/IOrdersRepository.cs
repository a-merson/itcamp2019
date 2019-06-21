using System.Linq;

namespace Itcamp.Sales.Core
{
    public interface IOrdersRepository
    {
        Order GetOrder(long id);
        void SaveOrder(Order order);
        IQueryable<Order> GetOrders();

        int GetLast3YearsCompletedOrdersCountFor(long customerId);
    }
}