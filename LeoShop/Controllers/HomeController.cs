using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeoShop.Models;
using LeoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var result = new HomeViewModel { ProductsOnSale = _productRepository.GetProductsOnSale() };
            return View(result);
        }
    }
}
