namespace HouseRentingSystem.Core.Models.Agent
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeAgentModel
    {
        [StringLength(15, MinimumLength = 7)]
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
