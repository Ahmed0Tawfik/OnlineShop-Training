using FirstMVC.Models;

namespace FirstMVC.ViewModel
{
    public class HomeViewModel
    {
        public List<Product> FeaturedProducts { get; set; }
        public List<Category> Categories { get; set; }
    }
}
