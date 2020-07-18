using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeoShop.Models;
using LeoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeoShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShopCartItems();
            _shoppingCart.Items = items;

            var result = new ShoppingCartViewModel { ShoppingCart = _shoppingCart, ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()  };
            return View(result);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            Product product = _productRepository.GetById(productId);
            if (product != null)
                _shoppingCart.AddToCart(product, 1);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            Product product = _productRepository.GetById(productId);
            if (product != null)
                _shoppingCart.RemoveFromCart(product);

            return RedirectToAction("Index");
        }
    }
}
