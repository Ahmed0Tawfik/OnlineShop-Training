namespace FirstMVC.Models
{
    public class Cart
    {
        public int ID { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Total { get => Products.Sum(p => p.Price); }
    
   
    }
}
