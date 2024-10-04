using FirstMVC.Models;
using FirstMVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductServices _ProductServices;
        private readonly CategoryServices _CategoryServices;



        public CategoryController(ProductServices ProductServices, CategoryServices CategoryServices)
        {
            _ProductServices = ProductServices;
            _CategoryServices = CategoryServices;
        }
        public IActionResult Index()
        {
            return View("Index", _CategoryServices.GetAll());
        }
    }
}
