using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Order;
using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IPizzaServices _pizzaServices;
        public OrderController(IOrderService orderService, IPizzaServices pizzaServices)
        {
            _orderService = orderService;
            _pizzaServices = pizzaServices;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            IEnumerable<OrderViewModel> orderListViewModel = _orderService.GetAllOrders();

            return View(orderListViewModel);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Pizzas = _pizzaServices.GetAllPizzas();
            OrderViewModel order = new OrderViewModel();
            return View(order);
        }

        [HttpPost]
        public ActionResult Create(OrderViewModel newOrder)
        {
             _orderService.AddNewOrder(newOrder);

            return RedirectToAction("Index","Order");
        }


        public ActionResult Delete(int id)
        {

            OrderViewModel order = _orderService.GetOrderById(id);

            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(int id,OrderViewModel order)
        {
            if(order is null)
            {
                return NotFound();
            }

            _orderService.DeleteOrder(id);

            return RedirectToAction("Index", "Order");
        }

        public ActionResult Edit(int id)
        {
            OrderViewModel order = _orderService.GetOrderById(id);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(int id,OrderViewModel updateOrder)
        {
            _orderService.UpdateOrder(id, updateOrder);

            return RedirectToAction("Index", "Order");

        }
    }
}
