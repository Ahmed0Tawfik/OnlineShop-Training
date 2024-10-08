using FirstMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        public List<Product> GetProductsByCategory(int id);
        public Product GetProductById(int id);
       
    }
}
