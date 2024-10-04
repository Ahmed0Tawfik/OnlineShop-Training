
using FirstMVC.Models;
using FirstMVC.Repository;

namespace FirstMVC.Service
{
    public class CategoryServices
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryServices(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public List<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

    }
}
