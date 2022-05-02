using Microsoft.AspNetCore.Mvc;
using VaporGames.Models;
using VaporGames.ViewModels;

namespace VaporGames.Components
{
    public class CartSize : ViewComponent
    {
        private readonly Cart _cart;

        public CartSize(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _cart.GetCartItens();
            _cart.CartItens = itens;
            var cartVm = new CartViewModel
            {
                Cart = _cart,
                TotalValue = _cart.GetTotalValue(),
            };
            return View(cartVm);

        }
    }
}
