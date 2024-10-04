using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstMVC.Models
{
    public class Product
    {
       
        public int ID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        public required Category Category { get; set; }
        public required decimal Price { get; set; }
        public required string Image {  get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }


    }
}
