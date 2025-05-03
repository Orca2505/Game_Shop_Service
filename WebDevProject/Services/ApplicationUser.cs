using Microsoft.EntityFrameworkCore;
using WebDevProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebDevProject.Services

{
    public class ApplicationUser : IdentityUser
    {
        public string user_name { get; set; } = string.Empty;
    }
}
