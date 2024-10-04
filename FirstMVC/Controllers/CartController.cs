using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class CartController : Controller
    {
        [Authorize]
        public IActionResult GetCart()
        {
            return View();
        }
    }
}
