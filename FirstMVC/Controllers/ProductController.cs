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

        public IActionResult GetProductsByCategory(int id)
        {
            return View("Index", _ProductServices.GetProductsByCategory(id));
        }

        public IActionResult GetProductByID(int id)
        {
            return View("SingleProduct", _ProductServices.GetProductByID(id));
        }
    }
}
