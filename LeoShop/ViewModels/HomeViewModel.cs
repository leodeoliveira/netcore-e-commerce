using LeoShop.Models;
using System.Collections.Generic;

namespace LeoShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> ProductsOnSale { get; set; }
    }
}
