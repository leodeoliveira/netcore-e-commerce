using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeoShop.Models
{
    public class Product : Entity
    {
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string AllergyInformation { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsOnSale { get; set; }

        public bool HasStock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
