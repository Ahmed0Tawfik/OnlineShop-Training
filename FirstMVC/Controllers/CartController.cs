using FirstMVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstMVC.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller  
    {
        private readonly ICartRepository _CartRepository;
        public CartController(ICartRepository CartRepository)
        {
            _CartRepository = CartRepository;
        }

        public IActionResult GetCart(string id)
        {
            var model = _CartRepository.GetCart(id);
            return View("GetCart",model);
        }

        public IActionResult AddToCart(int ID)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _CartRepository.AddToCart(userid, ID);

            return RedirectToAction("GetCart", new { id = userid });
        }

        public IActionResult RemoveFromCart(int ID)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _CartRepository.RemoveFromCart(userid, ID);

            return RedirectToAction("GetCart", new { id = userid });
        }
    }
}
