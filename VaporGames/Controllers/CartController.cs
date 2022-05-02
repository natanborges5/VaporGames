using Microsoft.AspNetCore.Mvc;
using VaporGames.Models;
using VaporGames.Repositories.Interfaces;
using VaporGames.ViewModels;

namespace VaporGames.Controllers
{
    public class CartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly Cart _cart;

        public CartController(IGameRepository gameRepository, Cart cart)
        {
            _gameRepository = gameRepository;
            _cart = cart;
        }

        public IActionResult Index()
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
        public IActionResult AddGameToCart(int gameId)
        {
            var gameSelected = _gameRepository.GetGameById(gameId);
            if(gameSelected != null)
            {
                _cart.AddToCart(gameSelected);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveGameFromCart(int gameId)
        {
            var gameSlected = _gameRepository.GetGameById(gameId);
            if(gameSlected != null)
            {
                _cart.RemoveItemFromCart(gameSlected);
            }
            return RedirectToAction("Index");
        }
    }
}
