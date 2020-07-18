using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeoShop.Models
{
    public class ShoppingCart
    {
        private AppDbContext _appDbContext;
        public string Id { get; set; }

        public List<ShopCartItem> Items { get; set; }

        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { Id = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var item = _appDbContext.ShopCartItems.SingleOrDefault(x => x.Product.Id == product.Id && x.ShoppingCartId == Id);
            if (item == null)
            {
                item = new ShopCartItem() { ShoppingCartId = this.Id, Product = product, Amount = amount };
                _appDbContext.ShopCartItems.Add(item);
            }
            else
                item.Amount++;
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var item = _appDbContext.ShopCartItems.SingleOrDefault(x => x.Product.Id == product.Id && x.ShoppingCartId == Id);
            int localAmount = 0;

            if (item != null)
            {
                if (item.Amount > 1)
                {
                    item.Amount--;
                    localAmount = item.Amount;
                }
                else
                    _appDbContext.ShopCartItems.Remove(item);
                
            }
            
            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return Items ?? (Items = _appDbContext.ShopCartItems.Where(x => x.ShoppingCartId == this.Id).Include(y => y.Product).ToList());
        }

        public void ClearChart()
        {
            var cartItems = _appDbContext.ShopCartItems.Where(x => x.ShoppingCartId == this.Id);
            _appDbContext.ShopCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _appDbContext.ShopCartItems.Where(x => x.ShoppingCartId == this.Id).Select(y => y.Product.Price * y.Amount).Sum();
            return total;
        }
    }
}
