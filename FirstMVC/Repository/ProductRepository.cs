using FirstMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _Context;

        public ProductRepository(ShopContext Context)
        {
            _Context = Context;
        }
        public List<Product> GetAll()
        {
            return _Context.Products.Include(p => p.Category).ToList();
        }

        public List<Product> GetByCategory(Category category)
        {
           return _Context.Products.Where(p => p.Category == category).ToList();  
        }
    }
}
