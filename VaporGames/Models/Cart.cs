using Microsoft.EntityFrameworkCore;
using VaporGames.Context;

namespace VaporGames.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;

        public Cart(AppDbContext context)
        {
            _context = context;
        }

        public string CartId { get; set; }
        public List<CartItem> CartItens { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new Cart(context)
            {
                CartId = cartId
            };
        }
        public void AddToCart(Game game)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Game.Id == game.Id && s.CartId == CartId);

            if(cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Game = game,
                };
                _context.CartItems.Add(cartItem);
            }
            _context.SaveChanges();  
        }
        public void RemoveItemFromCart(Game game)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Game.Id == game.Id && s.CartId == CartId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges();       
        }
        public List<CartItem> GetCartItens()
        {
            return CartItens ??
                (CartItens = _context.CartItems
                .Where(c=> c.CartId == CartId)
                .Include(s => s.Game)
                .ToList());
                
        }
        public void CleanCart()
        {
            var cartItens = _context.CartItems.Where(cart => cart.CartId == CartId);
            _context.CartItems.RemoveRange(cartItens);
            _context.SaveChanges();
        }
        public float GetTotalValue()
        {
            var total = _context.CartItems.Where(c => c.CartId == CartId)
                .Select(c => c.Game.Price).Sum();
            return total;
        }
    }
}
