using FirstMVC.Models;
using FirstMVC.Service;
using FirstMVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductServices _ProductServices;
        private readonly CategoryServices _CategoryServices;
        public HomeController(ILogger<HomeController> logger, ProductServices ProductServices, CategoryServices CategoryServices)
        {
            _logger = logger;
            _CategoryServices = CategoryServices;
            _ProductServices = ProductServices;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

                model.FeaturedProducts = _ProductServices.GetFeaturedProducts();
                model.Categories = _CategoryServices.GetAll();

            return View("Index",model);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
