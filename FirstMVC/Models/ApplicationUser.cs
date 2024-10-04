using Microsoft.AspNetCore.Identity;

namespace FirstMVC.Models

{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
