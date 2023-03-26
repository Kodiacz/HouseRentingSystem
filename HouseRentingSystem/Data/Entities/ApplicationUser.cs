namespace HouseRentingSystem.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using System.Runtime.CompilerServices;

    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        : base() {
            
        }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}