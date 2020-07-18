using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeoShop.Models;
using LeoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeoShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.GetAll().OrderBy(x => x.Id);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.GetAll().Where(x => x.Category.Name == category).OrderBy(x => x.Id);
                currentCategory = category;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
