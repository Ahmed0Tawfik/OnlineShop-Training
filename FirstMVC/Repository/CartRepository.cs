using FirstMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Repository
{
    public class CartRepository: ICartRepository
    {
        private readonly ShopContext _Context;
        public CartRepository(ShopContext Context)
        {
            _Context = Context;
        }
        public Cart GetCart(string userID)
        {
            var model = _Context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserID == userID);
            return model;
        }

        public void AddToCart(string userID, int productID)
        {
            Product product = _Context.Products.FirstOrDefault(p => p.ID == productID);

            _Context.Carts.FirstOrDefault(c => c.UserID == userID).Products.Add(product);

            product.Quantity--;

            SaveChanges();
        }

        public void RemoveFromCart(string userID, int productID)
        {
            var cart = _Context.Carts.Include(c => c.Products)
                                      .FirstOrDefault(c => c.UserID == userID);

            if (cart != null)
            {
                var product = cart.Products.FirstOrDefault(p => p.ID == productID);

                if (product != null)
                {
                    cart.Products.Remove(product);
                    product.Quantity++;
                    SaveChanges();
                }
            }
        }


        public void ClearCart(string userID)
        {
            throw new System.NotImplementedException();
        }

        private void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}
