using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeoShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Categories;
        }

        public Category GetById(int id)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
