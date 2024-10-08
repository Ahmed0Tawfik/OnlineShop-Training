using FirstMVC.Models;

namespace FirstMVC.Repository
{
    public interface ICartRepository
    {
        public Cart GetCart(string userID);
        public void AddToCart(string userID, int productID);
        public void RemoveFromCart(string userID, int productID);
    }
}
