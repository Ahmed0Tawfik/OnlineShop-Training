using Microsoft.AspNetCore.Identity;

namespace FirstMVC.Models

{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public Cart Cart { get; set; } = new Cart();    
    }
}
