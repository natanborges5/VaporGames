using Microsoft.AspNetCore.Mvc;
using VaporGames.Models;
using VaporGames.Repositories.Interfaces;
using VaporGames.Repositories.Repository;

namespace VaporGames.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            List<CartItem> cartItems = _cart.GetCartItens();
            _cart.CartItens = cartItems;

            if(_cart.CartItens.Count == 0)
            {
                ModelState.AddModelError("", "Empty cart, try to add any item to the cart");

            }
            float totalPrice = _cart.GetTotalValue();
            order.TotalValue = totalPrice;
            order.TotalItensOrder = cartItems.Count();
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                ViewBag.CheckoutCompleteMsg = "Thanks for buying with us";
                ViewBag.TotalValue = totalPrice;
                _cart.CleanCart();
                return View("~/Views/Order/CheckOutComplete.cshtml",order);
            }
            return View(order);

            
        }
    }
}
