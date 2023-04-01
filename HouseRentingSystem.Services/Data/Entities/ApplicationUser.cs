namespace HouseRentingSystem.Services.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        : base() {
            
        }

        [Required]
        [StringLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}