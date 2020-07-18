using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeoShop.Models
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _appDbContext.Products.Include(c => c.Category);
        }
        public Product GetById(int id)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsOnSale()
        {
            return _appDbContext.Products.Where(p => p.IsOnSale);
        }
    }
}
