using FirstMVC.Service;
using Microsoft.AspNetCore.Mvc;


namespace FirstMVC.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly CategoryServices _CategoryServices;

        public CategoryViewComponent(CategoryServices CategoryServices)
        {
            _CategoryServices = CategoryServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _CategoryServices.GetAll();
        return View(categories);  
        }
    }
}
