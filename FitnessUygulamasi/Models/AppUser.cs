using Microsoft.AspNetCore.Identity;

namespace FitnessUygulamasi.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public int? Height { get; set; } // Boy
        public int? Weight { get; set; } // Kilo
    }
}