using FirstMVC.Models;
using FirstMVC.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices _ProductServices;
        private readonly CategoryServices _CategoryServices;



        public ProductController(ProductServices ProductServices, CategoryServices CategoryServices)
        {
            _ProductServices = ProductServices;
            _CategoryServices = CategoryServices;
        }
        public IActionResult Index()
        {
            return View("Index", _ProductServices.GetAll());
        }

        public IActionResult ByCategoryBags() 
        {
            Category cat = new Category { Name = "Bags" };
            return  View("Index", _ProductServices.GetByCategory(cat));
        }
    }
}
