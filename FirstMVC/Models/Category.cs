using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Models
{
    public class Category
    {
        public Category()
        {
            
        }
        public int ID { get; set; }

        [MaxLength(30)]
        public required string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
