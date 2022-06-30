using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Domain.Repositories
{
    public interface IOrderRepository
    {
        IReadOnlyList<Order> GetAllOrders();
        int GenerateOrderId();
        void AddNewOrder(Order newOrder);
        void DeleteOrderById(int id);
        Order GetOrderById(int id);
    }
}
