using PizzAppOnion.Contracts.ViewModels.Order;

namespace PizzAppOnion.Contracts.Services
{
    public interface IOrderService
    {
        IReadOnlyList<OrderViewModel> GetAllOrders();

        void AddNewOrder(OrderViewModel order);
        void DeleteOrder(int id);
        OrderViewModel GetOrderById(int id);
        void UpdateOrder(int id, OrderViewModel updateOrder);
    }
}
