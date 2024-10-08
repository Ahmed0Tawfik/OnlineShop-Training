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

        public List<Product> GetProductsByCategory(int id)
        {
           return _Context.Products.Where(p => p.Category.ID == id ).ToList();  
        }

        public Product GetProductById(int id)
        {
            return _Context.Products.Include(p => p.Category).FirstOrDefault(p => p.ID == id);
        }
    }
}
