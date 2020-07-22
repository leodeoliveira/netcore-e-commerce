using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeoShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.GetShopCartItems();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    Order = order,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();

        }
    }
}
