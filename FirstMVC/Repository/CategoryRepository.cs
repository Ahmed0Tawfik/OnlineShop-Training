using FirstMVC.Models;

namespace FirstMVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _Context;

        public CategoryRepository(ShopContext Context)
        {
            _Context = Context;
        }
        public List<Category> GetAll()
        {
           return _Context.Categories.ToList();
        }

       
    }
}
