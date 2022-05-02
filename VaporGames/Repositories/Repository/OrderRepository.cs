using VaporGames.Context;
using VaporGames.Models;
using VaporGames.Repositories.Interfaces;

namespace VaporGames.Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Cart _cart;

        public OrderRepository(AppDbContext appDbContext, Cart cart)
        {
            _appDbContext = appDbContext;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();


            var cartItens = _cart.GetCartItens();
            foreach(var iten in cartItens)
            {
                var orderDetail = new OrderDetails()
                {
                    GameId = iten.Game.Id,
                    OrderId = order.OrderId,
                    Price = iten.Game.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
