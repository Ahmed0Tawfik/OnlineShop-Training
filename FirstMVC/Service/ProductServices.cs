using FirstMVC.Models;
using FirstMVC.Repository;

namespace FirstMVC.Service
{
    public class ProductServices
    {
        private readonly IProductRepository _ProductRepository;
        public ProductServices(IProductRepository ProductRepository)
        {
             _ProductRepository = ProductRepository;
        }

        public List<Product> GetAll() 
        { 
            return _ProductRepository.GetAll(); 
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return _ProductRepository.GetProductsByCategory(id);
        }

        public List<Product> GetFeaturedProducts()
        {
            return _ProductRepository.GetAll().OrderBy(p => Guid.NewGuid()).Take(3).ToList();
        }

        public Product GetProductByID(int id)
        {
            return _ProductRepository.GetProductById(id);
        }
    }
}
