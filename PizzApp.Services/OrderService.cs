using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Order;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Services.Mappers;

namespace PizzAppOnion.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IPizzaRepository _pizzaRepository;
        public OrderService(IOrderRepository orderRepository,IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }

        public void AddNewOrder(OrderViewModel order)
        {
            Pizza selectPizza = _pizzaRepository.GetPizzaById(order.PizzaId);

            int orderId = _orderRepository.GenerateOrderId();

            Order newOrder = new Order()
            {
                CreatedAt = order.CreatedAt,
                Pizzas = new List<Pizza> { selectPizza },
                Id = orderId,
            };

            _orderRepository.AddNewOrder(newOrder);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrderById(id);
        }

        public IReadOnlyList<OrderViewModel> GetAllOrders()
        {
            IReadOnlyList<Order> dbOrders = _orderRepository.GetAllOrders();

            return dbOrders.Select(x => x.ToOrderViewModel()).ToArray();
        }

        public OrderViewModel GetOrderById(int id)
        {
            Order order = _orderRepository.GetOrderById(id);

            return order.ToOrderViewModel();
        }

        public void UpdateOrder(int id, OrderViewModel updateOrder)
        {
            Order order = _orderRepository.GetOrderById(id);

            order.CreatedAt = updateOrder.CreatedAt;
        }
    }
}
