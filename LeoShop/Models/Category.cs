using System.Collections.Generic;

namespace LeoShop.Models
{
    public class Category : Entity
    {
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}