

using Microsoft.AspNetCore.Identity;

namespace CoreIdentity102.Models
{
    public class AppUser: IdentityUser
    {
        public string? City { get; set; }
    }
}
