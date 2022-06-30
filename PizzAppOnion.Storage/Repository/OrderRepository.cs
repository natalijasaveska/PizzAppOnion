using PizzAppOnion.Domain.Entities; 
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;

namespace PizzAppOnion.Storage.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddNewOrder(Order newOrder)
        {
            PizzaDatabase.ORDERS.Add(newOrder);
        }

        public void DeleteOrderById(int orderId)
        {
            Order order = PizzaDatabase.ORDERS.FirstOrDefault(x => x.Id == orderId);
            PizzaDatabase.ORDERS.Remove(order);
        }

        public int GenerateOrderId()
        {
            return PizzaDatabase.ORDERS.Max(x => x.Id) + 1;
        }

        public IReadOnlyList<Order> GetAllOrders()
        {
            return PizzaDatabase.ORDERS;
        }

        public Order GetOrderById(int id)
        {
            return PizzaDatabase.ORDERS.SingleOrDefault(x => x.Id == id);
        }
    }
}
